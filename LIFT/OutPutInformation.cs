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
    public partial class OutPutInformation : Form
    {
        private StartPage startPage;
        public OutPutInformation(StartPage st)
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
