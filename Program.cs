using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Minecraft离线UUID生成器
{
    internal static class Program
    {
        public static MainWindow? mainwin;
        public static string SeekFolder = @"..\"; // 默认搜索路径
        public static bool NoGUI = false;
        public static string PlayerName = "";
        [DllImport("kernel32.dll")] private static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        ///  The main entry point for the application.s
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (IsHelpRequested(args))
            {
                AttachConsole(ATTACH_PARENT_PROCESS);
                PrintHelp();
                return;
            }

            ParseCommandLineArgs(args);

            if (NoGUI && string.IsNullOrEmpty(PlayerName))
            {
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.WriteLine("\n错误：-nogui 模式下必须提供玩家名！");
                Console.WriteLine("用法示例：Minecraft离线UUID生成器.exe -nogui -playername \"Steve\"");
                return;
            }

            // 非 GUI 模式直接处理并退出
            if (NoGUI)
            {
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.WriteLine($"\n玩家名: {PlayerName}");
                if (Regex.IsMatch(PlayerName, @"^[A-Za-z_][A-Za-z0-9_]+$"))
                    Console.WriteLine($"该玩家的uuid为：{GenerateUUID.GenerateOfflineUUID(PlayerName)}");
                else
                    Console.WriteLine("[Error]请确认玩家名称格式正确");
                return;
            }

            ApplicationConfiguration.Initialize();
            mainwin = new MainWindow();
            mainwin.Input.Text = PlayerName;
            Application.Run(mainwin);
        }

        private static bool IsHelpRequested(string[] args)
        {
            var helpFlags = new[] { "-help", "/?", "/help" };
            return args.Any(arg => helpFlags.Contains(arg.ToLower()));
        }

        private static void PrintHelp()
        {
            Console.WriteLine("\nMinecraft离线UUID生成器 使用说明");
            Console.WriteLine("用法:");
            Console.WriteLine("  Minecraft离线UUID生成器.exe [选项]");
            Console.WriteLine("  不填写[选项]则使用默认(GUI)方式启动");
            Console.WriteLine("  (boyuan5629提供了功能更完整的图形化界面,应该不会有人会用nogui吧)");//调侃
            Console.WriteLine();
            Console.WriteLine("选项:");
            Console.WriteLine("  -seek或-seekfolder <路径>  设置搜索路径（默认：上级目录）");
            Console.WriteLine("  -nogui              启用命令行模式");
            Console.WriteLine("  -name或-playername <名字>  在-nogui模式下必须提供玩家名");
            Console.WriteLine("  -help, /?, /help   显示帮助信息");
            Console.WriteLine();
            Console.WriteLine("示例:");
            Console.WriteLine("  Minecraft离线UUID生成器.exe");
            Console.WriteLine("  Minecraft离线UUID生成器.exe -seekfolder \"C:\\Data\"");
            Console.WriteLine("  Minecraft离线UUID生成器.exe -nogui -playername \"Steve\"");
        }

        private static void ParseCommandLineArgs(string[] args)
        {
            if(args.Length == 0) return;
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "-seek":
                    case "-seekfolder":
                        if (i + 1 < args.Length)
                        {
                            SeekFolder = args[i + 1];
                            i++; // 跳过下一个参数（路径值）
                        }
                        if (!Directory.Exists(SeekFolder))
                        {
                            if (NoGUI)
                            {
                                AttachConsole(ATTACH_PARENT_PROCESS);
                                Console.WriteLine("[警告] 路径不存在，将使用默认值");
                            }
                            else MessageBox.Show("[警告] 路径不存在，将使用默认值");
                            SeekFolder = @"..\";
                        }
                        break;
                    case "-nogui":
                        NoGUI = true;
                        break;
                    case "-name":
                    case "-playername":
                        if (i + 1 < args.Length)
                        {
                            PlayerName = args[i + 1];
                            i++;
                        }
                        break;
                    default:
                        AttachConsole(ATTACH_PARENT_PROCESS);
                        Console.WriteLine("""[error]未知参数，请使用"-help"或"/?"获取帮助""");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}