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
    public partial class Form3 : Form
    {
        private Form1 startPage;
        public Form3(Form1 st)
        {
            InitializeComponent();
            startPage = st;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            startPage.Show();
            e.Cancel = true;
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
