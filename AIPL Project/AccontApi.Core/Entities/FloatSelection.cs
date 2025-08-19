using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccontApi.Core.Entities
{
    public class FloatSelection
    {
        public int ItemId { get; set; }
        public string FloatCategory { get; set; }
        public string CategoryItems { get; set; }
        public string FloatCategoryId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
