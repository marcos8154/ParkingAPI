using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface IDatabaseConfig
    {
        void Set(string server, int port, string user, string password, string dbName);

        string ConnectionString();
    }
}
