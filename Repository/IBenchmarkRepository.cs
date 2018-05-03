using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBenchmarkRepository
    {
        List<BenchMarkViewDto> GetBenmarkData(int requestTotal, long requestId, string requestName);
    }
}
