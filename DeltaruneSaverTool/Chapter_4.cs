using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DeltaruneSaverTool
{
    public partial class Chapter_4 : Form
    {
        public Chapter_4()
        {
            InitializeComponent();

            string Programm_Saves = DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\";
            if (!File.Exists(Programm_Saves + "data.txt"))
            {
                File.WriteAllText(Programm_Saves + "data.txt", "");
            }

            listBox1.Items.Clear();
            var lines = File.ReadAllLines(Programm_Saves + @"data.txt");
            listBox1.Items.AddRange(lines);
        }

        private void Chapter_4_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Height = 520;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string Programm_Saves = DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4";
                string Game_Saves = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DELTARUNE\";
                string Game_Slot = comboBox1.SelectedIndex.ToString();
                string Save_File = Game_Saves + "filech4_" + Game_Slot;
                string Save_Name = textBox1.Text;
                string Saved_File = Programm_Saves + @"\" + Save_Name + @"\filech4_" + Game_Slot;

                Directory.CreateDirectory(Programm_Saves + @"\" + Save_Name);

                File.Copy(Save_File, Saved_File);

                listBox1.Items.Add(Save_Name);
                string Data_0 = File.ReadAllText(Programm_Saves + @"\data.txt");
                string Data_1 = Data_0 + Save_Name + "\n";

                File.WriteAllText(Programm_Saves + @"\data.txt", Data_1);

                textBox1.Text = "";
                this.Height = 480;
            }
            else
            {
                MessageBox.Show("Select Save Slot!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string Programm_Saves = DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\";
                string Game_Saves = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DELTARUNE\";
                string Save_0 = "";
                string Game_Slot_1 = comboBox1.SelectedIndex.ToString();

                if (File.Exists(Programm_Saves + @"\" + listBox1.SelectedItem + @"\filech4_0"))
                {
                    Save_0 = @"\filech4_0";
                }
                else if (File.Exists(Programm_Saves + @"\" + listBox1.SelectedItem + @"\filech4_1"))
                {
                    Save_0 = @"\filech4_1";
                }
                else if (File.Exists(Programm_Saves + @"\" + listBox1.SelectedItem + @"\filech4_2"))
                {
                    Save_0 = @"\filech4_2";
                }

                File.Delete(Game_Saves + "filech4_" + Game_Slot_1);
                File.Copy(Programm_Saves + @"\" + listBox1.SelectedItem + @"\" + Save_0, Game_Saves + "filech4_" + Game_Slot_1);
                MessageBox.Show("Completed!");
            }
            else
            {
                MessageBox.Show("Select Save Slot!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Game_Saves = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DELTARUNE\";

            File.Delete(Game_Saves + @"\filech4_0");
            File.Delete(Game_Saves + @"\filech4_1");
            File.Delete(Game_Saves + @"\filech4_2");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (DeltaruneSaverTool.Properties.Settings.Default.Game_Path == "null")
            {
                MessageBox.Show("Add Game Path in Settings");
            }
            else
            {
                Process.Start(DeltaruneSaverTool.Properties.Settings.Default.Game_Path);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.Delete(DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\" + listBox1.SelectedItem + @"\filech4_0");
            Directory.Delete(DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\" + listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);

            var items = listBox1.Items.Cast<string>().ToArray();
            File.WriteAllLines(DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\data.txt", items);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Programm_Saves = DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\";

            if (ExportDialog.ShowDialog() == DialogResult.OK)
            {
                string data_0 = File.ReadAllText(Programm_Saves + @"\" + listBox1.SelectedItem + @"\filech4_0");
                File.WriteAllText(ExportDialog.FileName, data_0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Programm_Saves = DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\";

            if (ImportDialog.ShowDialog() == DialogResult.OK)
            {
                Import import = new Import();

                if (import.ShowDialog() == DialogResult.OK)
                {
                    listBox1.Items.Add(DeltaruneSaverTool.Properties.Settings.Default.ImportName);

                    Directory.CreateDirectory(Programm_Saves + DeltaruneSaverTool.Properties.Settings.Default.ImportName);
                    File.Copy(ImportDialog.FileName, Programm_Saves + DeltaruneSaverTool.Properties.Settings.Default.ImportName + @"\filech4_0");

                    var items = listBox1.Items.Cast<string>().ToArray();
                    File.WriteAllLines(DeltaruneSaverTool.Properties.Settings.Default.Saves_Path + @"\Chapter_4\data.txt", items);
                }
            }
        }
    }
}
