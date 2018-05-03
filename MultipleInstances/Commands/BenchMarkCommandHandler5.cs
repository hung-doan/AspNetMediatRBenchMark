using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleInstances.Commands
{
    public class BenchMarkCommand5Handler : IRequestHandler<BenchMarkCommand5, List<BenchMarkViewDto>>
    {
        private IBenchmarkRepository _repository;
        public BenchMarkCommand5Handler(IBenchmarkRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<BenchMarkViewDto>> Handle(BenchMarkCommand5 request, CancellationToken cancellationToken)
        {
            return _repository.GetBenmarkData(request.RequestTotal, request.RequestId, request.RequestName);
        }
    }
}
