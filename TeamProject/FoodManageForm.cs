using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace TeamProject
{
    public partial class FoodManageForm : Form
    {
        private int SelectedRowIndex;
        OracleDataAdapter DBAdapter;
        DataSet DS;
        OracleCommandBuilder myCommandBuilder;
        DataTable foodTable;
        private int SelectedKeyValue;

        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=hong1; Password = 1111; Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); ";
                string commandString = "select * from food";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }

            try
            {
                DS.Clear();//***
                DBAdapter.Fill(DS, "food");
                dataGridView1.DataSource = DS.Tables["food"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        
    }
        public FoodManageForm()
        {
            InitializeComponent();
            DB_Open();
        }

        private void button1_Click(object sender, EventArgs e) //확인
        {
            Close();
        }

       private void button2_Click(object sender, EventArgs e)  //재고변경
        {
            /*QuantityChangeForm cFrm = new QuantityChangeForm();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = item.SubItems;
                cFrm.AmmText = subItem[1].Text;
                if (cFrm.ShowDialog() == DialogResult.OK)
                {
                    subItem[1].Text = cFrm.AmmText;
                }
            }
            cFrm.Dispose();*/
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
