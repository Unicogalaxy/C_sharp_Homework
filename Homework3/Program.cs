using Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var alarmClock = new AlarmClock();

            // 订阅事件
            alarmClock.Tick += (s, e) =>
                Console.WriteLine($"滴答... 当前时间：{e.CurrentTime:HH:mm:ss}");

            alarmClock.Alarm += (s, e) =>
                Console.WriteLine($"叮铃铃！！！闹钟时间到：{e.AlarmTime:HH:mm:ss}");

            Console.WriteLine("按任意键退出...");
            // 设置5秒后的闹钟
            var alarmTime = DateTime.Now.AddSeconds(10);
            Console.WriteLine($"设置闹钟时间：{alarmTime:HH:mm:ss}");
            alarmClock.SetAlarm(alarmTime);

            
            Console.ReadKey();
        }
    }
}
