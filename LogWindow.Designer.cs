namespace Minecraft离线UUID生成器
{
    partial class LogWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Loglist = new ListBox();
            Log = new Button();
            SuspendLayout();
            // 
            // Loglist
            // 
            Loglist.FormattingEnabled = true;
            Loglist.ItemHeight = 17;
            Loglist.Items.AddRange(new object[] { "LogList" });
            Loglist.Location = new Point(12, 12);
            Loglist.Name = "Loglist";
            Loglist.Size = new Size(420, 174);
            Loglist.TabIndex = 0;
            // 
            // Log
            // 
            Log.Location = new Point(12, 192);
            Log.Name = "Log";
            Log.Size = new Size(420, 41);
            Log.TabIndex = 1;
            Log.Text = "导出日志";
            Log.UseVisualStyleBackColor = true;
            Log.Click += Log_Click;
            // 
            // LogWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 245);
            Controls.Add(Log);
            Controls.Add(Loglist);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LogWindow";
            Text = "LogWindow";
            ResumeLayout(false);
        }

        #endregion

        internal ListBox Loglist;
        private Button Log;
    }
}