using AspNetMediatRBenchMark.Controllers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SingleInstances.Commands;
using Repository;
using System.Threading.Tasks;
using Xunit;
namespace AspNetMediatRBenchMark.Test
{
    public class WithMediatR_Single
    {
        IServiceCollection _serviceCollection;
        ServiceProvider _serviceProvider;

        public WithMediatR_Single()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddTransient<SingleMediatRController>();

            _serviceCollection.AddMediatR(typeof(SingleInstances.Commands.IMediatorBootstrap));

            _serviceCollection.AddTransient<IBenchmarkRepository, BenchmarkRepository>();

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public async Task Benchmark()
        {
            var controller = _serviceProvider.GetService<SingleMediatRController>();
            var command = new BenchMarkCommand
            {
                RequestTotal = 10,
                RequestId = 9,
                RequestName = "benchmark"

            };

            await controller.Process(command);

        }
        
    }
}
