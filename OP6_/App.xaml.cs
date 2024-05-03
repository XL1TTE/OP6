using Microsoft.Extensions.DependencyInjection;
using OP6_.Core;
using OP6_.MVVM.Model;
using OP6_.MVVM.View;
using OP6_.MVVM.ViewModel;
using OP6_.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OP6_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider; 
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<FilmLocalDB>();
            services.AddSingleton<FilmFilterParameters>();
            services.AddSingleton<FilteringService>();

            services.AddSingleton<MainWindow>((provider) => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<FilmotekaViewModel>();

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModelBase>>(provider =>
            viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));
            _serviceProvider = services.BuildServiceProvider();

            
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
