using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public partial class QuantityChangeForm : Form
    {
        public QuantityChangeForm()
        {
            InitializeComponent();
        }
        public string AmmText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
