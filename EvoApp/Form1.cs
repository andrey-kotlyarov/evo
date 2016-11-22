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



namespace EvoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Grid.CurrentGrid.CreateGrid();
        }


        //Grid grid = new Grid();


        private void btnTest_Click(object sender, EventArgs e)
        {
            //txtTest.Text = "btnTest_Click\r\n1\r\n2\r\n3";
            

            txtTest.Text = Grid.CurrentGrid.ToString();
            //txtTest.Text = Grid.CurrentGrid.ToMonoString();
        }

        private void btnNextGeneration_Click(object sender, EventArgs e)
        {
            Grid.CurrentGrid.NextGeneration();
            txtTest.Text = Grid.CurrentGrid.ToMonoString();
        }

        private void btnNextIteration_Click(object sender, EventArgs e)
        {
            Grid.CurrentGrid.NextIteration();
            txtTest.Text = Grid.CurrentGrid.ToMonoString();
        }
    }
}
