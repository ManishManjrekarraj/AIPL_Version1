using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UILoadDatas
    {
        public int ItemNumber { get; set; }
        public string LoadName { get; set; }
        public string LoadType { get; set; }
        public float LoadValueTonnes { get; set; }
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
        public decimal LocationZ { get; set; }
        public decimal AreaX { get; set; }
        public decimal AreaY { get; set; }
        public int DragCoefficients { get; set; }
        public Guid ProjectId { get; set; }
    }
}
