using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Clock
{
    // 自定义事件参数类
    public class TickEventArgs : EventArgs
    {
        public DateTime CurrentTime { get; set; }
    }

    public class AlarmEventArgs : EventArgs
    {
        public DateTime AlarmTime { get; set; }
    }

    // 闹钟类
    public class AlarmClock
    {
        public event EventHandler<TickEventArgs> Tick;
        public event EventHandler<AlarmEventArgs> Alarm;

        private DateTime? _alarmTime;
        private readonly Timer _timer;

        public AlarmClock()
        {
            _timer = new Timer(1000); // 1秒间隔
            _timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        public void SetAlarm(DateTime alarmTime)
        {
            _alarmTime = alarmTime;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.Now;

            // 触发Tick事件
            Tick?.Invoke(this, new TickEventArgs { CurrentTime = now });

            // 检查并触发Alarm事件
            if (_alarmTime.HasValue && now >= _alarmTime.Value)
            {
                Alarm?.Invoke(this, new AlarmEventArgs { AlarmTime = _alarmTime.Value });
                _alarmTime = null; // 重置闹钟
            }
        }
    }

}
