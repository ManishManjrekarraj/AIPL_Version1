using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
    public static class ProjectDetailsQueries
    {
        public static string AddProjectDetails =>
    @"INSERT INTO [dbo].[ProjectDetails]
    ([ProjectName], [CompanyName], [ClientName], [MobileNumber], [EmailId], [Domain], [ProjectDescription], [AttachFile])
        OUTPUT INSERTED.ProjectId
    VALUES
    ( @ProjectName, @CompanyName, @ClientName, @MobileNumber, @EmailId, @Domain, @ProjectDescription, @AttachFile)";

    

    //public static string GetProjectId =>
    //@"SELECT ProjectId AS NEWID() FROM [dbo].[ProjectDetails] WHERE ProjectId = LAST_INSERT_ID()";
        
        public static string GetProjectId =>
    @"SELECT ProjectId FROM [dbo].[ProjectDetails] WHERE ProjectName = @ProjectName ";

    }
}
