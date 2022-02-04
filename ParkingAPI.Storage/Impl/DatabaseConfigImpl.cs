using IoCdotNet.Attributes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.Impl
{
    [SingletonInstance]
    public class DatabaseConfigImpl : IDatabaseConfig
    {
        private MySqlConnectionStringBuilder sb;

        public void Set(string server, int port, string user, string password)
        {
            sb = new MySqlConnectionStringBuilder();
            sb.Server = server;
            sb.Port = (uint)port;
            sb.UserID = user;
            sb.Password = password;
            sb.Database = "ParkingDB";
        }

        public string ConnectionString()
        {
            if (sb == null) return null;
            return sb.ConnectionString;
        }
    }
}
