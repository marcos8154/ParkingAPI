﻿using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface ICobrancaRepository : IRepository<Cobranca>
    {
        Cobranca ObterPorCodigo(string codigoCobranca);
    }
}
