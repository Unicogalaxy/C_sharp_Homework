using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Week9_test
{
    public class WordDatabase
    {
        private SQLiteConnection connection;

        public WordDatabase()
        {
            //数据库文件放在了Data Source下
            string connectionString = "Data Source=D:\\DevelopSoftware\\sqlite\\sqlite_database\\demo1.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
        }

        public List<(string English, string Chinese)> LoadWords()
        {
            // 用于存储从数据库中读取的单词数据，每个元素是一个包含英文和中文词义的元组
            List<(string English, string Chinese)> words = new List<(string English, string Chinese)>();
            try
            {
                connection.Open();
                // 使用 ORDER BY RANDOM() 随机排序查询结果
                string query = "SELECT English, Chinese FROM Words ORDER BY RANDOM()";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                // 循环读取数据读取器中的每一行数据
                while (reader.Read())
                {
                    string english = reader.GetString(0);
                    string chinese = reader.GetString(1);
                    // 将英文单词和中文词义组成一个元组，并添加到 words 列表中
                    words.Add((english, chinese));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // 如果在读取数据过程中出现异常，弹出消息框显示错误信息
                MessageBox.Show("Error loading words: " + ex.Message);
            }
            finally
            {
                // 无论是否发生异常，最后都关闭数据库连接
                connection.Close();
            }
            return words;
        }
    }
}