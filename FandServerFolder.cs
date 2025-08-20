namespace Minecraft离线UUID生成器
{
    public class FandServerFolder
    {
        private static Error_list errorList = new();

        /// <summary>
        /// 查找包含whitelist.json的服务器目录（支持相对路径）
        /// </summary>
        /// <param name="targetDirectory">目标目录（绝对或相对路径）</param>
        /// <param name="recursive">是否递归搜索子目录</param>
        public static void FindServerFoldersWithWhitelist(string targetDirectory,bool recursive = false)
        {
            errorList = new Error_list();
            
            try
            {
                // 转换为绝对路径
                string rootDirectory = Path.GetFullPath(targetDirectory);

                // 检查根目录是否为空
                if (string.IsNullOrWhiteSpace(rootDirectory))
                {
                    errorList.AddError(40); // 服务器目录路径不能为空
                    return;
                }

                // 检查根目录是否存在
                if (!Directory.Exists(rootDirectory))
                {
                    errorList.AddError(41); // 服务器根目录不存在
                    return;
                }

                // 获取目录列表
                var searchOption = recursive ? 
                    SearchOption.AllDirectories : 
                    SearchOption.TopDirectoryOnly;

                string[] subDirectories;
                try
                {
                    subDirectories = Directory.GetDirectories(
                        rootDirectory, 
                        "*", 
                        searchOption);
                }
                catch (UnauthorizedAccessException)
                {
                    errorList.AddError(42); // 无权访问
                    return;
                }
                catch (Exception)
                {
                    errorList.AddError(43); // 目录遍历错误
                    return;
                }
                
                // 搜索whitelist.json
                foreach (string dir in subDirectories)
                {
                    try
                    {
                        string whiteListPath = Path.Combine(dir, "whitelist.json");
                        if (File.Exists(whiteListPath))
                        {
                            // 添加相对路径显示（相对于最初传入的路径）
                            string displayPath = Path.GetRelativePath(rootDirectory, dir);
                            AddToServerList(displayPath);
                        }
                    }
                    catch (Exception)
                    {
                        errorList.AddError(1); // 系统IO操作失败
                        continue;
                    }
                }
            }
            catch (Exception)
            {
                errorList.AddError(0); // 未知错误
            }

            if (errorList.Length > 0)
            {
                throw errorList;
            }
        }

        private static void AddToServerList(string displayPath)
        {
            if (Program.mainwin.Server_List.InvokeRequired)
            {
                Program.mainwin.Server_List.Invoke(new Action(() => 
                {
                    if (!Program.mainwin.Server_List.Items.Contains(displayPath))
                        Program.mainwin.Server_List.Items.Add(displayPath);
                }));
            }
            else
            {
                if (!Program.mainwin.Server_List.Items.Contains(displayPath))
                    Program.mainwin.Server_List.Items.Add(displayPath);
            }
        }
    }
}