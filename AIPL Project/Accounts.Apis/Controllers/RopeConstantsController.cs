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
    public class RopeConstantsController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(RopeConstantsController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public RopeConstantsController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }


        [HttpPost]
        //[Route("AddRopeConstants")]
        public async Task<IActionResult> Add(UIRopeConstants entity)
        {

            var apiResponse = new ApiResponse<string>();
            RopeConstants ropeconstants = _IMapper.Map<RopeConstants>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.RopeConstants.AddAsync(ropeconstants);
                //UICustomer customerdata = _IMapper.Map<UICustomer>(data);
                apiResponse.Success = true;
                apiResponse.Result = data;

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

            return Ok(apiResponse);
        }
        

        [HttpGet]
        [Route("GetAllRopeConstants")]
        public async Task<List<UIRopeConstants>> GetAll()
        {

            var apiResponse = new ApiResponse<List<UIRopeConstants>>();
            List<UIRopeConstants> ropeConstantsList = new List<UIRopeConstants>();
            try
            {
                var data = await _unitOfWork.RopeConstants.GetAllAsync();
                ropeConstantsList = _IMapper.Map<List<UIRopeConstants>>(data);
                apiResponse.Success = true;
                apiResponse.Result = ropeConstantsList;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return ropeConstantsList;
        }
    }
}
