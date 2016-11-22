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
    public partial class Form4 : Form
    {
        private Form1 startPage;
        public Form4(Form1 st)
        {
            InitializeComponent();
            startPage = st;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {

            startPage.Show();
            e.Cancel = true;
            this.Hide();
        }
    }
}
