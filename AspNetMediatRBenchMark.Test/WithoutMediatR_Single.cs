using AspNetMediatRBenchMark.Controllers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using SingleInstances.Services;
using System.Threading.Tasks;
using Xunit;
namespace AspNetMediatRBenchMark.Test
{
    public class WithoutMediatR_Single
    {
        IServiceCollection _serviceCollection;
        ServiceProvider _serviceProvider;

        public WithoutMediatR_Single()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddTransient<SingleServiceController>();

            _serviceCollection.AddTransient<IBenchmarkRepository, BenchmarkRepository>();

            _serviceCollection.AddTransient<IBenchMarkService, BenchMarkService>();

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public async Task Benchmark()
        {
            var controller = _serviceProvider.GetService<SingleServiceController>();
            var dto = new BenchMarkServiceDto
            {
                RequestTotal = 10,
                RequestId = 9,
                RequestName = "benchmark"

            };

            await controller.Process(dto);
        }
    }
}
