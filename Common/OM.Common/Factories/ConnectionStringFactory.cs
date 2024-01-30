using OM.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Common.Factories
{
    public class ConnectionStringFactory
    {
        public static class ConnectionStringsFactory
        {
            public static string GetDbContextConnectionString()
            {
                return Environment.GetEnvironmentVariable(EnvironmentVariableConstants.DbConnectionString) ?? "MIGRATION";
            }
        }
    }
}
