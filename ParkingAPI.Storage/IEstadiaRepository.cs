using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface IEstadiaRepository : IRepository<Estadia>
    {
        Estadia ObterEstadiaAbertaPorPlaca(string placa);
        IReadOnlyCollection<Estadia> ObterEstadiaPorPlaca(string placa);
        IReadOnlyCollection<Estadia> ObterEstadiaAberta();
        IReadOnlyCollection<Estadia> ObterEstadiaPorEstacionamento(string cnpj_estacionamento);
        bool PossuiDisponibilidade(Proprietario donoPlaca);
        Estadia ObterEstadiaPlacaNaoPrioritaria(Proprietario donoPlaca);
        List<Estadia> BuscarEstadias(string cNPJEstacionamento, string placaVeiculo, bool apenasEmAberto);
    }
}
