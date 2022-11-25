using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ChronosService.Services
{
    public interface ITimerService
    {
        public DispatcherTimer CreateTimer();
    }
}
