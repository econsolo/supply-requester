using Dapper;
using Microsoft.Extensions.Options;
using SupplyRequester.Domain.Entities;
using SupplyRequester.Infrastructure.Repositories.Interfaces;
using SupplyRequester.Util.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SupplyRequester.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly SupplyRequesterSettings SupplyRequesterSettings;

        protected BaseRepository(IOptions<SupplyRequesterSettings> options)
        {
            SupplyRequesterSettings = options.Value;
        }

        protected SqlConnection GetConnection()
        {
            var sqlConn = new SqlConnection(SupplyRequesterSettings.ConnectionSettings.SqlServerConnectionString);
            return sqlConn;
        }

        public async Task<T> GetById(Guid id)
        {
            var sql = @$"
                SELECT *
                FROM {nameof(T)} T (NOLOCK)
                WHERE T.[Id] = @Id
            ";

            using var connection = GetConnection();

            return await connection.QueryFirstOrDefaultAsync<T>(sql, new
            {
                Id = id
            });
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var sql = @$"
                SELECT *
                FROM {nameof(T)} T (NOLOCK)
                ORDER BY T.[InsertedDate] DESC
            ";

            using var connection = GetConnection();

            return await connection.QueryAsync<T>(sql);
        }
    }
}
