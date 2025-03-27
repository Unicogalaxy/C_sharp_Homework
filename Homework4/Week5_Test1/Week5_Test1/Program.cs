using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Week5_Test1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
