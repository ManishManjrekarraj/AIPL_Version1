using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UIChainConstants
    {
        public string ChainGrade {  get; set; }
        public string Notation { get; set; }
        public decimal ConstantK { get; set; }
        public decimal Diameter { get; set; }
        public Guid ProjectId { get; set; }
    }
}
