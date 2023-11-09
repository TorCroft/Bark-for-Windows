namespace Bark4Windows
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.hotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.serverURLLabel = new System.Windows.Forms.Label();
            this.BarkNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bootCheckBox = new System.Windows.Forms.CheckBox();
            this.autoCopyCheckBox = new System.Windows.Forms.CheckBox();
            this.hotkeyLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.clipContentCheckBox = new System.Windows.Forms.CheckBox();
            this.defaultTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.hotkeyComboBox = new System.Windows.Forms.ComboBox();
            this.notifyCheckBox = new System.Windows.Forms.CheckBox();
            this.isArchiveCheckBox = new System.Windows.Forms.CheckBox();
            this.showhiddenCheckBox = new System.Windows.Forms.CheckBox();
            this.barkKeyLabel = new System.Windows.Forms.Label();
            this.barkKeyText = new System.Windows.Forms.TextBox();
            this.defaultServerCheckBox = new System.Windows.Forms.CheckBox();
            this.lockCheckBox = new System.Windows.Forms.CheckBox();
            this.serverURLText = new CueTextBox();
            this.NotifyIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotkeyCheckBox
            // 
            this.hotkeyCheckBox.AutoSize = true;
            this.hotkeyCheckBox.Location = new System.Drawing.Point(368, 30);
            this.hotkeyCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.hotkeyCheckBox.Name = "hotkeyCheckBox";
            this.hotkeyCheckBox.Size = new System.Drawing.Size(76, 20);
            this.hotkeyCheckBox.TabIndex = 0;
            this.hotkeyCheckBox.Text = "Hot Key";
            this.hotkeyCheckBox.UseVisualStyleBackColor = true;
            this.hotkeyCheckBox.CheckedChanged += new System.EventHandler(this.hotkeyCheckBox_CheckedChanged);
            // 
            // serverURLLabel
            // 
            this.serverURLLabel.AutoSize = true;
            this.serverURLLabel.Location = new System.Drawing.Point(31, 89);
            this.serverURLLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serverURLLabel.Name = "serverURLLabel";
            this.serverURLLabel.Size = new System.Drawing.Size(47, 16);
            this.serverURLLabel.TabIndex = 1;
            this.serverURLLabel.Text = "Server";
            // 
            // BarkNotifyIcon
            // 
            this.BarkNotifyIcon.ContextMenuStrip = this.NotifyIconMenu;
            this.BarkNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("BarkNotifyIcon.Icon")));
            this.BarkNotifyIcon.Text = "Bark";
            this.BarkNotifyIcon.Visible = true;
            this.BarkNotifyIcon.BalloonTipClicked += new System.EventHandler(this.AutoBarkNotifyIcon_BalloonTipClicked);
            this.BarkNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AutoBarkNotifyIcon_MouseClick);
            this.BarkNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AutoBarkNotifyIcon_MouseDoubleClick);
            // 
            // NotifyIconMenu
            // 
            this.NotifyIconMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.NotifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowToolStripMenuItem,
            this.HotkeyToolStripMenuItem,
            this.BootToolStripMenuItem,
            this.NotifyToolStripMenuItem,
            this.SendToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.NotifyIconMenu.Name = "NotifyIconMenu";
            this.NotifyIconMenu.Size = new System.Drawing.Size(216, 148);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.ShowToolStripMenuItem.Text = "Show";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.AutoBarkNotifyIcon_BalloonTipClicked);
            // 
            // HotkeyToolStripMenuItem
            // 
            this.HotkeyToolStripMenuItem.Name = "HotkeyToolStripMenuItem";
            this.HotkeyToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.HotkeyToolStripMenuItem.Text = "Enable Hot Key";
            this.HotkeyToolStripMenuItem.Click += new System.EventHandler(this.HotkeyToolStripMenuItem_Click);
            // 
            // BootToolStripMenuItem
            // 
            this.BootToolStripMenuItem.Name = "BootToolStripMenuItem";
            this.BootToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.BootToolStripMenuItem.Text = "Run at Startup";
            this.BootToolStripMenuItem.Click += new System.EventHandler(this.BootToolStripMenuItem_Click);
            // 
            // NotifyToolStripMenuItem
            // 
            this.NotifyToolStripMenuItem.Name = "NotifyToolStripMenuItem";
            this.NotifyToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.NotifyToolStripMenuItem.Text = "Notify upon Delivery";
            this.NotifyToolStripMenuItem.Click += new System.EventHandler(this.NotifyToolStripMenuItem_Click);
            // 
            // SendToolStripMenuItem
            // 
            this.SendToolStripMenuItem.Name = "SendToolStripMenuItem";
            this.SendToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.SendToolStripMenuItem.Text = "Push";
            this.SendToolStripMenuItem.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(215, 24);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // bootCheckBox
            // 
            this.bootCheckBox.AutoSize = true;
            this.bootCheckBox.Location = new System.Drawing.Point(514, 30);
            this.bootCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.bootCheckBox.Name = "bootCheckBox";
            this.bootCheckBox.Size = new System.Drawing.Size(112, 20);
            this.bootCheckBox.TabIndex = 3;
            this.bootCheckBox.Text = "Run at Startup";
            this.bootCheckBox.UseVisualStyleBackColor = true;
            this.bootCheckBox.CheckedChanged += new System.EventHandler(this.bootCheckBox_CheckedChanged);
            // 
            // autoCopyCheckBox
            // 
            this.autoCopyCheckBox.AutoSize = true;
            this.autoCopyCheckBox.Location = new System.Drawing.Point(514, 132);
            this.autoCopyCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.autoCopyCheckBox.Name = "autoCopyCheckBox";
            this.autoCopyCheckBox.Size = new System.Drawing.Size(91, 20);
            this.autoCopyCheckBox.TabIndex = 4;
            this.autoCopyCheckBox.Text = "Auto Copy";
            this.autoCopyCheckBox.UseVisualStyleBackColor = true;
            this.autoCopyCheckBox.CheckedChanged += new System.EventHandler(this.autoCopyCheckBox_CheckedChanged);
            // 
            // hotkeyLabel
            // 
            this.hotkeyLabel.AutoSize = true;
            this.hotkeyLabel.Location = new System.Drawing.Point(31, 33);
            this.hotkeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hotkeyLabel.Name = "hotkeyLabel";
            this.hotkeyLabel.Size = new System.Drawing.Size(54, 16);
            this.hotkeyLabel.TabIndex = 5;
            this.hotkeyLabel.Text = "Hot Key";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(31, 173);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(33, 16);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(109, 169);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(228, 22);
            this.titleTextBox.TabIndex = 8;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(109, 209);
            this.contentTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(228, 22);
            this.contentTextBox.TabIndex = 9;
            this.contentTextBox.TextChanged += new System.EventHandler(this.contentTextBox_TextChanged);
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(31, 214);
            this.contentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(52, 16);
            this.contentLabel.TabIndex = 10;
            this.contentLabel.Text = "Content";
            // 
            // clipContentCheckBox
            // 
            this.clipContentCheckBox.AutoSize = true;
            this.clipContentCheckBox.Location = new System.Drawing.Point(368, 211);
            this.clipContentCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.clipContentCheckBox.Name = "clipContentCheckBox";
            this.clipContentCheckBox.Size = new System.Drawing.Size(123, 20);
            this.clipContentCheckBox.TabIndex = 11;
            this.clipContentCheckBox.Text = "Send Clipboard";
            this.clipContentCheckBox.UseVisualStyleBackColor = true;
            this.clipContentCheckBox.CheckedChanged += new System.EventHandler(this.clipContentCheckBox_CheckedChanged);
            // 
            // defaultTitleCheckBox
            // 
            this.defaultTitleCheckBox.AutoSize = true;
            this.defaultTitleCheckBox.Location = new System.Drawing.Point(368, 173);
            this.defaultTitleCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.defaultTitleCheckBox.Name = "defaultTitleCheckBox";
            this.defaultTitleCheckBox.Size = new System.Drawing.Size(100, 20);
            this.defaultTitleCheckBox.TabIndex = 12;
            this.defaultTitleCheckBox.Text = "Default Title";
            this.defaultTitleCheckBox.UseVisualStyleBackColor = true;
            this.defaultTitleCheckBox.CheckedChanged += new System.EventHandler(this.defaultTitleCheckBox_CheckedChanged);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(291, 249);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(87, 31);
            this.sendButton.TabIndex = 13;
            this.sendButton.Text = "Push";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // hotkeyComboBox
            // 
            this.hotkeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hotkeyComboBox.FormattingEnabled = true;
            this.hotkeyComboBox.Location = new System.Drawing.Point(109, 28);
            this.hotkeyComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.hotkeyComboBox.Name = "hotkeyComboBox";
            this.hotkeyComboBox.Size = new System.Drawing.Size(228, 24);
            this.hotkeyComboBox.TabIndex = 14;
            this.hotkeyComboBox.SelectedIndexChanged += new System.EventHandler(this.hotkeyComboBox_SelectedIndexChanged);
            // 
            // notifyCheckBox
            // 
            this.notifyCheckBox.AutoSize = true;
            this.notifyCheckBox.Location = new System.Drawing.Point(514, 63);
            this.notifyCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.notifyCheckBox.Name = "notifyCheckBox";
            this.notifyCheckBox.Size = new System.Drawing.Size(149, 20);
            this.notifyCheckBox.TabIndex = 15;
            this.notifyCheckBox.Text = "Notify upon Delivery";
            this.notifyCheckBox.UseVisualStyleBackColor = true;
            this.notifyCheckBox.CheckedChanged += new System.EventHandler(this.notifyCheckBox_CheckedChanged);
            // 
            // isArchiveCheckBox
            // 
            this.isArchiveCheckBox.AutoSize = true;
            this.isArchiveCheckBox.Location = new System.Drawing.Point(514, 94);
            this.isArchiveCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.isArchiveCheckBox.Name = "isArchiveCheckBox";
            this.isArchiveCheckBox.Size = new System.Drawing.Size(74, 20);
            this.isArchiveCheckBox.TabIndex = 17;
            this.isArchiveCheckBox.Text = "Archive";
            this.isArchiveCheckBox.UseVisualStyleBackColor = true;
            this.isArchiveCheckBox.CheckedChanged += new System.EventHandler(this.isArchiveCheckBox_CheckedChanged);
            // 
            // showhiddenCheckBox
            // 
            this.showhiddenCheckBox.AutoSize = true;
            this.showhiddenCheckBox.Location = new System.Drawing.Point(368, 131);
            this.showhiddenCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.showhiddenCheckBox.Name = "showhiddenCheckBox";
            this.showhiddenCheckBox.Size = new System.Drawing.Size(109, 20);
            this.showhiddenCheckBox.TabIndex = 18;
            this.showhiddenCheckBox.Text = "Show Hidden";
            this.showhiddenCheckBox.UseVisualStyleBackColor = true;
            this.showhiddenCheckBox.CheckedChanged += new System.EventHandler(this.showURLCheckBox_CheckedChanged);
            // 
            // barkKeyLabel
            // 
            this.barkKeyLabel.AutoSize = true;
            this.barkKeyLabel.Location = new System.Drawing.Point(31, 132);
            this.barkKeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.barkKeyLabel.Name = "barkKeyLabel";
            this.barkKeyLabel.Size = new System.Drawing.Size(61, 16);
            this.barkKeyLabel.TabIndex = 19;
            this.barkKeyLabel.Text = "Bark Key";
            // 
            // barkKeyText
            // 
            this.barkKeyText.Enabled = false;
            this.barkKeyText.Location = new System.Drawing.Point(109, 129);
            this.barkKeyText.Margin = new System.Windows.Forms.Padding(4);
            this.barkKeyText.Name = "barkKeyText";
            this.barkKeyText.Size = new System.Drawing.Size(228, 22);
            this.barkKeyText.TabIndex = 20;
            this.barkKeyText.UseSystemPasswordChar = true;
            this.barkKeyText.TextChanged += new System.EventHandler(this.barkKeyText_TextChanged);
            // 
            // defaultServerCheckBox
            // 
            this.defaultServerCheckBox.AutoSize = true;
            this.defaultServerCheckBox.Checked = true;
            this.defaultServerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultServerCheckBox.Location = new System.Drawing.Point(368, 94);
            this.defaultServerCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.defaultServerCheckBox.Name = "defaultServerCheckBox";
            this.defaultServerCheckBox.Size = new System.Drawing.Size(114, 20);
            this.defaultServerCheckBox.TabIndex = 21;
            this.defaultServerCheckBox.Text = "Default Server";
            this.defaultServerCheckBox.UseVisualStyleBackColor = true;
            this.defaultServerCheckBox.CheckedChanged += new System.EventHandler(this.defaultServerCheckBox_CheckedChanged);
            // 
            // lockCheckBox
            // 
            this.lockCheckBox.AutoSize = true;
            this.lockCheckBox.Checked = true;
            this.lockCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockCheckBox.Location = new System.Drawing.Point(368, 58);
            this.lockCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.lockCheckBox.Name = "lockCheckBox";
            this.lockCheckBox.Size = new System.Drawing.Size(58, 20);
            this.lockCheckBox.TabIndex = 22;
            this.lockCheckBox.Text = "Lock";
            this.lockCheckBox.UseVisualStyleBackColor = true;
            this.lockCheckBox.CheckedChanged += new System.EventHandler(this.lockCheckBox_CheckedChanged);
            // 
            // serverURLText
            // 
            this.serverURLText.Cue = "api.day.app";
            this.serverURLText.Enabled = false;
            this.serverURLText.Location = new System.Drawing.Point(109, 86);
            this.serverURLText.Margin = new System.Windows.Forms.Padding(4);
            this.serverURLText.Name = "serverURLText";
            this.serverURLText.Size = new System.Drawing.Size(228, 22);
            this.serverURLText.TabIndex = 16;
            this.serverURLText.UseSystemPasswordChar = true;
            this.serverURLText.TextChanged += new System.EventHandler(this.serverURLText_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 297);
            this.Controls.Add(this.lockCheckBox);
            this.Controls.Add(this.defaultServerCheckBox);
            this.Controls.Add(this.barkKeyText);
            this.Controls.Add(this.barkKeyLabel);
            this.Controls.Add(this.showhiddenCheckBox);
            this.Controls.Add(this.isArchiveCheckBox);
            this.Controls.Add(this.serverURLText);
            this.Controls.Add(this.notifyCheckBox);
            this.Controls.Add(this.hotkeyComboBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.defaultTitleCheckBox);
            this.Controls.Add(this.clipContentCheckBox);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.hotkeyLabel);
            this.Controls.Add(this.autoCopyCheckBox);
            this.Controls.Add(this.bootCheckBox);
            this.Controls.Add(this.serverURLLabel);
            this.Controls.Add(this.hotkeyCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Bark";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.NotifyIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox hotkeyCheckBox;
        private System.Windows.Forms.Label serverURLLabel;
        private System.Windows.Forms.NotifyIcon BarkNotifyIcon;
        private System.Windows.Forms.CheckBox bootCheckBox;
        private System.Windows.Forms.CheckBox autoCopyCheckBox;
        private System.Windows.Forms.Label hotkeyLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.CheckBox clipContentCheckBox;
        private System.Windows.Forms.CheckBox defaultTitleCheckBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox hotkeyComboBox;
        private System.Windows.Forms.CheckBox notifyCheckBox;
        private System.Windows.Forms.ContextMenuStrip NotifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem HotkeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NotifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private CueTextBox serverURLText;
        private System.Windows.Forms.CheckBox isArchiveCheckBox;
        private System.Windows.Forms.CheckBox showhiddenCheckBox;
        private System.Windows.Forms.Label barkKeyLabel;
        private System.Windows.Forms.TextBox barkKeyText;
        private System.Windows.Forms.CheckBox defaultServerCheckBox;
        private System.Windows.Forms.CheckBox lockCheckBox;
    }
}

