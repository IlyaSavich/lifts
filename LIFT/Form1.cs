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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            start = new Form2(this);
            init = new Form3(this);
            create = new Form4(this);
            
            
        }
        Form2 start;
        Form3 init;
        Form4 create;
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void initializationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            init.Show();
            this.Hide();

        }

        private void inputParametresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            create.Show();
            this.Hide();
        }

        private void timerWorkingTime_Tick(object sender, EventArgs e)
        {
            statusPanelWorkingTime.Text = DateTime.Now.ToString("HH:mm:ss"); // TODO show time from start system
        }

        private void startMenuSubitem_Click(object sender, EventArgs e)
        {
            start.Show();
            this.Hide();
        }

        private void stopMenuSubitem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void initMenuSubitem_Click(object sender, EventArgs e)
        {
            init.Show();
            this.Hide();
        }
    }
}
