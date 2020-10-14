using System;
using System.Data;
using System.IO;
using System.Linq;
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
                HiddenField1.Value = ID.ToString();
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
            // TextBox2.Text = ds.Tables[0].Rows[0]["classID"].ToString();
            DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["classID"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["studentNum"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["studentSex"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["password"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["birthday"].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0]["province"].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0]["city"].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0]["district"].ToString();
            TextBox11.Text = ds.Tables[0].Rows[0]["address"].ToString();
        }

        /// <summary>
        /// 提交用户
        /// </summary>
        private void AddUser()
        {
            int ID = Convert.ToInt32(Request["studentID"]);
            // .Trim()去掉空格
            string v1 = TextBox1.Text.Trim();
            string v2 = DropDownList1.SelectedValue;
            // string v2 = TextBox2.Text.Trim();
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
                //string.IsNullOrEmpty(v1)     // 为null或者空 条件为true
                if (string.IsNullOrEmpty(v1))
                {
                    Label1.Text = "用户名不能为空";
                    return;
                }


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
                // 校验用户规则
                if (!UpdateUserRules(ID, v1, v3, v5))
                {
                    return;
                }

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
        /// 更新用户校验规则
        /// </summary>
        /// <param name="ID">用户id</param>
        /// <param name="v3">用户学号</param>
        /// <param name="v5">用户手机号</param>
        /// <returns></returns>
        private bool UpdateUserRules(int ID, string v1, string v3, string v5)
        {
            // 不能为空
            //string.IsNullOrEmpty(v1)     // 为null或者空 条件为true
            if (string.IsNullOrEmpty(v1))
            {
                Label1.Text = "用户名不能为空";
                return false;
            }

            // 查用户是否存在
            DataSet studentListByID =
                OperaterBase.GetData("select * from studentInfo where studentID= '" + ID + "'");
            if (studentListByID.Tables[0].Rows.Count > 0)
            {
                //判断学号是否相等我不是我自己我要修改一个新的学号
                if (v3 != studentListByID.Tables[0].Rows[0]["studentNum"].ToString())
                {
                    //查询数据库中是否存在这个学号
                    DataSet studentNumList =
                        OperaterBase.GetData("select * from studentInfo where studentNum='" + v3 + "'");
                    if (studentNumList.Tables[0].Rows.Count > 0)
                    {
                        Label3.Text = "学号已经重复";
                    }
                    else
                    {
                        //查询数据库中是否存在这个手机
                        DataSet mobileList =
                            OperaterBase.GetData("select * from studentInfo where mobile='" + v5 + "'");
                        if (mobileList.Tables[0].Rows.Count > 0)
                        {
                            Label2.Text = "手机号已经重复";
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                Label1.Text = "用户信息已经被删除，请检查";
            }

            return false;
        }

        /// <summary>
        /// 获取班级信息
        /// </summary>
        private void getClassInfoData()
        {
            string sql = "select * from classInfo";
            DataSet ds = OperaterBase.GetData(sql);
            // 给上面表格绑定
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
            // 给下拉框绑定
            DropDownList1.DataSource = ds;
            // 绑定下拉框文字
            DropDownList1.DataTextField = "className";
            //绑定下拉框value值
            DropDownList1.DataValueField = "classID";
            DropDownList1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            avatatUpload();
        }

        public bool avatatUpload()
        {
            // 使用file-upload控件获取文件上传的文件名
            string strName = FileUpload1.PostedFile.FileName;
            // 如果文件名存在
            if (strName != "")
            {
                // 判断文件是否ok
                bool fileOk = false;
                // 获取.的索引号，在这里，代表图片和名字与后缀的间隔
                int i = strName.LastIndexOf(".");
                // 获取文件后缀名
                string kzm = strName.Substring(i);
                // 给文件生成一个新的后缀名
                string newName = Guid.NewGuid().ToString();
                // 设置文件相对网站根目录的保存路径，~号表示当前目录，在此目录下的images文件夹
                string xiangdui = @"~\images\";
                /*
                 * 设置文件保存的本地目录的绝对路径
                 * 对于路径中的字符“\”在字符串中必须以"\\"表示
                 * 因为"\"为特殊字符。或者可以使用上一行的给路径前面加上@
                 */
                string juedui = Server.MapPath("~\\images\\");
                // 绝对路径+新文件名+后缀名=新的文件名称
                string newFileName = juedui + newName + kzm;
                // 验证FileUpload控件确实包含文件
                if (FileUpload1.HasFile)
                {
                    String[] allowedExtensions = {".gif", ".png", ".bmp", ".jpg", ".txt"};
                    // 判断后缀名是否包含数组中
                    if (allowedExtensions.Contains(kzm))
                    {
                        fileOk = true;
                    }
                }

                if (fileOk)
                {
                    try
                    {
                        // 判断该路径是否存在
                        if (!Directory.Exists(juedui))
                        {
                            Directory.CreateDirectory(juedui);
                        }

                        // 将图片存储到服务器上
                        FileUpload1.PostedFile.SaveAs(newFileName);
                        Label4.Text = "上传成功";
                        Image1.ImageUrl= xiangdui+newName+kzm;

                        return true;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        throw;
                    }
                }
                else
                {
                    Label4.Text = "只能上传图片文件";
                }
            }

            return false;
        }
    }
}