using System.Text.RegularExpressions;

namespace Minecraft离线UUID生成器
{
    public partial class MainWindow : Form
    {
        Error_list _List = new();
        bool haveLog=false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Info.Text = "[None]Nothing";
            haveLog = false;
            if (Regex.IsMatch(Input.Text, @"^[A-Za-z_][A-Za-z0-9_]+$"))
            {
                Output.Text = GenerateUUID.GenerateOfflineUUID(Input.Text);
            }
            else
            {
                Info.Text = "[Error]请确认玩家名称格式正确";
                return;
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            Info.Text = "[None]Nothing";
            haveLog = false;
            try
            {
                if (Server_List.CheckedItems.Count == 0) { Info.Text = Error_list.Errors[14]; return; }
                foreach (string item in Server_List.CheckedItems)
                {
                    Write_to_whitelist.AddToWhitelist($@"..\{item}\whitelist.json",Input.Text,Output.Text);
                }
            }
            catch(Error_list ex)
            {
                if (ex.Length == 0) return;
                else if (ex.Length == 1) Info.Text = ex.GetError();
                else if (ex.Length > 1)
                {
                    _List = ex;
                    haveLog = true;
                    Info.Text = Error_list.Errors[90];
                }
            }
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            Info.Text = "[None]Nothing";
            haveLog = false;
            Server_List.Items.Clear();
            try
            {
                FandServerFolder.FindServerFoldersWithWhitelist(Program.SeekFolder);
            }
            catch (Error_list ex)
            {
                if (ex.Length == 0) return;
                else if (ex.Length == 1) Info.Text = ex.GetError();
                else if (ex.Length > 1)
                {
                    _List = ex;
                    haveLog = true;
                    Info.Text = Error_list.Errors[90];
                }
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            if(!haveLog) return; 
            LogWindow log = new();
            log.Loglist.Items.Clear();
            foreach (string item in _List.AllErrors)
                log.Loglist.Items.Add(item);
            log.ShowDialog();
        }
    }
}
