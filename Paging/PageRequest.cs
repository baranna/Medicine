using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Paging
{
    public class PageRequest
    {
        public int Page { get; set; } = 0;

        public int PageSize { get; set; } = 15;
    }
}
