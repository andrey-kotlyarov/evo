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

        private FormDebug _formDebug;




        public FormEvo()
        {
            InitializeComponent();
        }

        private void FormEvo_Load(object sender, EventArgs e)
        {
            _pause = true;
            btnStart.Enabled = _pause;
            btnPause.Enabled = !_pause;
            



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
            cbDelay.SelectedIndex = 2;



            //
            //ONE EVENT
            //
            cbOneEvent.Checked = true;


            evoEngine_Work();
            return;
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
            catch (OperationCanceledException ocex)
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
            

            _evoEngine = null;
            _tokenSource = null;

            btnStart.Enabled = false;
            btnPause.Enabled = false;
        }








        private void evoEngine_OnIterationCompleted(int generation, int iteration, EGrid eGrid)
        {
            if (cbOneEvent.Checked) btnPause_Click(null, null);
            //addReportMessage(String.Format("evoEngine_OnIterationCompleted G:{0} I:{1}", generation, iteration));
        }

        private void evoEngine_OnGenerationStarted(int generation)
        {
            if (cbOneEvent.Checked) btnPause_Click(null, null);
            addReportMessage(String.Format("evoEngine_OnGenerationStarted G:{0}", generation));
        }

        private void evoEngine_OnGenerationCompleted(int generation, int iteration, EGrid eGrid)
        {
            if (cbOneEvent.Checked) btnPause_Click(null, null);
            addReportMessage(String.Format("evoEngine_OnGenerationCompleted G:{0} I:{1}", generation, iteration));
        }


        private void addReportMessage(string message)
        {
            string txt = txtReport.Text;

            if (txt.Length > 0) txt += "\r\n";
            txt += message;

            txtReport.Text = txt;
        }

        
        

    }
}
