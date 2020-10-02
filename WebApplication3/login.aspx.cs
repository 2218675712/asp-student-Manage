using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;

namespace WebApplication3
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mobile = TextBox1.Text;
            string password = TextBox2.Text;
            string sql = "select * from studentInfo where mobile='" + mobile + "' and password='" + password +
                         "'";
            DataSet ds = OperaterBase.GetData(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = "登录成功";
            }
            else
            {
                Label1.Text = "登录失败";
            }

            // 跳转页面
            Response.Redirect("/WebForm1.aspx");
        }
    }
}