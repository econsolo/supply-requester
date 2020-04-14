using Dapper;
using Microsoft.Extensions.Options;
using SupplyRequester.Domain.Entities;
using SupplyRequester.Infrastructure.Repositories.Interfaces;
using SupplyRequester.Util.Settings;
using System;
using System.Threading.Tasks;

namespace SupplyRequester.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<SupplyRequesterSettings> options) : base(options)
        { }

        public async Task<User> GetByUsernamePassword(string username, string password)
        {
            var sql = @"
                SELECT *
                FROM User U (NOLOCK)
                WHERE 1 = 1
                AND U.[Username] = @Username
                AND U.[Password] = @Password
            ";

            using var connection = GetConnection();

            return await connection.QueryFirstOrDefaultAsync(sql, new
            {
                Username = username,
                Password = password
            });
        }

        public async Task<Guid> Insert(User user)
        {
            var sql = @"
                INSERT INTO [User] (
                    [Name],
                    [Username],
                    [Password],
                    [Email],
                    [PhoneNumber],
                    [InsertedDate]
                )
                OUTPUT INSERTED.[Id]
                VALUES (
                    @Name,
                    @Username,
                    @Password,
                    @Email,
                    @PhoneNumber,
                    @InsertedDate
                )
            ";

            using var connection = GetConnection();

            user.Id = await connection.QueryFirstOrDefaultAsync<Guid>(sql, new
            {
                user.Name,
                user.Username,
                user.Password,
                user.Email,
                user.PhoneNumber,
                user.InsertedDate
            });

            return user.Id;
        }

        public async Task<int> Update(User user)
        {
            var sql = @"
                UPDATE [User] SET
                    [Name] = @Name,
                    [Username] = @Username,
                    [Password] = @Password,
                    [Email] = @Email,
                    [PhoneNumber] = @PhoneNumber,
                    [UpdatedDate] = @UpdatedDate
                WHERE [Id] = @Id
            ";

            using var connection = GetConnection();

            return await connection.ExecuteAsync(sql, new
            {
                user.Name,
                user.Username,
                user.Password,
                user.Email,
                user.PhoneNumber,
                user.UpdatedDate,
                user.Id
            });
        }
    }
}
