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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Grid grid = new Grid();


        private void btnTest_Click(object sender, EventArgs e)
        {
            //txtTest.Text = "btnTest_Click\r\n1\r\n2\r\n3";
            

            txtTest.Text = Grid.CurrentGrid.ToString();
            //txtTest.Text = Grid.CurrentGrid.ToMonoString();
        }

        

        private void btnNextIteration_Click(object sender, EventArgs e)
        {
            Grid.CurrentGrid.NextIteration();
            txtTest.Text = Grid.CurrentGrid.ToMonoString();
        }







        private Worker _worker;
        private CancellationTokenSource _tokenSource;
        //private TaskScheduler _scheduler;



        private void Form1_Load(object sender, EventArgs e)
        {
            //_scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            /*
            _worker = new Worker();
            //_worker.WorkCompleted += _worker_WorkCompleted;
            _worker.ProcessChanged += _worker_ProcessChanged;

            btnStart.Enabled = false;

            bool cancelled = await Task<bool>.Factory.StartNew(_worker.Work);

            lblWork.Text = (cancelled ? "cancel" : "finish");
            btnStart.Enabled = true;
            */

            btnStart.Enabled = false;

            _worker = new Worker();
            _worker.ProcessChanged += _worker_ProcessChanged;

            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            
            Task<int> task = null;
            //bool isError = false;
            //bool cancelled = false;
            int result;
            string message = "";

            try
            {
                task = Task<int>.Factory.StartNew(() => _worker.Work(token), token);
                result = await task;
            }
            catch (OperationCanceledException)
            {
                //cancelled = true;
            }
            catch (Exception ex)
            {
                //isError = true;
                message = string.Format("Error: {0}", ex.Message);
            }
            

            /*
            if (!isError)
            {
                //message = (cancelled ? "cancel" : "finish");
                message = (task.IsCanceled ? "cancel" : "finish");
            }
            */

            if (!task.IsFaulted)
            {
                message = (task.IsCanceled ? "cancel" : "finish");
            }

            lblWork.Text = message;
            btnStart.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_worker != null && _tokenSource != null)
            {
                _tokenSource.Cancel();
            }
        }


        private void _worker_WorkCompleted(int progress)
        {

        }

        private void _worker_ProcessChanged(int progress)
        {
            this.InvokeEx(
                () =>
                {
                    lblWork.Text = progress.ToString();
                }
            );
        }
    }
}
