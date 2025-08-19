using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccontApi.Core.Entities
{
    public class FloatCategory
    {
        public int FloatcategoryId { get; set; }
        public string Floatcategory {  get; set; }
        public Guid ProjectId { get; set; }
    }
}
