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
        public string PlacaId { get; private set; }
        public Guid EstacionamentoId { get; private set; }
        public virtual Placa Placa { get; private set; }
        public Boolean Mensalista { get; private set; }
        public string Observacao { get; private set; }
        public virtual Estacionamento Estacionamento { get; private set; }

        public Estadia(Estacionamento estacionamento, Placa placa)
        {
            Id = Guid.NewGuid();

            EstacionamentoId = estacionamento.Id;
            PlacaId = placa.Descricao;
            Placa = placa;
            DataEntrada = DateTime.Now;

            //se placa não é de mensalista
            if(placa.ProprietarioId==null) {
                Mensalista = false;
            } else {
                //o mensalista pode pagar por 2 vagas mas ter 4 placas cadastradas para usar a vaga, por exemplo, tem prioridade a placa que tiver marcada como padrão
                if(placa.Proprietario.Vagas>Placa.Proprietario.EstadiasMensalistaAberta.Count) {
                    //tem vaga disponível, abre estadia mensalista
                    Mensalista = true;
                } else if(placa.Padrao) {
                    //pega uma placa comum desse proprietário com estadia de mensalista aberta
                    Estadia estadiaplacacomum = Placa.Proprietario.EstadiasMensalistaAberta.Find(p => !p.Placa.Padrao);
                    if(estadiaplacacomum.Id!=null) {
                        //abre estadia mensalista
                        Mensalista = true;

                        //fecha estadia de placa adicional e abre uma com cobrança comum 
                        estadiaplacacomum.Observacao = "Estadia fechada automaticamente para dar vaga para '"+placa.Descricao+"'";
                        estadiaplacacomum.Saida();
                        Estadia novaEstadia = new Estadia(estadiaplacacomum.Estacionamento, estadiaplacacomum.Placa);
                    } else {
                        //se todas as vagas disponíveis estão ocupadas por placas padrão, abre estadia comum
                        Mensalista = false;
                    }
 
                } else {
                    //não é placa padrão e as vagas contratadas estão todas sendo usadas, abre estadia comum
                    Mensalista = false;
                }
            }  

            if(Mensalista) {
                placa.Proprietario.EstadiasMensalistaAberta.Add(this);
            }
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
            if(Mensalista) {
                //se estadia for de mensalista, gera cobrança com valor zerado
                cobrancaEstacionamento = new Cobranca(Placa, 0, $"Estadia de '{PlacaId}' (mensalista) por {TotalMinutos()} minutos");
                Placa.Proprietario.EstadiasMensalistaAberta.Remove(this);
            } else {
                decimal valor = Estacionamento.CalculaValorEstadia(this);
                cobrancaEstacionamento = new Cobranca(Placa, valor, $"Estadia de '{PlacaId}' por {TotalMinutos()} minutos");
            }

            return cobrancaEstacionamento;
        }
    }
}
