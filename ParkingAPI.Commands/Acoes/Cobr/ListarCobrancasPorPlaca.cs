using ParkingAPI.Commands.Manipuladores.Cobr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Cobr
{
    public class ListarCobrancasPorPlaca : IComandoAPI
    {
        public const string SITUACAO_PAGO = "PAGO";
        public const string SITUACAO_NAO_PAGO = "NAO_PAGO";
        public const string SITUACAO_TODOS = "TODOS";

        public string PlacaVeiculo { get; set; }
        public bool TodoOPeriodo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Situacao { get; set; }


        public async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorCobrancasPorPlaca().Manipular(this);
        }

        public void Valida()
        {
            string[] situacoesAceitas = new string[] { "PAGO", "NAO_PAGO", "TODOS" };

            if (string.IsNullOrEmpty(Situacao)) throw new Exception("A situação deve ser informada. Os valores válidos são: 'PAGO', 'NAO_PAGO' e 'TODOS'");

            Situacao = Situacao.ToUpper();
            if (situacoesAceitas.Any(s => s.Equals(Situacao)) == false)
                throw new Exception($"O valor '{Situacao}' não é válido para a Situação. Os valores válidos são: 'PAGO', 'NAO_PAGO' e 'TODOS'");

            if (TodoOPeriodo == false)
                if (DataInicio == null || DataFim == null)
                    throw new Exception("Caso a consulta não seja para todo o período, uma data inicial e final devem ser informadas");

            if (string.IsNullOrEmpty(PlacaVeiculo)) throw new Exception("A placa do veículo deve ser informada");
        }
    }
}
