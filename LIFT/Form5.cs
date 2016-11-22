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
    public partial class Form5 : Form
    {
        private Form1 startPage;
        public Form5(Form1 st)
        {
            InitializeComponent();
            startPage = st;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            startPage.Show();
        }
    }
}
