using IoCdotNet;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.Impl
{
    public class ContextFactory : IDesignTimeDbContextFactory<MySqlDatabase>
    {
        public MySqlDatabase CreateDbContext(string[] args)
        {
            Assembly asm = typeof(IDatabase).Assembly;
            BatchBinding.MagicBind(asm, "ParkingAPI.Storage", "ParkingAPI.Storage.Impl");

            IDatabaseConfig cfg = IoC.Resolve<IDatabaseConfig>();
            cfg.Set(
                    server: "localhost",
                    port: 3306,
                    user: "root",
                    password: "81547686");


            return new MySqlDatabase();
        }
    }
}
