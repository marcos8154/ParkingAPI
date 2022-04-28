using IoCdotNet;
using ParkingAPI.Commands.Acoes.Estadi;
using ParkingAPI.Dominio;
using ParkingAPI.Dominio.Enum;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Estadi
{
    internal sealed class EntrarPlaca : ManipuladorComando<EntradaPlaca>
    {
        private readonly IEstacionamentoRepository estRepos;
        private readonly IPlacaRepository plaRepos;
        private readonly IEstadiaRepository estaRepos;
        private readonly ICobrancaRepository cobrRepos;

        public EntrarPlaca()
        {
            estRepos = IoC.Resolve<IEstacionamentoRepository>();
            plaRepos = IoC.Resolve<IPlacaRepository>();
            estaRepos = IoC.Resolve<IEstadiaRepository>();
            cobrRepos = IoC.Resolve<ICobrancaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(EntradaPlaca cmd)
        {
            try
            {
                cmd.Valida();
                Estacionamento est = BuscaEstacionamento(cmd);
                Placa pla = BuscaOuCadastraPlaca(cmd);

                TipoEstadia tipo = ObterTipoEstadia(pla);

                Estadia esta = new Estadia(
                    estacionamento: est,
                    placaEntrando: pla,
                    tipo);

                estaRepos.Add(esta);
                return new ResultadoAcao("Estadia aberta");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }

        private TipoEstadia ObterTipoEstadia(Placa placaEntrando)
        {
            if (placaEntrando.IsPlacaRotativa()) 
                return TipoEstadia.Rotativa;

            Proprietario donoPlaca = placaEntrando.Proprietario;
            bool possuiDisponibilidade = estaRepos.PossuiDisponibilidade(donoPlaca);

            if (possuiDisponibilidade)
            {
                return TipoEstadia.Mensalista;
            }
            else if (placaEntrando.PlacaPrioritaria)
            {
                Estadia naoPrioritaria = estaRepos.ObterEstadiaPlacaNaoPrioritaria(donoPlaca);
                if (naoPrioritaria == null)
                    return TipoEstadia.Rotativa;
                else
                {
                    Cobranca cobr = naoPrioritaria.Saida(
                            obs: "Estadia fechada automaticamente para dar vaga para '" + placaEntrando.Id + "'");

                    cobrRepos.Add(cobr);
                    return TipoEstadia.Mensalista;
                }
            }

            return TipoEstadia.Rotativa;
        }

        private Estacionamento BuscaEstacionamento(EntradaPlaca cmd)
        {
            Estacionamento est = estRepos.ObterPorCnpj(cmd.CNPJEstabelecimento);
            if (est == null) throw new Exception("Estacionamento não encontrado");
            return est;
        }

        private Placa BuscaOuCadastraPlaca(EntradaPlaca cmd)
        {
            Placa pla = plaRepos.Find(id: cmd.PlacaVeiculo);
            if (pla == null)
            {
                pla = new Placa(codigoPlaca: cmd.PlacaVeiculo);
                plaRepos.Add(pla);
            }
            return pla;
        }
    }
}