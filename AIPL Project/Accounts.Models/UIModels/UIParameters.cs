using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UIParameters
    {
        public int FloatSizeId { get; set; }
        public string FloatSize { get; set; }
        public decimal XCordinate { get; set; }

        public decimal YCordinate { get; set; }
        //public LocalValues LocalValues { get; set; }
        public decimal WeightTonns { get; set; }
        public decimal COGx { get; set; }
        public decimal COGy { get; set; }
        public decimal COGz { get; set; }
        public decimal Area { get; set; }
        public decimal MOIxLocalCentroid { get; set; }
        public decimal MOIyLocalCentroid { get; set; }
        //public GobalCalculations GobalCalculations { get; set; }

        // ,[Length_x]
        public decimal WeighedX { get; set; }
        // [Width_y]
        public decimal WeighedY { get; set; }
        // [Height_z]
        public decimal WeighedZ { get; set; }
        public decimal MOIx { get; set; }
        public decimal MOIy { get; set; }
    }
}
