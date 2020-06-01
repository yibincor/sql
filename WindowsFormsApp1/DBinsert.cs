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
    public partial class DBInsert : Form
    {
        public DBInsert()
        {
            InitializeComponent();
        }        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string sql = "select * from T_SyncTable where IsSync = 0";
            DataSet myds = Maticsoft.DBUtility.DbHelperSQL.Query(sql, null);
            int Count = myds.Tables["ds"].Rows.Count;
            textBox1.Text = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss ") + "获取需要发送报警同步的数据：" + Count+"条";
            for (i = 1; i <= Count; i++)
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
                j = j + i;
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql1(Maticsoft.DBUtility.DbHelperSQL.connectionString2, "insert into T_SyncTable(AlarmContent,InsertTime,IsSync,Remark,Remark1,Remark2,Remark3) values(" + aa + ", " + bb + ", " + cc + ", " + dd + "," + ee + "," + ff + "," + gg + ")");
                textBox2.Text = myds.Tables["ds"].Rows[i - 1][2]+" 已发送报警同步成功数据：" + i+ "条"+" 总发送报警同步成功数据："+j + "条";               
                object b = myds.Tables["ds"].Rows[i - 1][0];
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update T_SyncTable set IsSync = 1 where id = " + b + "");
            }

            string sql2 = "select * from T_ACKTable where IsSync = 0";
            DataSet myds2 = Maticsoft.DBUtility.DbHelperSQL.Query2(sql2);
            int Count2 = myds2.Tables["dt"].Rows.Count;
            textBox3.Text = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss ") + "获取需要接收报警同步的数据：" + Count2 + "条";
            for (k = 1; k <= Count2; k++)
            {
                object aa, bb, cc, dd, ee, ff, gg, hh;
                if (myds2.Tables["dt"].Rows[k - 1][1] == DBNull.Value)
                {
                    aa = "null";
                }
                else
                {
                    aa = "'" + myds2.Tables["dt"].Rows[k - 1][1] + "'";
                }
                if (myds2.Tables["dt"].Rows[k - 1][2] == DBNull.Value)
                {
                    bb = "null";
                }
                else
                {
                    bb = "'" + myds2.Tables["dt"].Rows[k - 1][2] + "'";
                }
                if (myds2.Tables["dt"].Rows[k - 1][3] == DBNull.Value)
                {
                    cc = "null";
                }
                else
                {
                    cc = "'" + myds2.Tables["dt"].Rows[k - 1][3] + "'";
                }
                if (myds2.Tables["dt"].Rows[k - 1][4] == DBNull.Value)
                {
                    dd = "null";
                }
                else
                {
                    dd = "'" + myds2.Tables["dt"].Rows[k - 1][4] + "'";
                }
                if (myds2.Tables["dt"].Rows[k - 1][5] == DBNull.Value)
                {
                    ee = "null";
                }
                else
                {
                    ee = "'" + myds2.Tables["dt"].Rows[k - 1][5] + "'";
                }
                if (myds2.Tables["dt"].Rows[k - 1][6] == DBNull.Value)
                {
                    ff = "null";
                }
                else
                {
                    ff = "'" + myds2.Tables["dt"].Rows[k - 1][6] + "'";
                }
                if (myds2.Tables["dt"].Rows[k - 1][7] == DBNull.Value)
                {
                    gg = "null";
                }
                else
                {
                    gg = "'" + myds2.Tables["dt"].Rows[k - 1][7] + "'";
                }
                if (myds2.Tables["dt"].Rows[k - 1][8] == DBNull.Value)
                {
                    hh = "null";
                }
                else
                {
                    hh = "'" + myds2.Tables["dt"].Rows[k - 1][8] + "'";
                }
                l = l + k;
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql1(Maticsoft.DBUtility.DbHelperSQL.connectionString, "insert into T_ACKTable(AckAlarmContent,AckInsertTime,IsSync,Remark,Remark1,Remark2,Remark3,Type) values( " + aa + ", " + bb + ", " + cc + ", " + dd + "," + ee + "," + ff + "," + gg + "," + hh + ")");
                textBox4.Text = myds2.Tables["dt"].Rows[k - 1][2] + " 已接收报警同步成功数据：" + k + "条" + " 总接收报警同步成功数据：" + l + "条";
                object b = myds2.Tables["dt"].Rows[k - 1][0];
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql2("update T_ACKTable set IsSync = 1 where id = " + b + "");
            }
            timer1.Enabled = true;
        }

        int i = 0;int j = 0;int k = 0;int l = 0;

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void DBInsert_Load(object sender, EventArgs e)
        {

        }
    }
}
