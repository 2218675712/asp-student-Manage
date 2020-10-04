using System;
using System.Data;
using System.Web.UI;
using WebApplication2;

namespace WebApplication3
{
    public partial class WebForm2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getClassInfoData();
                var ID = Convert.ToInt32(Request["studentID"]);
                if (ID == 0) return;
                Button1.CommandName = "Update";
                UpdateUser();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        /// <summary>
        /// 修改用户数据
        /// </summary>
        private void UpdateUser()
        {
            var ID = Convert.ToInt32(Request["studentID"]);
            string sql = "select * from  studentInfo where studentID = " + ID + "";
            DataSet ds = OperaterBase.GetData(sql);
            TextBox1.Text = ds.Tables[0].Rows[0]["studentName"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["classID"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["studentNum"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["studentSex"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["password"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["birthday"].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0]["province"].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0]["city"].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0]["district"].ToString();
            TextBox11.Text = ds.Tables[0].Rows[0]["address"].ToString();
            // TODO 可以进行提交，写语句调用adduser方法
        }

        /// <summary>
        /// 提交用户
        /// </summary>
        private void AddUser()
        {
            int ID = Convert.ToInt32(Request["studentID"]);
            // .Trim()去掉空格
            string v1 = TextBox1.Text.Trim();
            string v2 = TextBox2.Text.Trim();
            string v3 = TextBox3.Text.Trim();
            string v4 = TextBox4.Text.Trim();
            string v5 = TextBox5.Text.Trim();
            string v6 = TextBox6.Text.Trim();
            string v7 = TextBox7.Text.Trim();
            string v8 = TextBox8.Text.Trim();
            string v9 = TextBox9.Text.Trim();
            string v10 = TextBox10.Text.Trim();
            string v11 = TextBox11.Text.Trim();
            if (Button1.CommandName == "Insert")
            {
                DataSet isStudentRepeat =
                    OperaterBase.GetData("select * from studentInfo where studentNum='" + v3 + "'");
                if (isStudentRepeat.Tables[0].Rows.Count > 0)
                {
                    Label3.Text = "学号已经注册过,不能重复添加";
                    return;
                }

                DataSet isMobileRepeat = OperaterBase.GetData("select * from studentInfo where mobile='" + v5 + "'");
                if (isMobileRepeat.Tables[0].Rows.Count > 0)
                {
                    Label2.Text = "手机号码已经注册过,不能重复添加";
                    return;
                }

                string sql =
                    "insert into studentInfo (studentName,classID,studentNum,studentSex,mobile,password,birthday,province,city,district,address) values ('" +
                    v1 + "','" + v2 + "','" + v3 + "','" + v4 + "','" + v5 + "','" + v6 + "'," + v7 + ",'" + v8 +
                    "','" + v9 + "','" + v10 + "','" + v11 + "')";
                int flag = OperaterBase.CommandBySql(sql);
                if (flag > 0)
                {
                  
                    // 跳转页面
                    Response.Redirect("WebForm1.aspx");
                }
            }
            else if (Button1.CommandName == "Update")
            {
                string sql =
                    "update studentInfo set studentName='" + v1 + "',classID='" + v2 + "',studentNum='" + v3 +
                    "',studentSex='" + v4 + "',mobile='" + v5 + "',password='" + v6 + "',birthday='" + v7 +
                    "',province='" + v8 + "',city='" + v9 + "',district='" + v10 + "',address='" + v11 +
                    "' where studentID = " + ID + "";
                int flag = OperaterBase.CommandBySql(sql);
                if (flag > 0)
                {
                    // 跳转页面
                    Response.Redirect("WebForm1.aspx");
                }
            }
        }

        /// <summary>
        /// 获取班级信息
        /// </summary>
        private void getClassInfoData()
        {
            string sql = "select * from classInfo";
            DataSet ds = OperaterBase.GetData(sql);
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
        }
    }
}