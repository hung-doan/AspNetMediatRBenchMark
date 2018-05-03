using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultipleInstances.Services;

namespace AspNetMediatRBenchMark.Controllers
{
    public class MultipleServiceController : Controller
    {
        private IBenchMarkService5 _service;
        public MultipleServiceController(IBenchMarkService5 service)
        {
            _service = service;
        }
        public async Task<List<BenchMarkViewDto>> Process(BenchMarkServiceDto dto)
        {
            return await _service.GetBenmarkData(dto);
        }
    }
}
