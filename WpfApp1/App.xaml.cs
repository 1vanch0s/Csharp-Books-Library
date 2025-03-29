using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Data;
using static WpfApp1.Data.LibraryDBContext;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            services.AddDbContext<LibraryDBContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibraryDB;Trusted_Connection=True;"));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDBContext>();
                dbContext.Database.EnsureCreated();
            }

            var mainWindow = new MainWindow();
            //mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
