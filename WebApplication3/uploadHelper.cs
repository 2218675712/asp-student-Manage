using System;
using System.Collections;
using System.IO;
using System.Web;

namespace WebApplication3
{
    public class uploadHelper
    {
        public static uploadModel imgUpload(string strName, bool hasFile)
        {
            uploadModel newUploadModel = new uploadModel();
            newUploadModel.result = false;

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
                string juedui = HttpContext.Current.Server.MapPath("~\\images\\");
                // 绝对路径+新文件名+后缀名=新的文件名称
                string newFileName = juedui + newName + kzm;
                // 验证FileUpload控件确实包含文件
                if (hasFile)
                {
                    String[] allowedExtensions = {".gif", ".png", ".bmp", ".jpg", ".txt"};
                    // 判断后缀名是否包含数组中
                    if (((IList) allowedExtensions).Contains(kzm))
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

                        newUploadModel.newFileName = newFileName;
                        newUploadModel.fileName = xiangdui + newName + kzm;
                        newUploadModel.message = "上传成功";
                        newUploadModel.result = true;
                    }
                    catch (Exception exception)
                    {
                        newUploadModel.message = "出现异常";
                        Console.WriteLine(exception);
                        throw;
                    }
                }
                else
                {
                    newUploadModel.message = "文件名不存在";
                }
            }

            return newUploadModel;
        }
    }
}