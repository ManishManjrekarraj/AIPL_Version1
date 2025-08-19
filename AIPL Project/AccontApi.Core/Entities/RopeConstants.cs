using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccontApi.Core.Entities
{
    public class RopeConstants
    {
        public string RopeType { get; set; }
        public int TensileStrength { get; set; }
        public decimal KValue { get; set; }
        public decimal RequiredDiameter { get; set; }
        public Guid ProjectId { get; set; }
    }
}
