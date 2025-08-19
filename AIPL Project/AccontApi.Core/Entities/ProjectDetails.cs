using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccontApi.Core.Entities
{
    public class ProjectDetails
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }
        public int MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Domain { get; set; }
        public string ProjectDescription { get; set; }
        public string AttachFile { get; set; }
    }
}
