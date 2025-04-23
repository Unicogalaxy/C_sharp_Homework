using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week9_test;

namespace Week9_test
{
    /// <summary>
    /// 英语单词测试程序的主窗体
    /// </summary>
    public partial class Form1 : Form
    {
        // 单词数据库对象
        private WordDatabase wordDatabase;
        // 存储单词列表，包含英文和中文释义
        private List<(string English, string Chinese)> words;
        // 当前显示的单词索引
        private int currentIndex = 0;

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            
            // 初始化单词数据库
            wordDatabase = new WordDatabase();
            words = wordDatabase.LoadWords();
            
            // 显示第一个单词
            DisplayNextWord();
            
            // 为按钮的点击事件添加处理方法
            buttonSubmit.Click += ButtonSubmit_Click;
        }

        /// <summary>
        /// 显示下一个单词
        /// </summary>
        private void DisplayNextWord()
        {
            if (currentIndex < words.Count)
            {
                // 显示中文释义
                labelChinese.Text = words[currentIndex].Chinese;
                // 清空输入框
                textBoxEnglish.Text = "";
                // 设置输入框焦点
                textBoxEnglish.Focus();
            }
            else
            {
                // 所有单词测试完成
                MessageBox.Show("恭喜！你已经完成了所有单词的测试！", "测试完成", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// 提交按钮点击事件处理
        /// </summary>
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string input = textBoxEnglish.Text.Trim();
            string correctAnswer = words[currentIndex].English;
            
            // 检查答案是否正确（忽略大小写）
            if (input.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
            {
                labelResult.Text = "正确";
                labelResult.ForeColor = Color.Green;
            }
            else
            {
                labelResult.Text = $"错误\n正确答案: {correctAnswer}";
                labelResult.ForeColor = Color.Red;
            }
            
            // 移动到下一个单词
            currentIndex++;
            DisplayNextWord();
        }

        /// <summary>
        /// 输入框按键事件处理
        /// </summary>
        private void textBoxEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            // 按回车键时提交答案
            if (e.KeyCode == Keys.Enter)
            {
                ButtonSubmit_Click(sender, e);
            }
        }

        private void textBoxEnglish_TextChanged(object sender, EventArgs e)
        {

        }
    }
}