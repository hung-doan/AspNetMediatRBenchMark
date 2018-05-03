using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInstances.Services
{
    public class BenchMarkService4: IBenchMarkService4
    {
        private IBenchmarkRepository _repository;
        public BenchMarkService4(IBenchmarkRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BenchMarkViewDto>> GetBenmarkData(BenchMarkServiceDto dto)
        {
            return _repository.GetBenmarkData(dto.RequestTotal, dto.RequestId, dto.RequestName);
        }
    }
}
