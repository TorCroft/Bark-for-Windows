using KeyboardMonitor;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bark4Windows
{
    public partial class MainForm : Form
    {
        private String clipboardText;
        private String URLText;
        private KeyboardHook hook;
        private Dictionary<string, int> hotkeyDict;
        public MainForm()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            this.StartPosition = FormStartPosition.CenterScreen;

            hook = new KeyboardHook();
            hotkeyDict = new Dictionary<string, int>();
            hotkeyDict.Add("Ctrl + Alt + C", (int)Keys.Control + (int)Keys.Alt);
            hotkeyDict.Add("Shift + Alt + C", (int)Keys.Shift + (int)Keys.Alt);
            hotkeyDict.Add("Shift + C", (int)Keys.Shift);
            hotkeyDict.Add("Alt + C", (int)Keys.Alt);

            // Upgrade Config
            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
            }

            // Set HotkeyComboBox Items
            foreach (string key in hotkeyDict.Keys)
            {
                this.hotkeyComboBox.Items.Add(key);
            }

            // Set HotkeyComboBox Key Actions
            this.hotkeyComboBox.KeyDown += (s, e) => e.Handled = true;
            this.hotkeyComboBox.KeyPress += (s, e) => e.Handled = true;
            this.hotkeyComboBox.KeyUp += (s, e) => e.Handled = true;

            // Get Settings
            this.bootCheckBox.Checked = this.BootToolStripMenuItem.Checked = Properties.Settings.Default.boot;
            this.hotkeyComboBox.Text = Properties.Settings.Default.hotkey;
            this.hotkeyCheckBox.Checked = this.HotkeyToolStripMenuItem.Checked = Properties.Settings.Default.hotkeyCheck;
            this.serverURLText.Text = String.IsNullOrEmpty(Properties.Settings.Default.serverURL) ? "api.day.app" : Properties.Settings.Default.serverURL;
            this.titleTextBox.Text = Properties.Settings.Default.title;
            this.defaultTitleCheckBox.Checked = Properties.Settings.Default.titleCheck;
            this.contentTextBox.Text = Properties.Settings.Default.content;
            this.barkKeyText.Text = Properties.Settings.Default.barkKey;
            this.clipContentCheckBox.Checked = Properties.Settings.Default.contentCheck;
            this.autoCopyCheckBox.Checked = Properties.Settings.Default.autoCopyCheck;
            this.isArchiveCheckBox.Checked = Properties.Settings.Default.isArchiveCheck;
            this.defaultServerCheckBox.Checked = Properties.Settings.Default.defaultServerCheck;
            this.notifyCheckBox.Checked = this.NotifyToolStripMenuItem.Checked = Properties.Settings.Default.notifyCheck;
        }

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.AutoBarkNotifyIcon_ShowBalloonTip(2000, "Bark", "Bark is now running in background.", ToolTipIcon.Info);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() != "UserClosing")
            {
                this.ExitProgram();
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void AutoBarkNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.NotifyIconMenu.Show(Cursor.Position);
            }
        }

        private void AutoBarkNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowForm();
        }

        private void AutoBarkNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void ShowForm()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
            else
            {
                this.Activate();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExitProgram();
        }

        private void ExitProgram()
        {
            this.Dispose();
            this.Close();
        }

        private void SendBarkMsg()
        {
            String server_url;
            String bark_key = this.barkKeyText.Text;

            if (this.defaultServerCheckBox.Checked)
            {
                server_url = "https://api.day.app";
            }
            else
            {
                server_url = this.serverURLText.Text;
                if (String.IsNullOrWhiteSpace(server_url))
                {
                    MessageBox.Show("Server Cannot be Empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (server_url.EndsWith("/"))
                {
                    server_url = server_url.Remove(server_url.Length - 1);
                }

                // 检查server_url是否以"http://"或"https://"开头
                if (!server_url.StartsWith("http://") && !server_url.StartsWith("https://"))
                {
                    server_url = "https://" + server_url;
                }
            }

            clipboardText = Clipboard.GetText();

            Thread sendMsgThread = new Thread(new ParameterizedThreadStart(HttpSendBarkMsgThread));
            sendMsgThread.IsBackground = true;
            sendMsgThread.Start($"{server_url}/{bark_key}");
        }

        private void HttpSendBarkMsgThread(object obj)
        {
            try
            {
                // Set Post Params
                String body = this.clipContentCheckBox.Checked ? clipboardText : this.contentTextBox.Text;
                if (String.IsNullOrEmpty(body))
                {
                    MessageBox.Show("Empty Content is NOT Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                String title = this.defaultTitleCheckBox.Checked ? "Bark for Windows" : this.titleTextBox.Text;
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("title={0}", title);
                builder.AppendFormat("&body={0}", body);
                builder.AppendFormat("&copy={0}", body);
                builder.AppendFormat("&group={0}", "Bark for Windows");
                
                // autoCopy only features in iOS 14.4 and below.
                builder.AppendFormat("&autoCopy={0}", this.autoCopyCheckBox.Checked ? "1" : "0");

                if (isValidUrl(body))
                {
                    builder.AppendFormat("&url={0}", URLText);
                    builder.AppendFormat("&isArchive=1");
                }
                else
                {
                    builder.AppendFormat("&isArchive={0}", this.isArchiveCheckBox.Checked ? "1" : "0");
                }

                byte[] data = Encoding.UTF8.GetBytes(builder.ToString());

                HttpWebRequest request;
                request = (HttpWebRequest)WebRequest.Create(obj.ToString());
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                using (System.IO.Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }

                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string responseText = myreader.ReadToEnd();
                JObject barkResp = JObject.Parse(responseText);

                if (Convert.ToInt16(barkResp["code"]) == 200)
                {
                    if (this.notifyCheckBox.Checked)
                    {
                        this.AutoBarkNotifyIcon_ShowBalloonTip(1500, "Bark", "Message Delivered", ToolTipIcon.Info);
                    }
                }
                else
                {
                    this.AutoBarkNotifyIcon_ShowBalloonTip(3000, "Bark", "Push failed：\n" + barkResp["message"], ToolTipIcon.Error);
                }
            }
            catch (Exception e)
            {
                this.AutoBarkNotifyIcon_ShowBalloonTip(3000, "Push failed：", "" + e, ToolTipIcon.Error);
            }
        }

        private bool keyDownHandled = false;// 记录按键是否处理过，避免长按重复触发

        public bool isValidUrl(string url)
        {
            url = url.Trim();

            if (url.IndexOf('.') == -1 || url.Contains(' '))
                return false;

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "https://" + url;

            int protocolEndIndex = url.IndexOf("://") + 3;
            int pathStartIndex = url.IndexOf('/', protocolEndIndex);
            if (pathStartIndex == -1)
                pathStartIndex = url.Length;

            string host = url.Substring(protocolEndIndex, pathStartIndex - protocolEndIndex);

            if (Uri.CheckHostName(host) == UriHostNameType.Unknown)
                return false;

            URLText = url;
            return true;
        }

        private void hook_Start()
        {
            hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);
            hook.KeyUpEvent += new KeyEventHandler(hook_KeyUp);
            hook.Start();
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.C && (int)Control.ModifierKeys == hotkeyDict[this.hotkeyComboBox.Text] && keyDownHandled == false)
            {
                keyDownHandled = true;
                this.SendBarkMsg();
            }
        }

        private void hook_KeyUp(object sender, KeyEventArgs e)
        {
            keyDownHandled = false;
        }

        private void hotkeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool hotkeyChecked = this.hotkeyCheckBox.Checked;

            try
            {
                // Change Hook Status
                if (this.hotkeyCheckBox.Checked)
                {
                    this.hook_Start();
                }
                else
                {
                    hook.Stop();
                }
            }
            catch (Exception)
            {
                this.AutoBarkNotifyIcon_ShowBalloonTip(3000, "Bark", "Failed to enable hotkey", ToolTipIcon.Warning);
                this.hotkeyCheckBox.Checked = !hotkeyChecked;
                return;
            }

            if (hotkeyChecked == Properties.Settings.Default.hotkeyCheck) return;

            this.HotkeyToolStripMenuItem.Checked = hotkeyChecked;

            // Save HotkeyChecked Config
            Properties.Settings.Default.hotkeyCheck = hotkeyChecked;
            Properties.Settings.Default.Save();
        }

        private void HotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hotkeyCheckBox.Checked = !this.hotkeyCheckBox.Checked;
        }

        public void AutoBarkNotifyIcon_ShowBalloonTip(int tipDisplayTime, String tipTitle, String tipText, ToolTipIcon tipIcon)
        {
            this.BarkNotifyIcon.ShowBalloonTip(tipDisplayTime, tipTitle, tipText, tipIcon);
        }

        private void clipContentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool contentChecked = this.clipContentCheckBox.Checked;

            // Disable ContentText
            this.contentTextBox.Enabled = !contentChecked;

            if (contentChecked == Properties.Settings.Default.contentCheck) return;

            // Save ContentChecked Config
            Properties.Settings.Default.contentCheck = contentChecked;
            Properties.Settings.Default.Save();
        }

        private void defaultTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool defaultTitleChecked = this.defaultTitleCheckBox.Checked;

            // Disable TitleText
            this.titleTextBox.Enabled = !defaultTitleChecked;

            if (defaultTitleChecked == Properties.Settings.Default.titleCheck) return;

            // Save TitleChecked Config
            Properties.Settings.Default.titleCheck = defaultTitleChecked;
            Properties.Settings.Default.Save();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            this.SendBarkMsg();
        }

        private void bootCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool bootChecked = this.bootCheckBox.Checked;

            if (bootChecked == Properties.Settings.Default.boot) return;

            if (bootChecked)
            {
                RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.SetValue("Bark", Application.ExecutablePath);
                R_run.Close();
                R_local.Close();
            }
            else
            {
                RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.DeleteValue("Bark", false);
                R_run.Close();
                R_local.Close();
            }

            this.BootToolStripMenuItem.Checked = bootChecked;

            // Save BootChecked Config
            Properties.Settings.Default.boot = bootChecked;
            Properties.Settings.Default.Save();
        }

        private void BootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.bootCheckBox.Checked = !this.bootCheckBox.Checked;
        }

        private void hotkeyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String hotkeyText = this.hotkeyComboBox.Text;

            if (hotkeyText == Properties.Settings.Default.hotkey) return;

            Properties.Settings.Default.hotkey = hotkeyText;
            Properties.Settings.Default.Save();
        }

        private void serverURLText_TextChanged(object sender, EventArgs e)
        {
            String urlText = this.serverURLText.Text;

            if (urlText == Properties.Settings.Default.serverURL) return;

            Properties.Settings.Default.serverURL = urlText;
            Properties.Settings.Default.Save();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            String titleText = this.titleTextBox.Text;

            if (titleText == Properties.Settings.Default.title) return;

            Properties.Settings.Default.title = titleText;
            Properties.Settings.Default.Save();
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e)
        {
            String contentText = this.contentTextBox.Text;

            if (contentText == Properties.Settings.Default.content) return;

            Properties.Settings.Default.content = contentText;
            Properties.Settings.Default.Save();
        }

        private void autoCopyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool autoCopyChecked = this.autoCopyCheckBox.Checked;

            if (autoCopyChecked == Properties.Settings.Default.autoCopyCheck) return;

            Properties.Settings.Default.autoCopyCheck = autoCopyChecked;
            Properties.Settings.Default.Save();
        }

        private void notifyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool notifyChecked = this.notifyCheckBox.Checked;

            if (notifyChecked == Properties.Settings.Default.notifyCheck) return;

            this.NotifyToolStripMenuItem.Checked = notifyChecked;

            Properties.Settings.Default.notifyCheck = notifyChecked;
            Properties.Settings.Default.Save();
        }

        private void NotifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyCheckBox.Checked = !this.notifyCheckBox.Checked;
        }

        private void isArchiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isArchiveChecked = this.isArchiveCheckBox.Checked;
            if (isArchiveChecked == Properties.Settings.Default.isArchiveCheck) return;
            Properties.Settings.Default.isArchiveCheck = isArchiveChecked;
            Properties.Settings.Default.Save();
        }

        private void showURLCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.showhiddenCheckBox.Checked)
            {
                this.serverURLText.UseSystemPasswordChar = false;
                this.barkKeyText.UseSystemPasswordChar = false;
            }
            else
            {
                this.serverURLText.UseSystemPasswordChar = true;
                this.barkKeyText.UseSystemPasswordChar = true;
            }
        }

        private void defaultServerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool defaultServerCheckd = this.defaultServerCheckBox.Checked;
            if (defaultServerCheckd == Properties.Settings.Default.defaultServerCheck) return;
            Properties.Settings.Default.defaultServerCheck = defaultServerCheckd;
            Properties.Settings.Default.Save();
        }

        private void barkKeyText_TextChanged(object sender, EventArgs e)
        {
            String barkKeyText = this.barkKeyText.Text;

            if (barkKeyText == Properties.Settings.Default.barkKey) return;

            Properties.Settings.Default.barkKey = barkKeyText;
            Properties.Settings.Default.Save();
        }

        private void lockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lockCheckBox.Checked)
            {
                this.serverURLText.Enabled = false;
                this.barkKeyText.Enabled = false;
            }
            else
            {
                this.serverURLText.Enabled = true;
                this.barkKeyText.Enabled = true;
            }
        }
    }
}
