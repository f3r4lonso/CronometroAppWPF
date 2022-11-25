using ChronosService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CronometroWPF
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfiguredServices(services);

                }).Build();
        }
        private void ConfiguredServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<ITimerService, TimerService>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainwindow = _host.Services.GetRequiredService<MainWindow>();
            mainwindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
