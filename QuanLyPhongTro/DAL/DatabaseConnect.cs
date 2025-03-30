using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.DAL
{
    internal class DatabaseConnect
    {
        SqlConnection sqlConn;
        SqlDataAdapter da;
        DataSet ds;
        public   DatabaseConnect()
        {
            string strConn = "Data source= MinhNhutSoftware\\SQLEXPRESS; Database=Boarding_House_Management; Integrated Security = True";
            sqlConn = new SqlConnection(strConn);
        }

        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
           
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
               
                return ds.Tables[0];
            }
            return new DataTable();
        }
        public int ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn);
            sqlConn.Open();
            int result = sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
            return result;
        }
    }
}
