using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string con, sql;
            con = "Server=.;Database=SK_CKAlarm;user id=sa;password=8482134;";
            sql = "select * from T_SyncTable";
            SqlConnection mycon = new SqlConnection(con);
            mycon.Open();
            SqlDataAdapter myda = new SqlDataAdapter(sql, con);
            DataSet myds = new DataSet();
            myda.Fill(myds, "T_SyncTable");
            dataGridView1.DataSource = myds.Tables["T_SyncTable"];
            mycon.Close();
            string conn, sqll;
            conn = "Server=172.18.3.119;Database=SK_CKAlarm;user id=sa;password=security999;";   
            for (int i = 0; i <= 1; i++)
            {                
                SqlConnection myconn = new SqlConnection(con);
                myconn.Open();
                object b = myds.Tables["T_SyncTable"].Rows[i][0];
                object c = myds.Tables["T_SyncTable"].Rows[i][1];
                object d = myds.Tables["T_SyncTable"].Rows[i][2];
                object ee = myds.Tables["T_SyncTable"].Rows[i][3];
                sqll = "insert into T_SyncTable(AlarmContent,InsertTime,IsSync,Remark) values(" + b + "," + c + "," + d + "," + ee + ")";
                SqlCommand comm = new SqlCommand(sqll, myconn);
                comm.ExecuteReader();
                mycon.Close();
            } 
        }
    }
}
