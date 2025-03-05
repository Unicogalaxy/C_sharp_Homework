using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_test1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("请输入你想要构造的10个图形      （  1：长方形  2：正方形 3：圆形  ）");
            Console.WriteLine("----------------------------------------------------------------------------------");

            double area_sum = 0;    //10个图形的总面积
            //循环构造10个图形
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("请输入你要构造的第" +(i+1) + "个图形的形状");
                string input = Console.ReadLine();
                try
                {
                    int index = int.Parse(input);            //index表示要构造的形状
                    
                    switch (index)
                    {
                        case 1:
                            Console.WriteLine("请输入长和宽");
                            string sideStr = Console.ReadLine();
                            // 使用空格分割输入字符串
                            string[] parts = sideStr.Split(' ');
                            double num1 = double.Parse(parts[0]); // 转换第一个整数
                            double num2 = double.Parse(parts[1]); // 转换第二个整数
                            Rectangle rec = new Rectangle(num1, num2);
                            if (rec.isCorrect())
                            {
                                Console.WriteLine("构造成功!");
                                area_sum += rec.calculateArea();
                            }

                            else
                            {
                                Console.WriteLine("此图形不可构造");
                                i--;
                            }
                            break;
                        case 2:
                            Console.WriteLine("请输入边长");
                            string sideLengthStr = Console.ReadLine();
                            double num = double.Parse(sideLengthStr);
                            Square squ = new Square(num);
                            if (squ.isCorrect())
                            {
                                Console.WriteLine("构造成功!");
                                area_sum += squ.calculateArea();
                            }
                            else
                            {
                                Console.WriteLine("此图形不可构造");
                                i--;
                            }
                            break;
                        case 3:
                            Console.WriteLine("请输入半径长度");
                            string radiusStr = Console.ReadLine();
                            double radius = double.Parse(radiusStr);
                            Circle cir = new Circle(radius);
                            if (cir.isCorrect())
                            {
                                Console.WriteLine("构造成功!");
                                area_sum += cir.calculateArea();
                            }
                            else
                            {
                                Console.WriteLine("此图形不可构造");
                                i--;
                            }
                            break;
                        default:
                            Console.WriteLine("请重新输入1,2,3中的一个");
                            i--;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("输入无效，请输入一个有效的整数！");
                    i--;                            //输入无效，重新输入一遍
                }
            }

            //循环结束，输出面积和
            Console.WriteLine("这10个面积和为" + area_sum);


        }
       
        public abstract class Shape        //定义抽象类Shape
        {
            public abstract double calculateArea();     //计算面积
            public abstract bool isCorrect();               //判断是否合法
        }

        //矩形
        public class Rectangle : Shape
        {
            protected double myLength;
            protected double myWidth;
            public double Length        //定义字段Length,Width 长 宽
            {
                set {
                    myLength = value;
                }
                get
                {
                    return myLength;
                }
            }
            public double Width
            {
                set
                {
                    myWidth = value;
                }
                get
                {
                    return myWidth;
                }
            }
            public Rectangle(double length, double width)
            {
                myLength = length;
                myWidth = width;
            }
            public override double calculateArea()
            {
                return isCorrect() ? myLength *myWidth :0;
            }
            public override bool isCorrect()
            {
                return Length > 0 && Width > 0;
            }
        }

        //正方形
        public class Square : Rectangle    //让Square继承Rectangle
        {
            public Square(double sideLength) : base(sideLength, sideLength) // 显式调用基类构造函数
            {
            }
        }

        //圆形
        public class Circle : Shape
        {
            private const double PI = 3.14; //定义常量pi用于计算圆形的面积
            public double Radius
            {
                get;set;
            }
            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double calculateArea()
            {
                return isCorrect() ? PI * Radius * Radius : 0;
            }
            public override bool isCorrect()
            {
                return Radius > 0;
            }
        }
    }

}
