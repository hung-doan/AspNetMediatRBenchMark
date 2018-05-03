using AspNetMediatRBenchMark.Controllers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Threading.Tasks;

namespace AspNetMediatRBenchMark.Benchmarks
{
    [CoreJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    public class BenchmarkInfo
    {
        private ServiceProvider _serviceProvider_Mediator_Single;
        private ServiceProvider _serviceProvider_Mediator_Multiple;


        private ServiceProvider _serviceProvider_Service_Single;
        private ServiceProvider _serviceProvider_Service_Multiple;

        [GlobalSetup]
        public void Setup()
        {
            // MediatR Single
            var mediatorSingleServiceCollection = new ServiceCollection();

            mediatorSingleServiceCollection.AddMediatR(typeof(SingleInstances.Commands.IMediatorBootstrap));
            mediatorSingleServiceCollection.AddTransient<SingleMediatRController>();
            mediatorSingleServiceCollection.AddTransient<IBenchmarkRepository, BenchmarkRepository>();

            _serviceProvider_Mediator_Single = mediatorSingleServiceCollection.BuildServiceProvider();


            // MediatR Multiple
            var mediatorMultipleServiceCollection = new ServiceCollection();

            mediatorMultipleServiceCollection.AddMediatR(typeof(MultipleInstances.Commands.IMediatorBootstrap));
            mediatorMultipleServiceCollection.AddTransient<MultipleMediatRController>();
            mediatorMultipleServiceCollection.AddTransient<IBenchmarkRepository, BenchmarkRepository>();

            _serviceProvider_Mediator_Multiple = mediatorMultipleServiceCollection.BuildServiceProvider();


            // Service Single
            var serviceSingleServiceCollection = new ServiceCollection();

            
            serviceSingleServiceCollection.AddTransient<SingleServiceController>();
            serviceSingleServiceCollection.AddTransient<IBenchmarkRepository, BenchmarkRepository>();
            serviceSingleServiceCollection.AddTransient<SingleInstances.Services.IBenchMarkService, SingleInstances.Services.BenchMarkService>();


            _serviceProvider_Service_Single = serviceSingleServiceCollection.BuildServiceProvider();

            // Service Multiple
            var multipleSingleServiceCollection = new ServiceCollection();


            multipleSingleServiceCollection.AddTransient<MultipleServiceController>();
            multipleSingleServiceCollection.AddTransient<IBenchmarkRepository, BenchmarkRepository>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService, MultipleInstances.Services.BenchMarkService>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService2, MultipleInstances.Services.BenchMarkService2>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService3, MultipleInstances.Services.BenchMarkService3>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService4, MultipleInstances.Services.BenchMarkService4>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService5, MultipleInstances.Services.BenchMarkService5>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService6, MultipleInstances.Services.BenchMarkService6>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService7, MultipleInstances.Services.BenchMarkService7>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService8, MultipleInstances.Services.BenchMarkService8>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService9, MultipleInstances.Services.BenchMarkService9>();
            multipleSingleServiceCollection.AddTransient<MultipleInstances.Services.IBenchMarkService10, MultipleInstances.Services.BenchMarkService10>();

            _serviceProvider_Service_Multiple = multipleSingleServiceCollection.BuildServiceProvider();
        }


        [Benchmark]
        public async Task Mediator_Single()
        {
            var controller = _serviceProvider_Mediator_Single.GetService<SingleMediatRController>();
            var command = new SingleInstances.Commands.BenchMarkCommand
            {
                RequestTotal = 10,
                RequestId = 9,
                RequestName = "benchmark"

            };

            await controller.Process(command);
        }

        [Benchmark]
        public async Task Mediator_Multiple()
        {
            var controller = _serviceProvider_Mediator_Multiple.GetService<MultipleMediatRController>();
            var command = new MultipleInstances.Commands.BenchMarkCommand5
            {
                RequestTotal = 10,
                RequestId = 9,
                RequestName = "benchmark"

            };

            await controller.Process(command);
        }

        [Benchmark]
        public async Task Service_Single()
        {
            var controller = _serviceProvider_Service_Single.GetService<SingleServiceController>();
            var dto = new SingleInstances.Services.BenchMarkServiceDto
            {
                RequestTotal = 10,
                RequestId = 9,
                RequestName = "benchmark"

            };

            await controller.Process(dto);
        }

        [Benchmark]
        public async Task Service_Multiple()
        {
            var controller = _serviceProvider_Service_Multiple.GetService<MultipleServiceController>();
            var dto = new MultipleInstances.Services.BenchMarkServiceDto
            {
                RequestTotal = 10,
                RequestId = 9,
                RequestName = "benchmark"

            };

            await controller.Process(dto);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkInfo>();
        }
    }
}
