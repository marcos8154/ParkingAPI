using IoCdotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands
{
    public abstract class ManipuladorComando<TCommand> : IManipuladorComando where TCommand : IComandoAPI
    {
        protected abstract ResultadoAcao ManipulaComando(TCommand cmd);

        protected TRepository ObterInstanciaRepos<TRepository>()
        {
            return IoC.Resolve<TRepository>();
        }

        protected TRepository ObterInstanciaReposNomeado<TRepository>(string aliasInstancia)
        {
            InstanceManager manager = IoC.GetManager();
            return manager.ResolveNamed<TRepository>(aliasInstancia);
        }

        public async Task<IResultadoAcao> Manipular(IComandoAPI cmd)
        {
            return await Task.Run(() => ManipulaComando((TCommand)cmd));
        }
    }
}
