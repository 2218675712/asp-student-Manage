using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;

namespace WebApplication3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string studentNum = TextBox1.Text;
            string mobile = TextBox2.Text;
            string newPassword = TextBox3.Text;
            DataSet ds = OperaterBase.GetData("select * from studentInfo where studentNum='" + studentNum +
                                              "' and mobile='" + mobile + "'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                Label4.Text = "信息不对，请检查";
                return;
            }

            string studentId = ds.Tables[0].Rows[0]["studentID"].ToString();
            int num = OperaterBase.CommandBySql("update studentInfo set password='" + newPassword +
                                                "' where studentID=" + studentId + "");
            if (num > 0)
            {
                Label4.Text = "新密码设置成功，请登录";
                Response.Redirect("login.aspx");
            }
            else
            {
                Label4.Text = "程序异常";
            }
        }
    }
}