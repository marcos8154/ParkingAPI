﻿using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface IEstacionamentoRepository : IRepository<Estacionamento>
    {
        Estacionamento ObterPorCnpj(string cnpj);
    }
}
