using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace Week8_Test
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            
            // 初始化HttpClient
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        }

        private void InitializeCustomComponents()
        {
            // 设置窗体属性
            this.Text = "搜索引擎结果比较";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // 创建关键字输入框
            this.txtKeyword = new TextBox
            {
                Location = new Point(20, 20),
                Size = new Size(600, 30),
                Font = new Font("Microsoft YaHei", 12F),
                BorderStyle = BorderStyle.FixedSingle
            };

            // 创建搜索按钮
            this.btnSearch = new Button
            {
                Text = "搜索",
                Location = new Point(640, 18),
                Size = new Size(100, 35),
                Font = new Font("Microsoft YaHei", 12F),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            this.btnSearch.Click += BtnSearch_Click;

            // 创建搜狗结果标签
            this.lblBaidu = new Label
            {
                Text = "搜狗搜索结果：",
                Location = new Point(20, 60),
                AutoSize = true,
                Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215)
            };

            // 创建搜狗结果文本框
            this.txtBaiduResult = new TextBox
            {
                Multiline = true,
                Location = new Point(20, 90),
                Size = new Size(460, 500),
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Microsoft YaHei", 11F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            // 创建Bing结果标签
            this.lblBing = new Label
            {
                Text = "Bing搜索结果：",
                Location = new Point(500, 60),
                AutoSize = true,
                Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215)
            };

            // 创建Bing结果文本框
            this.txtBingResult = new TextBox
            {
                Multiline = true,
                Location = new Point(500, 90),
                Size = new Size(460, 500),
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Microsoft YaHei", 11F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            // 添加控件到窗体
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblBaidu);
            this.Controls.Add(this.txtBaiduResult);
            this.Controls.Add(this.lblBing);
            this.Controls.Add(this.txtBingResult);
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = this.txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入搜索关键字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.btnSearch.Enabled = false;
            this.txtBaiduResult.Text = "正在搜索...";
            this.txtBingResult.Text = "正在搜索...";

            try
            {
                // 并行执行两个搜索引擎的搜索
                var sogouTask = SearchSogou(keyword);
                var bingTask = SearchBing(keyword);

                // 等待两个任务完成
                await Task.WhenAll(sogouTask, bingTask);

                this.txtBaiduResult.Text = await sogouTask;
                this.txtBingResult.Text = await bingTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"搜索过程中发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.btnSearch.Enabled = true;
            }
        }

        private async Task<string> SearchSogou(string keyword)
        {
            try
            {
                string url = $"https://www.sogou.com/web?query={Uri.EscapeDataString(keyword)}";
                string html = await httpClient.GetStringAsync(url);
                
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                
                var results = new StringBuilder();
                
                // 尝试多种选择器来获取结果
                var resultNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'vrwrap')] | //div[contains(@class, 'rb')] | //div[contains(@class, 'results')]");
                if (resultNodes == null) return "未找到相关结果";

                foreach (var node in resultNodes.Take(10))
                {
                    // 获取标题
                    var titleNode = node.SelectSingleNode(".//h3 | .//h2 | .//a[contains(@class, 'str-title')]");
                    if (titleNode != null)
                    {
                        results.AppendLine("标题：" + titleNode.InnerText.Trim());
                    }

                    // 获取链接
                    var linkNode = node.SelectSingleNode(".//a[contains(@class, 'str-title')] | .//h3/a | .//h2/a");
                    if (linkNode != null)
                    {
                        results.AppendLine("链接：" + linkNode.GetAttributeValue("href", ""));
                    }

                    // 获取内容
                    var contentBuilder = new StringBuilder();
                    
                    // 尝试多种内容选择器
                    var contentNodes = node.SelectNodes(".//p[contains(@class, 'str-p')] | .//div[contains(@class, 'str-info')] | .//div[contains(@class, 'ft')] | .//div[contains(@class, 'summary')]");
                    if (contentNodes != null)
                    {
                        foreach (var contentNode in contentNodes)
                        {
                            string contentTem = contentNode.InnerText.Trim();
                            if (!string.IsNullOrEmpty(contentTem))
                            {
                                contentBuilder.AppendLine(contentTem);
                            }
                        }
                    }

                    // 如果内容为空，尝试获取其他可能的内容节点
                    if (contentBuilder.Length == 0)
                    {
                        var otherContent = node.SelectSingleNode(".//div[contains(@class, 'content')] | .//div[contains(@class, 'desc')]");
                        if (otherContent != null)
                        {
                            contentBuilder.AppendLine(otherContent.InnerText.Trim());
                        }
                    }

                    string contentText = contentBuilder.ToString().Trim();
                    if (!string.IsNullOrEmpty(contentText))
                    {
                        results.AppendLine("内容：" + contentText);
                    }

                    results.AppendLine("----------------------------------------");
                }

                string finalResult = results.ToString().Trim();
                
                // 如果内容仍然太少，尝试获取更多信息
                if (finalResult.Length < 200)
                {
                    // 尝试获取相关搜索
                    var relatedNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'related')]//a");
                    if (relatedNodes != null)
                    {
                        results.AppendLine("\n相关搜索：");
                        foreach (var relatedNode in relatedNodes.Take(5))
                        {
                            results.AppendLine(relatedNode.InnerText.Trim());
                        }
                    }
                }

                return results.ToString().Trim();
            }
            catch (Exception ex)
            {
                return $"搜索出错：{ex.Message}";
            }
        }

        private async Task<string> SearchBing(string keyword)
        {
            try
            {
                string url = $"https://www.bing.com/search?q={Uri.EscapeDataString(keyword)}";
                string html = await httpClient.GetStringAsync(url);
                
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                
                var resultNodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'b_algo')]");
                if (resultNodes == null) return "未找到相关结果";

                var results = new StringBuilder();
                foreach (var node in resultNodes.Take(5))
                {
                    var titleNode = node.SelectSingleNode(".//h2");
                    var contentNode = node.SelectSingleNode(".//p");
                    var linkNode = node.SelectSingleNode(".//h2/a");
                    
                    if (titleNode != null)
                    {
                        results.AppendLine("标题：" + titleNode.InnerText.Trim());
                    }
                    if (linkNode != null)
                    {
                        results.AppendLine("链接：" + linkNode.GetAttributeValue("href", ""));
                    }
                    if (contentNode != null)
                    {
                        results.AppendLine("内容：" + contentNode.InnerText.Trim());
                    }
                    results.AppendLine("----------------------------------------");
                }

                return results.ToString().Trim();
            }
            catch (Exception ex)
            {
                return $"搜索出错：{ex.Message}";
            }
        }
    }
}
