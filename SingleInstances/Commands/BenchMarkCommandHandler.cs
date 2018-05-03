using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SingleInstances.Commands
{
    public class BenchMarkCommandHandler : IRequestHandler<BenchMarkCommand, List<BenchMarkViewDto>>
    {
        private IBenchmarkRepository _repository;
        public BenchMarkCommandHandler(IBenchmarkRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<BenchMarkViewDto>> Handle(BenchMarkCommand request, CancellationToken cancellationToken)
        {
            return _repository.GetBenmarkData(request.RequestTotal, request.RequestId, request.RequestName);
        }
    }
}
