using ChronosService.Services;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace CronometroWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ITimerService _timer;

        private int seconds;
        private int minutes;
        private int hours;
        private bool running = false;
        private bool newRun = false;

        private DispatcherTimer timerService;

        public MainWindow(ITimerService timer)
        {
            InitializeComponent();
            _timer = timer;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!running && !newRun)
            {
                newRun = true;
                timerService = _timer.CreateTimer();
                seconds = 0;
                timerLabel.Content = Convert.ToString("0:00:00");
                timerService.Tick += TimerOn;
                timerService.Start();

                running = true;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            timerService.Stop();
            running = false;
            seconds = 0;
            minutes = 0;
            hours = 0;
            timerLabel.Content = Convert.ToString("0:00:00");
            newRun = false;
            btnStop.Content = "Stop";
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (newRun)
            {
                if (running)
                {
                    timerService.Stop();
                    running = false;
                    btnStop.Content = "Continue";
                }
                else
                {
                    timerService.Start();
                    running = true;
                    btnStop.Content = "Stop";
                }
            }
        }
        private void TimerOn(object sender, EventArgs e)
        {
            seconds += 1;

            var m = Convert.ToString(minutes);
            var s = Convert.ToString(seconds);

            if (minutes < 10)
            {
                m = Convert.ToString("0" + minutes);
            }

            if (seconds < 10)
            {
                s = Convert.ToString("0" + seconds);
            }

            timerLabel.Content = Convert.ToString(hours + ":" + m + ":" + s);

            if (seconds >= 59)
            {
                minutes += 1;
                seconds = 0;

                if (minutes >= 59)
                {
                    hours += 1;
                    minutes = 0;
                }
            }
        }
    }
}
