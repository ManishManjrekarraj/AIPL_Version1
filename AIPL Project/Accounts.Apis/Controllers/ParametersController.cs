using AccontApi.Core.Entities;
using AccountApi.Application.Interfaces;
using Accounts.Models.ApiResponse;
using Accounts.Models.UIModels;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Accounts.Apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParametersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _IMapper;
        private static readonly ILog _log = LogManager.GetLogger(typeof(ParametersController));
        public ParametersController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this._unitOfWork = unitOfWork;
            this._IMapper = Mapper;

        }

        [HttpGet]
        [Route("GetAllParameters")]
        public async Task<List<Parameters>> GetAll()
        {

            var apiResponse = new ApiResponse<List<Parameters>>();
            List<Parameters> parametersList = new List<Parameters>();
            try
            {
                var data = await _unitOfWork.ParametersRepo.GetAllAsync();
                parametersList = _IMapper.Map<List<Parameters>>(data);
                apiResponse.Success = true;
                apiResponse.Result = parametersList;
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

            return parametersList;
        }
    }
}
