using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        private void Timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from T_SyncTable where IsSync = 0";
            DataSet myds = Maticsoft.DBUtility.DbHelperSQL.Query(sql, null);
            int Count = myds.Tables["ds"].Rows.Count;
            textBox1.Text = "发送的数据"+Count+"条";
            for (int i = 1; i <= Count; i++)
            {
                object aa, bb, cc, dd, ee, ff, gg;
                if (myds.Tables["ds"].Rows[i - 1][1] == DBNull.Value)
                {
                    aa = "null";
                }
                else
                {
                    aa = "'" + myds.Tables["ds"].Rows[i - 1][1] + "'";
                }
                if (myds.Tables["ds"].Rows[i - 1][2] == DBNull.Value)
                {
                    bb = "null";
                }
                else
                {
                    bb = "'" + myds.Tables["ds"].Rows[i - 1][2] + "'";
                }
                if (myds.Tables["ds"].Rows[i - 1][3] == DBNull.Value)
                {
                    cc = "null";
                }
                else
                {
                    cc = "'" + myds.Tables["ds"].Rows[i - 1][3] + "'";
                }
                if (myds.Tables["ds"].Rows[i - 1][4] == DBNull.Value)
                {
                    dd = "null";
                }
                else
                {
                    dd = "'" + myds.Tables["ds"].Rows[i - 1][4] + "'";
                }
                if (myds.Tables["ds"].Rows[i - 1][5] == DBNull.Value)
                {
                    ee = "null";
                }
                else
                {
                    ee = "'" + myds.Tables["ds"].Rows[i - 1][5] + "'";
                }
                if (myds.Tables["ds"].Rows[i - 1][6] == DBNull.Value)
                {
                    ff = "null";
                }
                else
                {
                    ff = "'" + myds.Tables["ds"].Rows[i - 1][6] + "'";
                }
                if (myds.Tables["ds"].Rows[i - 1][7] == DBNull.Value)
                {
                    gg = "null";
                }
                else
                {
                    gg = "'" + myds.Tables["ds"].Rows[i - 1][7] + "'";
                }
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql1(Maticsoft.DBUtility.DbHelperSQL.connectionString2, "insert into T_SyncTable(AlarmContent,InsertTime,IsSync,Remark,Remark1,Remark2,Remark3) values(" + aa + ", " + bb + ", " + cc + ", " + dd + "," + ee + "," + ff + "," + gg + ")");        
                textBox2.Text = "接收的数据" + i + "条";
                Refresh();
                object b = myds.Tables["ds"].Rows[i - 1][0];
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update T_SyncTable set IsSync = 1 where id = " + b + "");
            }
        }
    }
}
