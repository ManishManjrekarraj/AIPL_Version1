using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UIFloatCategory
    {
        public int FloatCategoryId { get; set; }
        public string FloatCategory {  get; set; }
        public Guid ProjectId { get; set; }
    }
}
