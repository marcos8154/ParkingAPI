
using IoCdotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands
{
    public abstract class ManipuladorComandoEmLotes<TCommand> where TCommand : class
    {
        protected TRepository ObterInstanciaRepos<TRepository>()
        {
            return IoC.Resolve<TRepository>();
        }

        protected TRepository ObterInstanciaReposNomeado<TRepository>(string aliasInstancia)
        {
            InstanceManager manager = IoC.GetManager();
            return manager.ResolveNamed<TRepository>(aliasInstancia);
        }

        protected abstract ResultadoAcao ManipulaComando(TCommand cmd);

        public async Task<IResultadoAcao> Manipular(List<IComandoAPI> cmd)
        {
            return await Task.Run(() => ManipulaComando(cmd as TCommand));
        }
    }
}
