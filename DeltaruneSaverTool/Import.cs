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
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeltaruneSaverTool.Properties.Settings.Default.ImportName = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
