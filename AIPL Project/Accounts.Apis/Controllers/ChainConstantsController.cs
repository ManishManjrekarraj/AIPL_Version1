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
    public class ChainConstantsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ChainConstantsController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public ChainConstantsController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpPost]
        //[Route("AddRopeConstants")]
        public async Task<IActionResult> Add(UIChainConstants entity)
        {

            var apiResponse = new ApiResponse<string>();
            ChainConstants chainconstants = _IMapper.Map<ChainConstants>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.ChainConstants.AddAsync(chainconstants);
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
        [Route("GetAllChainConstants")]
        public async Task<List<UIChainConstants>> GetAll()
        {

            var apiResponse = new ApiResponse<List<UIChainConstants>>();
            List<UIChainConstants> chainConstantsList = new List<UIChainConstants>();
            try
            {
                var data = await _unitOfWork.ChainConstants.GetAllAsync();
                chainConstantsList = _IMapper.Map<List<UIChainConstants>>(data);
                apiResponse.Success = true;
                apiResponse.Result = chainConstantsList;
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

            return chainConstantsList;
        }
    }
}
