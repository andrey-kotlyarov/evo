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
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //txtTest.Text = "btnTest_Click\r\n1\r\n2\r\n3";

            Grid grid = new Grid();
            //txtTest.Text = grid.ToString();
            txtTest.Text = grid.ToMonoString();
        }
    }
}
