using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Information_Safty_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Remote_Control_Form RCF = new Remote_Control_Form();
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            PassW_Break RCF = new PassW_Break();
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void P_R_Button_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form1 RCF = new Form1();
            RCF.Show();
            this.Hide();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

       
    }
}
