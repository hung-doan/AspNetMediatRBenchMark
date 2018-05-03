using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class BenchmarkRepository : IBenchmarkRepository
    {
        public List<BenchMarkViewDto> GetBenmarkData(int requestTotal, long requestId, string requestName)
        {
            var result = new List<BenchMarkViewDto>();
            for(var i = 0; i < requestTotal; i++)
            {
                result.Add(new BenchMarkViewDto {
                    Id = requestId + i,
                    Name = $"{requestName}-{i}"
                });
            }

            return result;
        }
    }
}
