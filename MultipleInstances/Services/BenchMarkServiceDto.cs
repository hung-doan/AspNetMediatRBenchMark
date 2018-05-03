using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleInstances.Services
{
    public class BenchMarkServiceDto
    {
        public int RequestTotal { get; set; }
        public long RequestId { get; set; }
        public string RequestName { get; set; }
    }
}
