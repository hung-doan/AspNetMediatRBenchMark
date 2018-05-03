using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInstances.Services
{
    public interface IBenchMarkService9
    {
        Task<List<BenchMarkViewDto>> GetBenmarkData(BenchMarkServiceDto dto);
    }
}
