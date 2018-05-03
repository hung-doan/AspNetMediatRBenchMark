using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInstances.Commands
{
    public class BenchMarkCommand7 : IRequest<List<BenchMarkViewDto>>
    {
        public int RequestTotal { get; set; }
        public long RequestId { get; set; }
        public string RequestName { get; set; }
    }
}
