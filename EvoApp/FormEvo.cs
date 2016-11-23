using System;
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
            updateControls();

            
        }

        private void FormEvo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _pbGridBufferGraphics.Dispose();
        }

        /*
        private void FormEvo_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            //e.Graphics.DrawLine(pen, 20, 10, 300, 100);

            e.Graphics.DrawLine(pen, this.Width, this.Height, 300, 100);
        }
        */

        private void loadControls()
        {
            selDelay.Items.Add("10");
            selDelay.Items.Add("20");
            selDelay.Items.Add("30");
            selDelay.Items.Add("50");
            selDelay.Items.Add("100");
            selDelay.Items.Add("200");
            selDelay.Items.Add("500");

            selDelay.SelectedIndex = 3;

            cbIterEnabled.Checked = true;


            _pbGridBufferGraphics = BufferedGraphicsManager.Current.Allocate(pbGrid.CreateGraphics(), pbGrid.DisplayRectangle);

        }

        private void updateControls()
        {
            lblGen.Text = Grid.CurrentGrid.generation.num.ToString();
            lblIter.Text = Grid.CurrentGrid.generation.iteration.ToString();

            drawGrid();
        }

        

        private void drawGrid()
        {
            Graphics g = _pbGridBufferGraphics.Graphics;

            g.Clear(Color.Gray);

            //int it = Grid.CurrentGrid.generation.iteration;
            Cell[,] cells = Grid.CurrentGrid.cells;

            int size = 24;

            for (int y = 0; y < Const.GRID_SIZE_Y; y++)
            {
                for (int x = 0; x < Const.GRID_SIZE_X; x++)
                {
                    int px = x * size;
                    int py = y * size;

                    Rectangle r = new Rectangle(px - 1, py - 1, size - 2, size - 2);

                    if (cells[x, y].content == CellContentType.EMPTY)
                    {
                        g.FillRectangle(Brushes.DarkGray, r);
                    }
                    if (cells[x, y].content == CellContentType.WALL)
                    {
                        g.FillRectangle(Brushes.Black, r);
                    }
                    if (cells[x, y].content == CellContentType.FOOD)
                    {
                        g.FillRectangle(Brushes.Green, r);
                    }
                    if (cells[x, y].content == CellContentType.TOXIN)
                    {
                        g.FillRectangle(Brushes.Red, r);
                    }
                    if (cells[x, y].content == CellContentType.BOT)
                    {
                        g.FillRectangle(Brushes.Blue, r);
                    }
                }
            }


            //g.DrawEllipse(Pens.Blue, pbGrid.DisplayRectangle);
            //g.DrawRectangle(Pens.Gold, 10, 10, it * 4, it * 2);
            //g.FillRectangle(Brushes.Violet, 12, 12, it * 4 - 4, it * 2 - 4);


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
                    updateControls();
                }
            );
        }

        private void _workerEvo_NextGeneration(int i)
        {
            this.InvokeEx(
                () =>
                {
                    updateControls();
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
