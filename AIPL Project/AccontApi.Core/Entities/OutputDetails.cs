using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccontApi.Core.Entities
{
    public class OutputDetails
    {
        public decimal TotalWeight { get; set; }
        public decimal GlobalCGX { get; set; }
        public decimal GlobalCGY { get; set; }
        public decimal GlobalCGZ { get; set; }
        public decimal GlobalMx { get; set; }
        public decimal GlobalMy { get; set; }
        public decimal TotalArea { get; set; }
        public decimal UnitBuoyancyCapacity { get; set; }
        public Guid ProjectId { get; set; }

    }

}
