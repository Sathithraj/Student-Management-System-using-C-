using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSFORBIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentList s = new studentList();
            s.TopLevel = false;
            panel4.Controls.Add(s);
            s.BringToFront();
            s.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            courseList c = new courseList();
            c.TopLevel = false;
            panel4.Controls.Add(c);
            c.BringToFront();
            c.Show();
        }
    }
}
