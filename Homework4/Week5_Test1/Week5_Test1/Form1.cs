using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week5_Test1
{
    public partial class Form1: Form
    {
        private FileMergerService fileMergerService;
        public Form1()
        {
            InitializeComponent();
            fileMergerService = new FileMergerService();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile1.Text = openFileDialog.FileName;
            }
        }
      
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile1.Text = openFileDialog.FileName;
            }
        }

        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile2.Text = openFileDialog.FileName;
            }
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            string file1 = txtFile1.Text;
            string file2 = txtFile2.Text;

            if (!string.IsNullOrEmpty(file1) && !string.IsNullOrEmpty(file2))
            {
                fileMergerService.MergeFiles(file1, file2);
            }
            else
            {
                MessageBox.Show("请选择两个文本文件。");
            }
        }
    }
}
