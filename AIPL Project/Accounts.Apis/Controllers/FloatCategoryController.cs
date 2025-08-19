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
using System;



namespace Accounts.Apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FloatCategoryController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FloatCategoryController));


        /// <summary>
        /// Initialize CustomerController by injecting an object type of IUnitOfWork
        /// </summary>
        public FloatCategoryController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpPost]
        //[Route("AddRopeConstants")]
        public async Task<IActionResult> Add(UIFloatCategory entity)
        {

            var apiResponse = new ApiResponse<string>();
            FloatCategory floatCategory = _IMapper.Map<FloatCategory>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.FloatCategories.AddAsync(floatCategory);
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
        [Route("GetAllCategories")]
        public async Task<List<UIFloatCategory>> GetAll()
        {

            var apiResponse = new ApiResponse<List<UIFloatCategory>>();
            List<UIFloatCategory> categoriesList = new List<UIFloatCategory>();
            try
            {
                var data = await _unitOfWork.FloatCategories.GetAllAsync();
                categoriesList = _IMapper.Map<List<UIFloatCategory>>(data);
                apiResponse.Success = true;
                apiResponse.Result = categoriesList;
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

            return categoriesList;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(List<Customer> entity)
        {

            var apiResponse = new ApiResponse<string>();
            FloatCategory floatCategory = _IMapper.Map<FloatCategory>(entity);
            //customer.IsActive = true;

            try
            {
                var data = await _unitOfWork.FloatCategories.AddAsync(floatCategory);
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

        [HttpPost]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(Customer entity)
        {

            var apiResponse = new ApiResponse<string>();
            //FloatCategory floatCategory = _IMapper.Map<FloatCategory>(entity);
            //customer.IsActive = true;

            try
            {
                if (entity.Id == Guid.Empty)
                {
                    Console.WriteLine("Guid is Empty");
                }
                else
                {
                    Console.WriteLine($"Guid exists : {entity.Id}");
                }
                //var data = await _unitOfWork.FloatCategories.AddAsync(floatCategory);
                //UICustomer customerdata = _IMapper.Map<UICustomer>(data);
                apiResponse.Success = true;
                //apiResponse.Result = data;

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
