using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFT
{
    public partial class Form2 : Form
    {
        private Form1 startPage;
        public Form2(Form1 st)
        {
            InitializeComponent();
            startPage = st;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            startPage.Show();
            e.Cancel = true;
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
