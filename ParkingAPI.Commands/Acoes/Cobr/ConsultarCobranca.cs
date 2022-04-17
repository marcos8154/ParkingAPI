﻿using ParkingAPI.Commands.Manipuladores.Cobr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Cobr
{
    public class ConsultarCobranca : IComandoAPI
    {
        public ConsultarCobranca(string codigoCobranca)
        {
            CodigoCobranca = codigoCobranca;
        }

        public string CodigoCobranca { get; set; }

        public async Task<IResultadoAcao> Executar()
        {
            return await new ConsultaCobranca().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(CodigoCobranca)) throw new Exception("O código da cobrança deve ser informado");
        }
    }
}