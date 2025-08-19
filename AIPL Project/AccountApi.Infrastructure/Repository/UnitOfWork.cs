using AccontApi.Core.Entities;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IRopeConstantsRepository ropeConstants,
            IChainConstantsRepository chainConstants,
            IFloatCategoryRepository floatCategory,
            IFloatSelectionRepository floatSelection,
            IOutputDetailsRepository outputDetails,
            ILoadDatasRepository loadDatas,
            IInputsandLayoutRepository inputsandLayout,
            IProjectDetailsRepository projectDetails, IParametersRepository parameters)
        {
            
            RopeConstants = ropeConstants;
            ChainConstants = chainConstants;
            FloatCategories = floatCategory;
            FloatSelection = floatSelection;
            OutputDetails = outputDetails;
            LoadDatas = loadDatas;
            InputsandLayout = inputsandLayout;
            ProjectDetails = projectDetails;
            ParametersRepo = parameters;

        }

        
        public IRopeConstantsRepository RopeConstants { get; }

        public IChainConstantsRepository ChainConstants { get; }

        public IFloatCategoryRepository FloatCategories { get; }

        public IFloatSelectionRepository FloatSelection { get;}

        public IOutputDetailsRepository OutputDetails {  get; }
        public ILoadDatasRepository LoadDatas { get; }
        public IInputsandLayoutRepository InputsandLayout { get; }
        public IProjectDetailsRepository ProjectDetails { get; set; }

        public IParametersRepository ParametersRepo { get; set; }

    }
}
