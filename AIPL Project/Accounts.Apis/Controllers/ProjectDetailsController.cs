using AccontApi.Core;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Logging;
//using AccountsUIBlazor.Data;
using Accounts.Models.UIModels;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Reflection;
using Accounts.Models.ApiResponse;
using AccountApi.Infrastructure.Repository;
using AccontApi.Core.Entities;



namespace Accounts.Apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectDetailsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FloatCategoryController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public ProjectDetailsController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpPost]
        //[Route("AddRopeConstants")]
        public async Task<Project_ID> Add(UIProjectDetails entity) 
        {

            var apiResponse = new ApiResponse<string>();
            ProjectDetails projectDetails = _IMapper.Map<ProjectDetails>(entity);
            //customer.IsActive = true;
            //Guid result = "";
            Project_ID project_id = new();

            try
            {
                var data = await _unitOfWork.ProjectDetails.PostAsyncProjectDetails(projectDetails);
                //result = data;

                //GetGuid getGuid = new GetGuid();
                project_id.ProjectID = data;

                //apiResponse.Success = true;
                //apiResponse.Result = data.ToString();

            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            //return Ok(result);
            return project_id;
        }
    }
}
