using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Evo2Lib;
using System.Threading;



namespace Evo2App
{
    public partial class FormEvo : Form
    {
        private Evo2Engine _evoEngine;
        private CancellationTokenSource _tokenSource;
        private bool _pause;
        private bool _firstlyShowGrid = false;

        private BufferedGraphics _pbGridBufferGraphics;

        private FormDebug _formDebug;
        


        public FormEvo()
        {
            InitializeComponent();
        }

        private void FormEvo_Load(object sender, EventArgs e)
        {
            _pbGridBufferGraphics = BufferedGraphicsManager.Current.Allocate(pbGrid.CreateGraphics(), pbGrid.DisplayRectangle);

            _pause = true;
            btnStart.Enabled = _pause;
            btnPause.Enabled = !_pause;

            slblStatus.Text = "load";



            //
            //EVENT VIA
            //
            cbEventVia.DisplayMember = "Text";
            cbEventVia.ValueMember = "Value";
            cbEventVia.DataSource = new[]
            {
                //new { Text = "Paused mode", Value = "-1" },
                new { Text = "Iteration mode", Value = "0" },
                new { Text = "Generation mode", Value = "1" },
                new { Text = "Generation 10", Value = "10" },
                new { Text = "Generation 100", Value = "100" },
                new { Text = "Generation 1000", Value = "1000" }
            };
            cbEventVia.SelectedIndex = 0;



            //
            //DELAY
            //
            cbDelay.DisplayMember = "Text";
            cbDelay.ValueMember = "Value";
            cbDelay.DataSource = new[]
            {
                new { Text = "10", Value = "10" },
                new { Text = "20", Value = "20" },
                new { Text = "40", Value = "40" },
                new { Text = "100", Value = "100" },
                new { Text = "200", Value = "200" },
                new { Text = "500", Value = "500" },
                new { Text = "1000", Value = "1000" }
            };
            //cbDelay.SelectedIndex = 2;
            cbDelay.SelectedIndex = 0;


            //
            //ONE EVENT
            //
            //cbOneEvent.Checked = true;
            cbOneEvent.Checked = false;


            evoEngine_Work();
            return;
        }

        private void FormEvo_MouseEnter(object sender, EventArgs e)
        {
            // Первоначальное отображение ГРИДА
            if (!_firstlyShowGrid)
            {
                if (_evoEngine != null)
                {
                    lblGen.Text = _evoEngine.eGrid.generation.ToString();
                    lblIter.Text = _evoEngine.eGrid.iteration.ToString();

                    drawGrid();
                    _firstlyShowGrid = true;
                }
            }
        }
        

        private void FormEvo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _pbGridBufferGraphics.Dispose();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            evoEngine_SetParam();
            evoEngine_SetPause(false);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            evoEngine_SetPause(true);
        }
        



        private void cbEventVia_SelectedIndexChanged(object sender, EventArgs e)
        {
            evoEngine_SetParam();
        }

        private void cbDelay_SelectedIndexChanged(object sender, EventArgs e)
        {
            evoEngine_SetParam();
        }


        

        private void btnDebug_Click(object sender, EventArgs e)
        {
            if (_formDebug == null)
            {
                _formDebug = new FormDebug(_evoEngine);
                _formDebug.FormClosed += formDebug_FormClosed;
                _formDebug.Show();

                btnDebug.Enabled = false;
            }
        }

        private void formDebug_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formDebug = null;
            btnDebug.Enabled = true;
        }

        private void evoEngine_SetPause(bool pause)
        {
            if (_evoEngine != null)
            {
                _pause = pause;
                _evoEngine.SetPause(_pause);

                btnStart.Enabled = _pause;
                btnPause.Enabled = !_pause;

                slblStatus.Text = (_pause ? "paused" : "run");
            }
        }

        private void evoEngine_SetParam()
        {
            if (_evoEngine != null)
            {
                _evoEngine.SetEventVia(Convert.ToInt32(cbEventVia.SelectedValue));
                _evoEngine.SetDelay(Convert.ToInt32(cbDelay.SelectedValue));
            }
        }

        

        private async void evoEngine_Work()
        {
            _evoEngine = new Evo2Engine();

            evoEngine_SetPause(_pause);
            evoEngine_SetParam();
            
            _evoEngine.OnGeneration_Started += evoEngine_OnGenerationStarted;
            _evoEngine.OnGeneration_Completed += evoEngine_OnGenerationCompleted;
            _evoEngine.OnIteration_Completed += evoEngine_OnIterationCompleted;

            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            Task<EGrid> task = null;
            EGrid eGrid;
            string message = "";
            
            
            try
            {
                task = Task<EGrid>.Factory.StartNew(() => _evoEngine.Work(token), token);
                eGrid = await task;
            }
            catch (OperationCanceledException)
            {
                //cancelled = true;
            }
            catch (Exception ex)
            {
                message = string.Format("error: {0}", ex.Message);
            }

            if (!task.IsFaulted)
            {
                message = (task.IsCanceled ? "cancel" : "finish");
            }


            slblStatus.Text = message;


            _evoEngine = null;
            _tokenSource = null;

            btnStart.Enabled = false;
            btnPause.Enabled = false;
        }

















        private void drawGrid()
        {
            if (_evoEngine == null) return;

            EGrid grid = _evoEngine.eGrid;

            Color colorGrid = Color.DarkGray;
            Brush brushWall = Brushes.Maroon;
            Brush brushEmpty = Brushes.LightGray;
            Brush brushBot = Brushes.Navy;
            Brush brushBot0 = Brushes.LightSeaGreen;
            Brush brushBot1 = Brushes.LightCyan;
            Brush brushFood = Brushes.Green;
            Brush brushToxin = Brushes.OrangeRed;

            Font fontBot = new Font(FontFamily.GenericSansSerif, 6.0F, FontStyle.Regular);
            Brush brushFont = Brushes.White;

            Font fontBot2 = new Font(FontFamily.GenericSansSerif, 5.0F, FontStyle.Bold);
            Brush brushFont2 = Brushes.Yellow;

            Graphics g = _pbGridBufferGraphics.Graphics;




            g.Clear(colorGrid);







            //int it = Grid.CurrentGrid.generation.iteration;
            ECell[,] cells = grid.cells;

            int size = 24;

            for (int y = 0; y < ESetting.GRID_SIZE_Y; y++)
            {
                for (int x = 0; x < ESetting.GRID_SIZE_X; x++)
                {
                    int px = x * size + 1;
                    int py = y * size + 1;

                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    Rectangle rc = new Rectangle(px + 3, py + 3, size - 6, size - 6);


                    if (cells[x, y].type == ECellType.EMPTY)
                    {
                        g.FillRectangle(brushEmpty, r);
                    }
                    if (cells[x, y].type == ECellType.WALL)
                    {
                        g.FillRectangle(brushWall, r);
                    }
                    if (cells[x, y].type == ECellType.FOOD)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushFood, rc);
                    }
                    if (cells[x, y].type == ECellType.TOXIN)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushToxin, rc);
                    }
                    if (cells[x, y].type == ECellType.BOT)
                    {
                        /*
                        EBot bot = Grid.CurrentGrid.GetBot(cells[x, y]);

                        if (bot.point == Grid.CurrentGrid.generation.bots[0].point)
                        {
                            g.FillRectangle(brushBot0, r);
                        }
                        else if (bot.point == Grid.CurrentGrid.generation.bots[1].point)
                        {
                            g.FillRectangle(brushBot1, r);
                        }
                        else
                        {
                            g.FillRectangle(brushBot, r);
                        }



                        g.DrawString(bot.health.ToString(), fontBot, brushFont, px + 1, py + 2);
                        g.DrawString(bot.age.ToString(), fontBot2, brushFont2, px + 10, py + 12);
                        */
                    }
                }
            }

            for (int i = 0; i < grid.bots.Length; i++)
            {
                EBot bot = grid.bots[i];


                if (bot.alive)
                {
                    int px = bot.point.x * size + 1;
                    int py = bot.point.y * size + 1;

                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    g.FillRectangle(brushBot, r);

                    g.DrawString(bot.health.ToString(), fontBot, brushFont, px + 1, py + 2);
                    g.DrawString(bot.generation.ToString(), fontBot2, brushFont2, px + 10, py + 12);
                }

            }




            //_pbGridBufferGraphics.Render();
            _pbGridBufferGraphics.Render(pbGrid.CreateGraphics());
        }


































        private void evoEngine_OnIterationCompleted(int generation, int iteration, EResultIteration resultIteration)
        {
            this.InvokeEx(
                () =>
                {
                    if (cbOneEvent.Checked) btnPause_Click(null, null);

                    lblGen.Text = generation.ToString();
                    lblIter.Text = iteration.ToString();

                    slblResultIteration.Text = resultIteration.ToShortString();
                    drawGrid();

                    //addReportMessage(String.Format("evoEngine_OnIterationCompleted G:{0} I:{1}", generation, iteration));
                }
            );
            
        }

        private void evoEngine_OnGenerationStarted(int generation)
        {
            this.InvokeEx(
                () =>
                {
                    if (cbOneEvent.Checked) btnPause_Click(null, null);

                    lblGen.Text = generation.ToString();
                    lblIter.Text = "0";

                    slblResultIteration.Text = "";

                    //addReportMessage(String.Format("evoEngine_OnGenerationStarted G:{0}", generation));
                }
            );

            
        }

        private void evoEngine_OnGenerationCompleted(int generation, int iteration, EResultGeneration resultGeneration)
        {
            this.InvokeEx(
                () =>
                {
                    if (cbOneEvent.Checked) btnPause_Click(null, null);

                    lblGen.Text = generation.ToString();
                    lblIter.Text = iteration.ToString();



                    updateHistory();
                    //addReportMessage(String.Format("evoEngine_OnGenerationCompleted G:{0} I:{1}", generation, iteration));
                }
            );
            
        }

        private void updateHistory()
        {
            EHistory eHistory = _evoEngine.eGrid.history;


            string history = "";

            for (int i = 0; i < Math.Min(32, eHistory.items.Count); i++)
            {
                history += (history.Length == 0 ? "" : "\r\n");
                history += "  " + eHistory.items[i].ToShortString();
            }
            
            txtHistory.Text = history;

            lblGenBest.Text = eHistory.bestItem.generation.ToString();
            lblIterBest.Text = eHistory.bestItem.iteration.ToString();


        }
















        /*
        private void addReportMessage(string message)
        {
            string txt = txtReport.Text;

            if (txt.Length > 0) txt += "\r\n";
            txt += message;

            txtReport.Text = txt;
        }
        */



    }
}
