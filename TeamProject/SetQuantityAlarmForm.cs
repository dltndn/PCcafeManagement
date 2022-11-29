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
    public partial class SetQuantityAlarmForm : Form
    {
        private OracleConnection odpConn = new OracleConnection();
        FoodManageForm _parent;
        public SetQuantityAlarmForm(FoodManageForm inform1)
        {
            InitializeComponent();
            _parent = inform1;
        }
        private void SetQuantityAlarmForm_Load(object sender, EventArgs e)
        {
           
        }

        private int UPDATERow()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "UPDATE owner SET limit_value=:limit_value WHERE owner_id='admin'";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OraCmd.Parameters.Add("limit_value", OracleDbType.Int32).Value = numericUpDown1.Text.Trim();
            return OraCmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UPDATERow() > 0)
            {
                MessageBox.Show("정상적으로 데이터가 업데이트됨!");
            }
            else MessageBox.Show("데이터 행이 업데이트되지 않음!");
            this.Close();
        }

        
    }
}
