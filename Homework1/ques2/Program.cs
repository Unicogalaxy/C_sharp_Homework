using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Work1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("请输入上限和下限:");
            string str = Console.ReadLine();

            //通过Split方法将str字符串分割
            string[] strs = str.Split(' ');

            //lower为下限，upper为上限
            int lower = int.Parse(strs[0]);
            int upper = int.Parse(strs[1]);
            Console.WriteLine("在{0}和{1}之间的质数有：",lower,upper);

            //count为质数的个数
            int count = 0;
            for(int i = lower; i <=upper; i++)
            {
                if (IsPrime(i))
                {
                    // 使用字符串格式化，每个数字宽度为5
                    Console.Write("{0,8}", i);
                    count++;
                    if (count % 10 == 0)
                    {
                        Console.WriteLine(" ");
                    }
                }
            }
            if(count == 0)
            {
                Console.WriteLine("没有找到质数");
            }
        }

        //定义判断质数的函数，判断num是否为参数
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;//       除了2之外的所有偶数都不为质数
            for (int i = 3; i * i <= num; i += 2)//   i+=2，只用判断奇数是否为质数
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}
