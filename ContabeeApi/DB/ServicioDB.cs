using ContabeeComunes.Configuracion;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabeeApi.DB
{
    public class ServicioDB : IServicioDB
    {
        private DBConfig _dbCondfig;

        public ServicioDB(IOptions<DBConfig> dbConfig)
        {
            _dbCondfig = dbConfig.Value;
        }

        public async Task<bool> EliminaZombies()
        {
            try
            {
                using (var conn = new MySqlConnection(_dbCondfig.DefaultConnection))
                {
                    await conn.OpenAsync();

                    var query = @"UPDATE contabeev2auto.tscript$colaproceso SET Estado = 1
                                WHERE Estado = 2
                                AND FechaAsignacion >= DATE_FORMAT(NOW(), '%Y-%m-01')
                                AND FechaAsignacion < DATE_ADD(DATE_FORMAT(NOW(), '%Y-%m-01') + INTERVAL 1 MONTH, INTERVAL 0 SECOND)
                                AND FechaAsignacion <= NOW() - INTERVAL 1 HOUR;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        int updte = await cmd.ExecuteNonQueryAsync();

                        return updte > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
