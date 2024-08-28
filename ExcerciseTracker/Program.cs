

using ExcerciseTracker.Controllers;
using ExcerciseTracker.Data;
using ExcerciseTracker.Repositories;
using ExcerciseTracker.Repositories.IRepository;
using ExcerciseTracker.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExcerciseTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var userInput = serviceProvider.GetService<UserInput>();

            userInput.UserMenu();
    
            
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ExcerciseContext>();

            services.AddScoped<IExcerciseRepository, ExcerciseRepository>();

            services.AddScoped<UserInput>();

            services.AddScoped<ExcerciseController>();

            services.AddScoped<ExcerciseService>();
        }
    }

}
