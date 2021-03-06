﻿using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInstances.Services
{
    public interface IBenchMarkService
    {
        Task<List<BenchMarkViewDto>> GetBenmarkData(BenchMarkServiceDto dto);
    }
}
