namespace Minecraft离线UUID生成器
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NAME = new Label();
            Input = new TextBox();
            Output = new TextBox();
            UUID = new Label();
            Info = new Label();
            Start = new Button();
            Export = new Button();
            Server_List = new CheckedListBox();
            SuspendLayout();
            // 
            // NAME
            // 
            NAME.CausesValidation = false;
            NAME.Location = new Point(12, 9);
            NAME.Name = "NAME";
            NAME.Size = new Size(82, 17);
            NAME.TabIndex = 0;
            NAME.Text = "Player name:";
            NAME.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Input
            // 
            Input.Location = new Point(100, 6);
            Input.Name = "Input";
            Input.PlaceholderText = "请输入玩家名称";
            Input.Size = new Size(332, 23);
            Input.TabIndex = 1;
            // 
            // Output
            // 
            Output.Location = new Point(100, 35);
            Output.Name = "Output";
            Output.PlaceholderText = "玩家的uuid";
            Output.ReadOnly = true;
            Output.Size = new Size(332, 23);
            Output.TabIndex = 2;
            Output.TabStop = false;
            // 
            // UUID
            // 
            UUID.CausesValidation = false;
            UUID.Location = new Point(12, 38);
            UUID.Name = "UUID";
            UUID.Size = new Size(82, 17);
            UUID.TabIndex = 3;
            UUID.Text = "UUID:";
            UUID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Info
            // 
            Info.CausesValidation = false;
            Info.Location = new Point(12, 219);
            Info.Name = "Info";
            Info.Size = new Size(420, 17);
            Info.TabIndex = 4;
            Info.Text = "Info";
            Info.Click += Info_Click;
            // 
            // Start
            // 
            Start.Location = new Point(12, 64);
            Start.Name = "Start";
            Start.Size = new Size(210, 51);
            Start.TabIndex = 5;
            Start.Text = "生成";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // Export
            // 
            Export.Location = new Point(228, 64);
            Export.Name = "Export";
            Export.Size = new Size(204, 51);
            Export.TabIndex = 6;
            Export.Text = "导出";
            Export.UseVisualStyleBackColor = true;
            Export.Click += Export_Click;
            // 
            // Server_List
            // 
            Server_List.CheckOnClick = true;
            Server_List.FormattingEnabled = true;
            Server_List.Items.AddRange(new object[] { "Nothing" });
            Server_List.Location = new Point(12, 121);
            Server_List.MultiColumn = true;
            Server_List.Name = "Server_List";
            Server_List.Size = new Size(420, 94);
            Server_List.TabIndex = 7;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(444, 245);
            Controls.Add(Server_List);
            Controls.Add(Export);
            Controls.Add(Start);
            Controls.Add(Info);
            Controls.Add(UUID);
            Controls.Add(Output);
            Controls.Add(Input);
            Controls.Add(NAME);
            MaximizeBox = false;
            Name = "MainWindow";
            ShowIcon = false;
            Text = "Minecraft离线UUID生成器";
            Activated += MainWindow_Activated;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NAME;
        private TextBox Output;
        private Label UUID;
        private Label Info;
        private Button Start;
        private Button Export;
        public CheckedListBox Server_List;
        public TextBox Input;
    }
}
