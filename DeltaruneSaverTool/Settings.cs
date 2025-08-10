using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeltaruneSaverTool
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            textBox1.Text = DeltaruneSaverTool.Properties.Settings.Default.Saves_Path;
            textBox2.Text = DeltaruneSaverTool.Properties.Settings.Default.Game_Path;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeltaruneSaverTool.Properties.Settings.Default.Saves_Path = textBox1.Text;
            DeltaruneSaverTool.Properties.Settings.Default.Game_Path = textBox2.Text;
            DeltaruneSaverTool.Properties.Settings.Default.Save();

            if (!File.Exists(textBox1.Text + @"\Chapter_1"))
            {
                Directory.CreateDirectory(textBox1.Text + @"\Chapter_1");
            }
            if (!File.Exists(textBox1.Text + @"\Chapter_2"))
            {
                Directory.CreateDirectory(textBox1.Text + @"\Chapter_2");
            }
            if (!File.Exists(textBox1.Text + @"\Chapter_3"))
            {
                Directory.CreateDirectory(textBox1.Text + @"\Chapter_3");
            }
            if (!File.Exists(textBox1.Text + @"\Chapter_4"))
            {
                Directory.CreateDirectory(textBox1.Text + @"\Chapter_4");
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SavesFolderDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = SavesFolderDialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GamePathFileDialog.Filter = "DELTARUNE.exe|*.exe";
            
            if (GamePathFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = GamePathFileDialog.FileName;
            }
        }
    }
}
