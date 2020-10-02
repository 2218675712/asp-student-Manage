

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class OperaterBase
    {
        public static DataSet GetData(string sql)
        /*
         * 查询数据库
         */
        {
            // string con = ConfigurationManager.ConnectionStrings["wareHouseEntity"].ConnectionString;
            string conn = "server=W10-20200915921;uid=sa;pwd=2218675712;database=student1";
            SqlConnection sct = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter(sql, sct);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
        public static int CommandBySql(string sql)
        /*
         * 增删改
         */
        {
            // string con = ConfigurationManager.ConnectionStrings["wareHouseEntity"].ConnectionString;
            string conn = "server=W10-20200915921;uid=sa;pwd=2218675712;database=student1";
            SqlConnection sct = new SqlConnection(conn);
            SqlCommand smd = new SqlCommand(sql, sct);
            sct.Open();//打开数据库链接
            int flag = smd.ExecuteNonQuery();
            sct.Close();//关闭数据库链接
            return flag;
        }
    }
}