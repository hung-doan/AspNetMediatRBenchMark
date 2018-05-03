using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SingleInstances.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMediatRBenchMark.Controllers
{
    public class SingleMediatRController : Controller
    {
        private IMediator _mediator;

        public SingleMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<BenchMarkViewDto>> Process(BenchMarkCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
