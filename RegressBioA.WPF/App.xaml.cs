using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RegressBioA.Domain.Commands;
using RegressBioA.Domain.Queries;
using RegressBioA.EntityFramework;
using RegressBioA.EntityFramework.Commands;
using RegressBioA.EntityFramework.Queries;
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

        private readonly IGetAllProjectsQuery _getAllProjectsQuery;
        private readonly ICreateProjectCommand _createProjectCommand;
        private readonly IUpdateProjectCommand _updateProjectCommand;
        private readonly IDeleteProjectCommand _deleteProjectCommand;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<SelectedProjectStore>();
                services.AddSingleton<ProjectStore>();
                services.AddSingleton<PopupNavigationStore>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<AsyncCommandErrorHandler>();
                services.AddTransient<ProjectViewModel>();

                services.AddSingleton<IGetAllProjectsQuery, GetAllProjectsQuery>();
                services.AddSingleton<ICreateProjectCommand, CreateProjectCommand>();
                services.AddSingleton<IUpdateProjectCommand, UpdateProjectCommand>();
                services.AddSingleton<IDeleteProjectCommand, DeleteProjectCommand>();

                string connectionString = "Data Source=Projects.db";
                services.AddDbContextFactory<ProjectsDbContext>((_, optionsBuilder) =>
                {
                    optionsBuilder.UseSqlite(connectionString);
                });
            });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
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
