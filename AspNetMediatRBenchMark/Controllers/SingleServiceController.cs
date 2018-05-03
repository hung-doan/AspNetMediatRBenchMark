using Microsoft.AspNetCore.Mvc;
using SingleInstances.Services;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMediatRBenchMark.Controllers
{
    public class SingleServiceController : Controller
    {
        private IBenchMarkService _service;
        public SingleServiceController(IBenchMarkService service)
        {
            _service = service;
        }
        public async Task<List<BenchMarkViewDto>> Process(BenchMarkServiceDto dto)
        {
            return await _service.GetBenmarkData(dto);
        }
    }
}
