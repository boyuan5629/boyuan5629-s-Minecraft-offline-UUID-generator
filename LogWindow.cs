namespace Minecraft离线UUID生成器
{
    public partial class LogWindow : Form
    {
        private static readonly string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        private static readonly string fileName = $"Log_{timeStamp}.log";
        private static string content = new("");


        public LogWindow()
        {
            InitializeComponent();
        }


        private void Log_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string item in Loglist.Items)
                {
                    content += $"{item}\n";
                }
                if (!Directory.Exists(".\\Log"))
                    Directory.CreateDirectory(".\\Log");
                if (!File.Exists($".\\Log\\{fileName}")) 
                    File.Create($".\\Log\\{fileName}");
                File.WriteAllText($".\\Log\\{fileName}", content);
            }
            catch
            {

            }
        }
    }
}
