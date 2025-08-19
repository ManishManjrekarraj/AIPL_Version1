using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UIRopeConstants
    {
        public string RopeType { get; set; }
        public int TensileStrength { get; set; }   
        public float KValue { get; set; }
        public float RequiredDiameter { get; set; }
        public Guid ProjectId { get; set; }
    }
}
