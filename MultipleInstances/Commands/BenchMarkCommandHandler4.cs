﻿using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleInstances.Commands
{
    public class BenchMarkCommand4Handler : IRequestHandler<BenchMarkCommand4, List<BenchMarkViewDto>>
    {
        private IBenchmarkRepository _repository;
        public BenchMarkCommand4Handler(IBenchmarkRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<BenchMarkViewDto>> Handle(BenchMarkCommand4 request, CancellationToken cancellationToken)
        {
            return _repository.GetBenmarkData(request.RequestTotal, request.RequestId, request.RequestName);
        }
    }
}
