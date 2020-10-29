using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mobile = Session["mobile"].ToString();
                if (!string.IsNullOrEmpty(mobile))
                {
                    string time = System.DateTime.Now.ToString();
                    Response.Write("欢迎" + mobile + "，您在" + time + "登录");
                }

                repeaterGetData();
            }
        }

        /// <summary>
        /// 默认查询
        /// </summary>
        public void repeaterGetData()
        {
            //1.修改查询sql语句 只要主表的ID
            //2.查看隐藏控件中的ID是否获取到了
            /*DataSet ds =
                OperaterBase.GetData(
                    "select a.*,b.className from studentInfo a left join classInfo b on a.classID=b.classID where a.IsDelete=0 and b.IsDelete=0");
            */
            // 利用视图查询
            DataSet ds =
                OperaterBase.GetData(
                    "select * from v_StudentInfo_ClassInfo");

            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int studentID = Convert.ToInt32(((HiddenField) e.Item.FindControl("hfStudentId")).Value);
            if (e.CommandName == "Delete")
            {
                string sql = "update studentInfo set IsDelete=1 where studentID=" + studentID + "";
                int flag = OperaterBase.CommandBySql(sql);
                if (flag > 0)
                {
                    Response.Write("<script type='text/javascript'>alert(成功删除：'" + flag + "'条数据);</script>");
                    repeaterGetData();
                }
            }
            else if (e.CommandName == "Edit")
            {
                Response.Redirect("/WebForm2.aspx?studentID=" + studentID + "");
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // 跳转页面
            Response.Redirect("/WebForm2.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var mobile = TextBox1.Text;
            if (mobile == "")
            {
                repeaterGetData();
            }
            else
            {
                string sql =
                    "select a.*,b.className from studentInfo as a left join classInfo as b on a.classID=b.classID where a.IsDelete=0 and b.IsDelete=0 and a.mobile='" +
                    mobile + "'";
                DataSet ds = OperaterBase.GetData(sql);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
        }
/// <summary>
/// 退出登录
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}