using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleInstances.Commands;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMediatRBenchMark.Controllers
{
    public class MultipleMediatRController : Controller
    {
        private IMediator _mediator;

        public MultipleMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<BenchMarkViewDto>> Process(BenchMarkCommand5 command)
        {
            return await _mediator.Send(command);
        }
    }
}
