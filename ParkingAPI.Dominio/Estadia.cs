using ParkingAPI.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Estadia
    {
        public Guid Id { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataSaida { get; private set; }


        public TipoEstadia Tipo { get; private set; }

        public string Observacao { get; private set; }


        public string PlacaId { get; private set; }

        /// <summary>
        /// Contém uma placa
        /// </summary>
        public virtual Placa Placa { get; private set; }

        public Guid EstacionamentoId { get; private set; }

        /// <summary>
        /// Pertence a um estacionamento
        /// </summary>
        public virtual Estacionamento Estacionamento { get; private set; }

        public Estadia(Estacionamento estacionamento, Placa placaEntrando)
        {
            Id = Guid.NewGuid();

            EstacionamentoId = estacionamento.Id;
            PlacaId = placaEntrando.Id;
            DataEntrada = DateTime.Now;

            Proprietario donoDaPlaca = placaEntrando.Proprietario;
            if (donoDaPlaca == null) throw new Exception("Proprietário não foi informado");


            //se placa não é de mensalista
            if (placaEntrando.IsPlacaRotativa())
                Tipo = TipoEstadia.Rotativa;
            //o mensalista pode pagar por 2 vagas mas ter 4 placas cadastradas para usar a vaga,
            //por exemplo, tem prioridade a placa que tiver marcada como padrão
            else if (donoDaPlaca.PossuiDisponibilidade() && placaEntrando.PlacaPrioritaria)
            {

                //pega uma placa comum desse proprietário com estadia de mensalista aberta
                Estadia estadiaplacacomum = donoDaPlaca.ObterEstadiaPlacaComum();

                if (estadiaplacacomum == null)
                {
                    //se todas as vagas disponíveis estão ocupadas por placas padrão, abre estadia comum
                    Tipo = TipoEstadia.Rotativa;
                }
                else
                {
                    //abre estadia mensalista
                    Tipo = TipoEstadia.Mensalista;

                    /*
                    //fecha estadia de placa adicional e abre uma com cobrança comum 
                    estadiaplacacomum.Observacao = "Estadia fechada automaticamente para dar vaga para '" + placaEntrando.DescricaoVeiculo + "'";
                    estadiaplacacomum.Saida();
                    Estadia novaEstadia = new Estadia(estadiaplacacomum.Estacionamento, estadiaplacacomum.Placa);
             */
                }
            }
            //não é placa padrão e as vagas
            //contratadas estão todas sendo usadas, abre estadia comum
            else Tipo = TipoEstadia.Rotativa; 
        }

        public double TotalMinutos()
        {
            if (DataSaida == null) return 0;

            double totalMin = ((DateTime)DataSaida - DataEntrada).TotalMinutes;
            return totalMin;
        }

        public Cobranca Saida()
        {
            if (Estacionamento == null)
                return null;

            DataSaida = DateTime.Now;
            Cobranca cobrancaEstacionamento;
            if (Tipo == TipoEstadia.Mensalista)
            {
                //se estadia for de mensalista, gera cobrança com valor zerado
                cobrancaEstacionamento = new Cobranca(Placa, 0, $"Estadia de '{PlacaId}' (mensalista) por {TotalMinutos()} minutos");
                Placa.Proprietario.EstadiasMensalistaAberta.Remove(this);
            }
            else
            {
                decimal valor = Estacionamento.CalculaValorEstadia(this);
                cobrancaEstacionamento = new Cobranca(Placa, valor, $"Estadia de '{PlacaId}' por {TotalMinutos()} minutos");
            }

            return cobrancaEstacionamento;
        }
    }
}
