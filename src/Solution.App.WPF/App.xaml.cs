using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.App.WPF.ViewModels;
using Solution.Domain.Services.Abstractions;
using Solution.Domain.Services.Implementations;
using Solution.JsonPlaceHolder.API.Client;

namespace Solution.App.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public App()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {

            ClientConfiguration clientConfiguration = new ClientConfiguration();
            Configuration.Bind("APIClientConfiguration", clientConfiguration);
            services.AddSingleton(clientConfiguration);

            services.AddScoped<IJsonPlaceHolderClient, JsonPlaceHolderClient>();

            services.AddScoped<IPostService, PostService>();

            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = ServiceProvider.GetRequiredService<MainWindow>();
            window.DataContext = ServiceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }
    }
}
