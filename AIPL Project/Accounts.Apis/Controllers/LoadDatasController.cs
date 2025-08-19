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
    public class LoadDatasController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ChainConstantsController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public LoadDatasController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpGet]
        [Route("GetAllLoadData")]
        public async Task<List<UILoadDatas>> GetAll()
        {

            var apiResponse = new ApiResponse<List<UILoadDatas>>();
            List<UILoadDatas> loadDataList = new List<UILoadDatas>();
            try
            {
                var data = await _unitOfWork.LoadDatas.GetAllAsync();
                loadDataList = _IMapper.Map<List<UILoadDatas>>(data);
                apiResponse.Success = true;
                apiResponse.Result = loadDataList;
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

            return loadDataList;
        }
    }
}
