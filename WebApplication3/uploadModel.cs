namespace WebApplication3
{
    public class uploadModel
    {
        public uploadModel()
        {
            
        }
        // 绝对路径地址
        public string newFileName { get; set; }

        // 相对路径地址
        public string fileName { get; set; }

        // 错误信息
        public string message { get; set; }

        // 状态        成功失败
        public bool result { get; set; }
    }
}