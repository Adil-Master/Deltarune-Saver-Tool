using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaruneSaverTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chapter_2 chapter_2 = new Chapter_2();

            this.Hide();

            if (chapter_2.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Chapter_1 chapter_1 = new Chapter_1();
            
            this.Hide();
            
            if (chapter_1.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chapter_3 chapter_3 = new Chapter_3();

            this.Hide();

            if (chapter_3.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Chapter_4 chapter_4 = new Chapter_4();

            this.Hide();

            if (chapter_4.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();

            aboutBox1.ShowDialog();
        }
    }
}
