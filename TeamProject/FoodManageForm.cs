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
    public partial class FoodManageForm : Form
    {
        public FoodManageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //확인
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)  //재고변경
        {
            QuantityChangeForm cFrm = new QuantityChangeForm();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = item.SubItems;
                cFrm.AmmText = subItem[1].Text;
                if (cFrm.ShowDialog() == DialogResult.OK)
                {
                    subItem[1].Text = cFrm.AmmText;
                }
            }
            cFrm.Dispose();
        }

        private void 이메일주소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetInformationForm iFrm = new SetInformationForm();
            iFrm.ShowDialog();
        }

        private void 알림수량ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetQuantityAlarmForm qFrm = new SetQuantityAlarmForm();
            qFrm.ShowDialog();
        }
    }
}
