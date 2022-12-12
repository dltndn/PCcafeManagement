using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeamProject
{
    public partial class Form1 : Form
    {
        private OracleConnection odpConn = new OracleConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FoodManageForm frm = new FoodManageForm();
            frm.ShowDialog();
            frm.Dispose();
        }
        private void manageBtn_Click(object sender, EventArgs e)
        {
            ManageForm frm = new ManageForm();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Get_owner_id("oqwfhhpiow"); //임시 id 사용
            string[] user_arr;
            int[] seat_arr;
            user_arr = Get_user_from_seat(); //select user_id from seat where is_on=1; 배열
            seat_arr = Get_seat_num_from_seat(); //select seat_id from seat where is_on=1; 배열
            for (int i = 0; i < user_arr.Length; i += 1)
            {
                string text;
                int seat_num;
                Label label;
                if (user_arr[i] != null)
                {
                    text = Get_user_name_left_time(user_arr[i]);
                    seat_num = seat_arr[i];
                    label = find_label_num(seat_num);
                    label.Text = text;
                }
            }

        }
        private void Get_owner_id(string id)
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "SELECT owner_id FROM owner WHERE owner_id=:id";
            OracleCommand OraCmdS = new OracleCommand(strqry, odpConn);
            OraCmdS.Parameters.Add("id", OracleDbType.Char).Value = id;
            OracleDataReader rdr = OraCmdS.ExecuteReader();
            while (rdr.Read())
            {
                label62.Text = rdr["owner_id"] as string;
            }
            rdr.Close();
            odpConn.Close();
        }
        private string[] Get_user_from_seat() //자리 이용중인 유저 아이디 배열에 추가
        {
            string[] arr = new string[16];
            OracleDataReader rdr = Get_data_reader_from_seat();
            int i = 0;
            while (rdr.Read())
            {
                // 필드 데이터 읽기
                string s = rdr["USER_ID"] as string;
                arr[i] = s;
                i += 1;
            }
            rdr.Close();
            odpConn.Close();
            return arr; 
        }
        private int[] Get_seat_num_from_seat() //자리 이용중인 seat number 배열에 추가
        {
            int[] arr = new int[16];
            OracleDataReader rdr = Get_data_reader_from_seat();
            int i = 0;
            while (rdr.Read())
            {
                // 필드 데이터 읽기
                int n = Convert.ToInt32(rdr["seat_id"]);
                arr[i] = n;
                i += 1;
            }
            rdr.Close();
            odpConn.Close();
            return arr;
        }
        private OracleDataReader Get_data_reader_from_seat() //이용중인 자리 select
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "SELECT * FROM seat WHERE is_on=:bool";
            OracleCommand OraCmdS = new OracleCommand(strqry, odpConn);
            OraCmdS.Parameters.Add("bool", OracleDbType.Char).Value = '1';
            OracleDataReader rdr = OraCmdS.ExecuteReader();
            return rdr;
        }
        private string Get_user_name_left_time(string user_id) //user 정보 select, 이름, 남은시간 리턴
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "SELECT * FROM user_data WHERE user_id=:user_id";
            OracleCommand OraCmdS = new OracleCommand(strqry, odpConn);
            OraCmdS.Parameters.Add("user_id", OracleDbType.Char).Value = user_id;
            OracleDataReader rdr = OraCmdS.ExecuteReader();
            string text = "";
            while (rdr.Read())
            {
                string name = rdr["user_name"] as string;
                int left_time = Convert.ToInt32(rdr["left_time"]);
                text = name + "\n" + Convert_left_time(left_time);
            }
            rdr.Close();
            odpConn.Close();
            return text;
        }
        private string Convert_left_time(int seconds) //시:분:초 형식으로 변환
        {    
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            seconds = (seconds % 3600) % 60;
            string result = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            return result;
        }
        private Label find_label_num(int s_num)
        {
            switch (s_num)
            {
                case 1:
                    return label1;
                case 2:
                    return label2;
                case 3:
                    return label3;
                case 4:
                    return label4;
                case 5:
                    return label5;
                case 6:
                    return label6;
                case 7:
                    return label7;
                case 8:
                    return label8;
                case 9:
                    return label9;
                case 10:
                    return label10;
                case 11:
                    return label11;
                case 12:
                    return label12;
                case 13:
                    return label13;
                case 14:
                    return label14;
                case 15:
                    return label15;
                case 16:
                    return label16;
            }
            return label16;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


       
    }
}
