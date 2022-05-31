using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Placa
    {
        /// <summary>
        /// A propria placa em si
        /// ex: 
        /// APT-5800 (antiga)
        /// AE0045G704 (mercosul)
        /// </summary>
        public string Id { get; private set; }
        public string DescricaoVeiculo { get; private set; }

        /// <summary>
        /// Aka. Placa "Padrão" <br/>
        /// Se verdadeiro, quando esta placa der entrada <br/>
        /// no estacionamento, verificar se há outras vagas <br/>
        /// ocupadas que NÃO SEJAM Prioritárias, e inseriro ESTA PLACA <br/>
        /// no lugar da outra <br/>
        /// 
        /// <br/>
        /// A placa substituida deverá passar para o rotativo
        /// </summary>
        public bool PlacaPrioritaria { get; private set; }
        public bool PlacaAutorizada { get; private set; }

        public Guid? ProprietarioId { get; private set; }
        public virtual Proprietario Proprietario { get; private set; }

        public bool IsPlacaRotativa()
        {
            return ProprietarioId == null;
        }

        public Placa(string codigoPlaca, string descricaoVeiculo = "", bool prioritaria = false)
        {
            if (string.IsNullOrEmpty(codigoPlaca))
                throw new Exception("A placa do veículo é obrigátória");

            Id = codigoPlaca.ToUpper();
            AtualizaInfo(descricaoVeiculo, prioritaria);
        }

        public Placa()
        {

        }

        public Placa DefineAutorizada(bool autorizada)
        {
            PlacaAutorizada = autorizada;
            return this;
        }


        public Placa AtualizaInfo(string descricaoVeiculo, bool prioritaria)
        {
            DescricaoVeiculo = string.IsNullOrEmpty(descricaoVeiculo) ? "Cadastrado automaticamente" : descricaoVeiculo.ToUpper();
            PlacaPrioritaria = prioritaria;
            return this;
        }

        /// <summary>
        /// A placa é cadastrada inicialmente <br/>
        /// sem proprietario. <br/>
        /// 
        /// A principio é uma placa do "Rotativo", <br/>
        /// e posteriormente ao cadastrar o "Cliente" (Proprietario.cs)<br/>
        /// e vincular a placa ao proprietario
        /// </summary>
        /// <param name="proprietario"></param>
        public Placa DefineProprietario(Proprietario proprietario)
        {
            if (proprietario == null) ProprietarioId = null;
            else ProprietarioId = proprietario.Id;
            return this;
        }
    }
}
