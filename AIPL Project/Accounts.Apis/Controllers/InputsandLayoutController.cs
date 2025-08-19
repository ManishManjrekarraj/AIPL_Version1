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
    public class InputsandLayoutController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ChainConstantsController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public InputsandLayoutController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpPost]
        [Route("AddInputs")]
        public async Task<IActionResult> Add(UIInputsAndLayout entity)
        {

            var apiResponse = new ApiResponse<string>();
            InputsandLayout inputsandlayout = _IMapper.Map<InputsandLayout>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.InputsandLayout.AddAsync(inputsandlayout);
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
        [Route("GetAllInputs")]
        public async Task<List<UIInputsAndLayout>> GetAllInputs()
        {

            var apiResponse = new ApiResponse<List<UIInputsAndLayout>>();
            List<UIInputsAndLayout> InputsList = new List<UIInputsAndLayout>();
            try
            {
                var data = await _unitOfWork.InputsandLayout.GetAllAsync();
                InputsList = _IMapper.Map<List<UIInputsAndLayout>>(data);
                apiResponse.Success = true;
                apiResponse.Result = InputsList;
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

            return InputsList;
        }

        [HttpPost]
        [Route("AddFloatSizes")]
        public async Task<IActionResult> AddFloatSizes(List<UIFloatSizeLayout> entity)
        {

            var apiResponse = new ApiResponse<string>();
            InputsandLayout inputsandlayout = _IMapper.Map<InputsandLayout>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.InputsandLayout.AddAsync(inputsandlayout);
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
        [Route("GetAllOutputTableDetails")]
        public async Task<List<UIOutputDetails>> GetAllOutputTableDetails()
        {

            var apiResponse = new ApiResponse<List<UIOutputDetails>>();
            List<UIOutputDetails> outputDetails = new List<UIOutputDetails>();
            try
            {
                var data = await _unitOfWork.OutputDetails.GetAllAsync();
                outputDetails = _IMapper.Map<List<UIOutputDetails>>(data);
                apiResponse.Success = true;
                apiResponse.Result = outputDetails;
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

            return outputDetails;
        }

        [HttpGet]
        [Route("GetAllLoadData")]
        public async Task<List<UILoadDatas>> GetAllLoadData()
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

        [HttpPost]
        [Route("AddInputsLayout")]
        public async Task<IActionResult> AddInputsLayout(UIInputLayoutMaster entity)
        {

            var apiResponse = new ApiResponse<string>();
            InputsandLayout inputsandlayout = _IMapper.Map<InputsandLayout>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.InputsandLayout.AddAsync(inputsandlayout);
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
    }
}
