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



namespace Evo2App
{
    public partial class FormDebug : Form
    {
        private  Evo2Engine _evoEngine;


        public FormDebug(Evo2Engine evoEngine)
        {
            InitializeComponent();
            _evoEngine = evoEngine;
        }

        private void FormDebug_Load(object sender, EventArgs e)
        {
            if (_evoEngine != null)
            {
                _evoEngine.OnGeneration_Started += evoEngine_OnGenerationStarted;
                _evoEngine.OnGeneration_Completed += evoEngine_OnGenerationCompleted;
                _evoEngine.OnIteration_Completed += evoEngine_OnIterationCompleted;


                lblGen.Text = _evoEngine.eGrid.generation.ToString();
                lblIter.Text = _evoEngine.eGrid.iteration.ToString();
            }

            


        }




        private void evoEngine_OnIterationCompleted(int generation, int iteration, EResultIteration resultIteration)
        {
            this.InvokeEx(
                () =>
                {
                    lblIter.Text = iteration.ToString();
                }
            );
        }

        private void evoEngine_OnGenerationStarted(int generation)
        {
            this.InvokeEx(
                () =>
                {
                    lblGen.Text = generation.ToString();
                    lblIter.Text = "0";
                }
            );
        }

        private void evoEngine_OnGenerationCompleted(int generation, int iteration, EResultGeneration resultGeneration)
        {
            this.InvokeEx(
                () =>
                {
                    lblGen.Text = generation.ToString();
                    lblIter.Text = iteration.ToString();
                }
            );
        }

        

        
    }
}
