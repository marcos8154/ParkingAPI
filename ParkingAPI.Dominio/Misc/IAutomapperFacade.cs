using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFIS.Misc
{
    public interface IAutomapperFacade
    {

        void Define(IConfigurationProvider cfg);

        TTarget Map<TTarget>(object source) where TTarget : class;


    }
}
