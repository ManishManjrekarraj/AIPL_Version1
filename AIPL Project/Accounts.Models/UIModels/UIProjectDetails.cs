using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Models.UIModels
{
    public class UIProjectDetails
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }
        public int MobileNumber { get; set; }  
        public string EmailId { get; set; }
        public Domain Domain { get; set; }
        public string ProjectDescription { get; set; }
        public string AttachFile { get; set; }
    }
    public enum Domain
    {
        Energy,
        Shipping,
        Water_Pumping,
        Floating_Events,
        Tourism,
        Construction
    }

}
