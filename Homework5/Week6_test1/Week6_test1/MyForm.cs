using System;
using System.Windows.Forms;
using AutoWindowsSize;

namespace Week6_test1
{
    public partial class MyForm : Form
    {
        AutoAdaptWindowsSize AutoSize;
        private string currentInput = "";
        private double? firstNumber = null;
        private string currentOperator = "";
        private bool newInput = true;
        private string expression = ""; // 新增变量用于存储完整表达式

        public MyForm()
        {
            InitializeComponent();
        }

        // 按下按钮后文本框显示的变化
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // 按下数字按钮时的通用处理方法
        private void AppendNumber(string number)
        {
            if (newInput)
            {
                currentInput = number;
                newInput = false;
            }
            else
            {
                currentInput += number;
            }
            if (string.IsNullOrEmpty(expression))
            {
                expression = currentInput;
            }
            else if (string.IsNullOrEmpty(currentOperator))
            {
                expression = expression.Replace(currentInput, "") + currentInput;
            }
            else
            {
                expression += number;
            }
            textBox1.Text = expression;
        }

        // 按下 0 对应的操作
        private void button1_Click(object sender, EventArgs e)
        {
            AppendNumber("0");
        }

        // 按下 1 对应的操作
        private void button2_Click(object sender, EventArgs e)
        {
            AppendNumber("1");
        }

        // 按下 2 对应的操作
        private void button3_Click(object sender, EventArgs e)
        {
            AppendNumber("2");
        }

        // 按下 3 对应的操作
        private void button4_Click(object sender, EventArgs e)
        {
            AppendNumber("3");
        }

        // 按下 4 对应的操作
        private void button5_Click(object sender, EventArgs e)
        {
            AppendNumber("4");
        }

        // 按下 5 对应的操作
        private void button6_Click(object sender, EventArgs e)
        {
            AppendNumber("5");
        }

        // 按下 6 对应的操作
        private void button7_Click(object sender, EventArgs e)
        {
            AppendNumber("6");
        }

        // 按下 7 对应的操作
        private void button8_Click(object sender, EventArgs e)
        {
            AppendNumber("7");
        }

        // 按下 8 对应的操作
        private void button9_Click(object sender, EventArgs e)
        {
            AppendNumber("8");
        }

        // 按下 9 对应的操作
        private void button10_Click(object sender, EventArgs e)
        {
            AppendNumber("9");
        }

        // 按下 = 对应的操作
        private void button11_Click(object sender, EventArgs e)
        {
            if (firstNumber.HasValue && !string.IsNullOrEmpty(currentOperator) && !string.IsNullOrEmpty(currentInput))
            {
                double secondNumber = double.Parse(currentInput);
                double result = 0;
                switch (currentOperator)
                {
                    case "+":
                        result = firstNumber.Value + secondNumber;
                        break;
                    case "-":
                        result = firstNumber.Value - secondNumber;
                        break;
                    case "*":
                        result = firstNumber.Value * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber.Value / secondNumber;
                        }
                        else
                        {
                            textBox1.Text = "Error: Division by zero";
                            return;
                        }
                        break;
                }
                expression = $"{firstNumber.Value}{currentOperator}{secondNumber}={result}";
                textBox1.Text = expression;
                currentInput = result.ToString();
                firstNumber = null;
                currentOperator = "";
                newInput = true;
            }
        }

        // 按下 del 对应的操作
        private void button12_Click(object sender, EventArgs e)
        {
            currentInput = "";
            firstNumber = null;
            currentOperator = "";
            newInput = true;
            expression = "";
            textBox1.Text = "";
        }

        // 按下运算符按钮时的通用处理方法
        private void SetOperator(object sender, EventArgs e, string op)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                if (firstNumber == null)
                {
                    firstNumber = double.Parse(currentInput);
                }
                else
                {
                    button11_Click(sender, e);
                    firstNumber = double.Parse(currentInput);
                }
                currentOperator = op;
                newInput = true;
                expression += op;
                textBox1.Text = expression;
            }
        }

        // 按下 + 对应的操作
        private void button13_Click(object sender, EventArgs e)
        {
            SetOperator(sender, e, "+");
        }

        // 按下 - 对应的操作
        private void button14_Click(object sender, EventArgs e)
        {
            SetOperator(sender, e, "-");
        }

        // 按下 * 对应的操作
        private void button15_Click(object sender, EventArgs e)
        {
            SetOperator(sender, e, "*");
        }

        // 按下 / 对应的操作
        private void button16_Click(object sender, EventArgs e)
        {
            SetOperator(sender, e, "/");
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            AutoSize = new AutoAdaptWindowsSize(this);
        }

        private void MyForm_SizeChanged(object sender, EventArgs e)
        {
            if (AutoSize != null) // 一定加这个判断，电脑缩放布局不是100%的时候，会报错
            {
                AutoSize.FormSizeChanged();
            }
        }
    }
}