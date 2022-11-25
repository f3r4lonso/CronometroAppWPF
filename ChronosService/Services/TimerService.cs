using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ChronosService.Services
{
    public class TimerService : ITimerService
    {
        public DispatcherTimer CreateTimer()
        {
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            return timer;
        }
    }
}
