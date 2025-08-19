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
    public class FloatSelectionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FloatSelectionController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public FloatSelectionController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpPost]
        //[Route("AddRopeConstants")]
        public async Task<IActionResult> Add(UIFloatSelection entity)
        {

            var apiResponse = new ApiResponse<string>();
            FloatSelection floatSelection = _IMapper.Map<FloatSelection>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.FloatSelection.AddAsync(floatSelection);
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
        [Route("GetAllFloatSelections")]
        public async Task<List<UIFloatSelection>> GetAll()
        {

            var apiResponse = new ApiResponse<List<UIFloatSelection>>();
            List<UIFloatSelection> floatSelectionList = new List<UIFloatSelection>();
            try
            {
                var data = await _unitOfWork.FloatSelection.GetAllAsync();
                floatSelectionList = _IMapper.Map<List<UIFloatSelection>>(data);
                apiResponse.Success = true;
                apiResponse.Result = floatSelectionList;
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

            return floatSelectionList;
        }
    }
}
