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
    public partial class CreatePassenger : Form
    {
        private StartPage startPage;
        public CreatePassenger(StartPage st)
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
