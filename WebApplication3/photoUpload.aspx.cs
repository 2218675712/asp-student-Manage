using System;
using System.IO;
using System.Linq;

namespace WebApplication3
{
    public partial class photoUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
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

                        Label1.Text = newFileName;
                        Label2.Text = "<b>原文件路径:</b>" + FileUpload1.PostedFile.FileName + "<br/>" + "<b>文件大小:</b>" +
                                      FileUpload1.PostedFile.ContentLength + "字节<br/>" + "文件类型:" +
                                      FileUpload1.PostedFile.ContentType + "<br/>";
                        Label3.Text = xiangdui + newName + kzm;
                        Label4.Text = "文件上传成功";
                        // 将图片存储到服务器上
                        FileUpload1.PostedFile.SaveAs(newFileName);
                        Image1.ImageUrl = xiangdui+newName+kzm;
                    }
                    catch (Exception exception)
                    {
                        Label4.Text = "文件上传失败";
                        Console.WriteLine(exception);
                        throw;
                    }
                }
                else
                {
                    Label4.Text = "只能上传图片文件";
                }
            }
        }
    }
}