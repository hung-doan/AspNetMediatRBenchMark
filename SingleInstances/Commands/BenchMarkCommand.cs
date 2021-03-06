﻿using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInstances.Commands
{
    public class BenchMarkCommand : IRequest<List<BenchMarkViewDto>>
    {
        public int RequestTotal { get; set; }
        public long RequestId { get; set; }
        public string RequestName { get; set; }
    }
}
