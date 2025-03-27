using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week5_Test1
{
    class FileMergerService
    {
        public void MergeFiles(string file1, string file2)
        {
            try
            {
                string dataDirectory = Path.Combine(Application.StartupPath, "Data");
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }

                string outputFilePath = Path.Combine(dataDirectory, "MergedFile.txt");

                string content1 = File.ReadAllText(file1);
                string content2 = File.ReadAllText(file2);

                string mergedContent = content1 + Environment.NewLine + content2;

                File.WriteAllText(outputFilePath, mergedContent);

                MessageBox.Show($"文件合并完成，新文件路径：{outputFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}");
            }
        }
    }
}
