using AccontApi.Core.Entities;
using AccountApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Infrastructure
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly DapperDbOptions _dapperOptions;

        private IDbConnection _connection;

        public SqlConnectionFactory(DapperDbOptions dapperOptions)
        {
            _dapperOptions = dapperOptions;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }

        public async Task<IDbConnection> GetOpenConnectionAsync()
        {
            if (_connection! == null || _connection.State != ConnectionState.Open)
            {
                SqlConnection connection = new SqlConnection(_dapperOptions?.MainDb);
                // var tokenProvider = new AzureServiceTokenProvider();
                //  connection.AccessToken = await tokenProvider.GetAccessTokenAsync("https://database.windows.net/");
                _connection = connection;
                _connection.Open();
            }

            return _connection;
        }
    }
}
