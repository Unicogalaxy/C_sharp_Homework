using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WebContentScraper
{
    public partial class Form1 : Form
    {
        private const string URL_PLACEHOLDER = "请输入要抓取的网页URL";

        public Form1()
        {
            InitializeComponent();
            UpdateStatus("就绪");
            InitializeUrlTextBox();
        }

        private void InitializeUrlTextBox()
        {
            urlTextBox.Text = URL_PLACEHOLDER;
            urlTextBox.ForeColor = System.Drawing.Color.Gray;

            urlTextBox.Enter += (s, e) =>
            {
                if (urlTextBox.Text == URL_PLACEHOLDER)
                {
                    urlTextBox.Text = "";
                    urlTextBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            urlTextBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(urlTextBox.Text))
                {
                    urlTextBox.Text = URL_PLACEHOLDER;
                    urlTextBox.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text.Trim();
            if (string.IsNullOrEmpty(url) || url == URL_PLACEHOLDER)
            {
                MessageBox.Show("请输入有效的URL", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdateStatus("正在抓取网页内容...");
                using (WebClient client = new WebClient())
                {
                    string pageContent = client.DownloadString(url);
                   
                    // 手机号正则表达式 - 匹配任意11位数字
                    string phonePattern = @"1[3-9]\d{9}";
                    MatchCollection phoneMatches = Regex.Matches(pageContent, phonePattern);
                    phoneListBox.Items.Clear();
                    foreach (Match match in phoneMatches)
                    {
                        phoneListBox.Items.Add(match.Value);
                    }

                    // 邮箱正则表达式
                    string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
                    MatchCollection emailMatches = Regex.Matches(pageContent, emailPattern);
                    emailListBox.Items.Clear();
                    foreach (Match match in emailMatches)
                    {
                        emailListBox.Items.Add(match.Value);
                    }

                    // 检查是否找到任何结果
                    string resultMessage = "抓取完成 - ";
                    if (phoneListBox.Items.Count == 0 && emailListBox.Items.Count == 0)
                    {
                        resultMessage += "未找到手机号码和邮箱地址";
                    }
                    else
                    {
                        if (phoneListBox.Items.Count == 0)
                        {
                            resultMessage += "未找到手机号码，";
                        }
                        else
                        {
                            resultMessage += $"找到 {phoneListBox.Items.Count} 个手机号码，";
                        }

                        if (emailListBox.Items.Count == 0)
                        {
                            resultMessage += "未找到邮箱地址";
                        }
                        else
                        {
                            resultMessage += $"找到 {emailListBox.Items.Count} 个邮箱地址";
                        }
                    }

                    UpdateStatus(resultMessage);

                    // 如果没有找到任何结果，显示提示信息
                    if (phoneListBox.Items.Count == 0 && emailListBox.Items.Count == 0)
                    {
                        MessageBox.Show("未在网页中找到手机号码和邮箱地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus("抓取失败");
                MessageBox.Show($"发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }
    }
}
