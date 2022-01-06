﻿using ParkingAPI.Dominio;
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
    }
}
