using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInstances.Services
{
    public class BenchMarkService: IBenchMarkService
    {
        private IBenchmarkRepository _repository;
        public BenchMarkService(IBenchmarkRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BenchMarkViewDto>> GetBenmarkData(BenchMarkServiceDto dto)
        {
            return _repository.GetBenmarkData(dto.RequestTotal, dto.RequestId, dto.RequestName);
        }
    }
}
