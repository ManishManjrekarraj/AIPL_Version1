using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Application.Interfaces
{
    public interface IUnitOfWork
    {

        IRopeConstantsRepository RopeConstants { get; }

        IChainConstantsRepository ChainConstants { get; }

        IFloatCategoryRepository FloatCategories { get; }

        IFloatSelectionRepository FloatSelection { get; }

        IOutputDetailsRepository OutputDetails { get; }

        ILoadDatasRepository LoadDatas { get; }
        IInputsandLayoutRepository InputsandLayout { get; }
        IProjectDetailsRepository ProjectDetails { get; }

        IParametersRepository ParametersRepo { get; }
    }
}
