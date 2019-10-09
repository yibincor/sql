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
            string sql = "select * from T_SyncTable";
            DataSet myds = Maticsoft.DBUtility.DbHelperSQL.Query(sql, null);
            string conn, sqll;
            conn = "Server=172.18.3.119;Database=SK_CKAlarm;user id=sa;password=security999;";
            for (int i = 0; i <= 2; i++)
            {
                object a = 1;
                if (myds.Tables["ds"].Rows[i][3] != a)
                {
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update T_SyncTable set IsSync = 1");
                } 
            }
        }            
    }
}
