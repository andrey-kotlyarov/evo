﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EvoLib;
using System.Threading;



namespace EvoApp
{
    public partial class FormEvo : Form
    {

        private WorkerEvo _workerEvo;
        private CancellationTokenSource _tokenSource;

        private BufferedGraphics _pbGridBufferGraphics;


        public FormEvo()
        {
            InitializeComponent();
        }

        private void FormEvo_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;


            loadControls();
            updateControlsGen();

            
        }

        private void FormEvo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _pbGridBufferGraphics.Dispose();
        }
        

        private void loadControls()
        {
            selDelay.Items.Add("1");
            selDelay.Items.Add("10");
            selDelay.Items.Add("20");
            selDelay.Items.Add("30");
            selDelay.Items.Add("50");
            selDelay.Items.Add("100");
            selDelay.Items.Add("200");
            selDelay.Items.Add("500");

            selDelay.SelectedIndex = 4;

            cbIterEnabled.Checked = true;


            _pbGridBufferGraphics = BufferedGraphicsManager.Current.Allocate(pbGrid.CreateGraphics(), pbGrid.DisplayRectangle);

        }


        private void updateControlsIter()
        {
            lblIter.Text = Grid.CurrentGrid.generation.iteration.ToString();
            drawGrid();
        }

        private void updateControlsGen()
        {
            lblGen.Text = Grid.CurrentGrid.generation.num.ToString();

            string lastIter = "";

            for (int i = Grid.CurrentGrid.generation.num - 1; i >= Math.Max(0, Grid.CurrentGrid.generation.num - 32); i--)
            {
                lastIter += (lastIter.Length == 0 ? "" : "\r\n");
                lastIter += Grid.CurrentGrid.generations[i].iteration.ToString();
            }




            txtIter.Text = lastIter;

            updateControlsIter();
        }



        private void drawGrid()
        {
            
            Color colorGrid = Color.DarkGray;
            Brush brushWall = Brushes.Maroon;
            Brush brushEmpty = Brushes.LightGray;
            Brush brushBot = Brushes.Navy;
            Brush brushFood = Brushes.Green;
            Brush brushToxin = Brushes.OrangeRed;

            Font fontBot = new Font(FontFamily.GenericSansSerif, 6.0F, FontStyle.Regular);
            Brush brushFont = Brushes.White;

            Font fontBot2 = new Font(FontFamily.GenericSansSerif, 5.0F, FontStyle.Bold);
            Brush brushFont2 = Brushes.Yellow;

            Graphics g = _pbGridBufferGraphics.Graphics;




            g.Clear(colorGrid);


            




            //int it = Grid.CurrentGrid.generation.iteration;
            Cell[,] cells = Grid.CurrentGrid.cells;

            int size = 24;

            for (int y = 0; y < Const.GRID_SIZE_Y; y++)
            {
                for (int x = 0; x < Const.GRID_SIZE_X; x++)
                {
                    int px = x * size + 1;
                    int py = y * size + 1;

                    Rectangle r = new Rectangle(px + 1, py + 1, size - 2, size - 2);
                    Rectangle rc = new Rectangle(px + 3, py + 3, size - 6, size - 6);


                    if (cells[x, y].content == CellContentType.EMPTY)
                    {
                        g.FillRectangle(brushEmpty, r);
                    }
                    if (cells[x, y].content == CellContentType.WALL)
                    {
                        g.FillRectangle(brushWall, r);
                    }
                    if (cells[x, y].content == CellContentType.FOOD)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushFood, rc);
                    }
                    if (cells[x, y].content == CellContentType.TOXIN)
                    {
                        g.FillRectangle(brushEmpty, r);
                        g.FillEllipse(brushToxin, rc);
                    }
                    if (cells[x, y].content == CellContentType.BOT)
                    {
                        g.FillRectangle(brushBot, r);

                        Bot bot = Grid.CurrentGrid.GetBot(cells[x, y]);
                        g.DrawString(bot.health.ToString(), fontBot, brushFont, px + 1, py + 2);
                        g.DrawString(bot.age.ToString(), fontBot2, brushFont2, px + 10, py + 12);

                    }
                }
            }

            


            //_pbGridBufferGraphics.Render();
            _pbGridBufferGraphics.Render(pbGrid.CreateGraphics());
        }



        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            statusLabel.Text = "start";

            _workerEvo = new WorkerEvo();
            _workerEvo.NextIteration += _workerEvo_NextIteration;
            _workerEvo.NextGeneration += _workerEvo_NextGeneration;

            _workerEvo_ChangeParam();

            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;


            Task<int> task = null;
            int result;
            string message = "";

            try
            {
                task = Task<int>.Factory.StartNew(() => _workerEvo.Work(token), token);
                result = await task;
            }
            catch (OperationCanceledException ocex)
            {
                //cancelled = true;
            }
            catch (Exception ex)
            {
                //isError = true;
                message = string.Format("Error: {0}", ex.Message);
            }
            
            if (!task.IsFaulted)
            {
                message = (task.IsCanceled ? "cancel" : "finish");
            }



            _workerEvo = null;
            _tokenSource = null;

            statusLabel.Text = message;
            btnStart.Enabled = true;
            
            btnStop.Enabled = false;
        }
        

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_workerEvo != null && _tokenSource != null)
            {
                statusLabel.Text = "stopped";
                _tokenSource.Cancel();
            }
        }







        private void _workerEvo_NextIteration(int i)
        {
            this.InvokeEx(
                () =>
                {
                    updateControlsIter();
                }
            );
        }

        private void _workerEvo_NextGeneration(int i)
        {
            this.InvokeEx(
                () =>
                {
                    updateControlsGen();
                }
            );
        }

        private void _workerEvo_ChangeParam()
        {
            if (_workerEvo != null)
            {
                _workerEvo.SetDelay(Convert.ToInt32(selDelay.SelectedItem.ToString()));
                _workerEvo.SetIterationEnabled(cbIterEnabled.Checked);
            }
        }

        private void cbIterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _workerEvo_ChangeParam();
        }

        private void selDelay_SelectedIndexChanged(object sender, EventArgs e)
        {
            _workerEvo_ChangeParam();
        }

        
    }
}
