using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using RegressBioA.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RegressBioA.WPF
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<SelectedProjectStore>();
                services.AddSingleton<ProjectStore>();
                services.AddSingleton<PopupNavigationStore>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<AsyncCommandErrorHandler>();
                services.AddTransient<ProjectViewModel>();

            })
            .Build();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.DataContext = _host.Services.GetRequiredService<MainViewModel>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
