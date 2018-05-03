using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleInstances.Commands
{
    public class BenchMarkCommandHandler2 : IRequestHandler<BenchMarkCommand2, List<BenchMarkViewDto>>
    {
        private IBenchmarkRepository _repository;
        public BenchMarkCommandHandler2(IBenchmarkRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<BenchMarkViewDto>> Handle(BenchMarkCommand2 request, CancellationToken cancellationToken)
        {
            return _repository.GetBenmarkData(request.RequestTotal, request.RequestId, request.RequestName);
        }
    }
}
