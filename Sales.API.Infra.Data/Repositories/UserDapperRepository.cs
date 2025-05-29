using Sales.API.Domain.DTOs.User;
using Sales.API.Domain.Entities;
using Dapper;
using System.Data;
using Sales.API.Domain.Interfaces.Repositories;

public class UserDapperRepository : IUserDapperRepository
{
    private readonly IDbConnection _dbConnection;

    public UserDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<UserDTO?> UpdateUserNameById(Guid id, string userName)
    {
        var sql = @"
            UPDATE ""User""
            SET ""UserName"" = @UserName,
            WHERE ""Id"" = @Id";

        await _dbConnection.ExecuteAsync(sql, new
            {
                userName
            }
        );
        return await GetUserByIdAsync(id);
    }
    public async Task<User> CreateAsync(User user)
    {
        var sql = @"
            INSERT INTO ""User"" (""Id"", ""UserName"", ""Password"")
            VALUES (@Id, @UserName, @Password)";

        // Garante que o Id está preenchido
        if (user.Id == Guid.Empty)
            user.Id = Guid.NewGuid();

        await _dbConnection.ExecuteAsync(sql, new
        {
            user.Id,
            user.UserName,
            user.Password
        });

        return user;
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        var sql = @"SELECT * FROM ""User""";
        var result = await _dbConnection.QueryAsync<User>(sql);
        return result.ToList();
    }

    public async Task<UserDTO?> GetUserByIdAsync(Guid id)
    {
        var sql = "SELECT \"Id\", \"UserName\" FROM \"User\" WHERE \"Id\" = @Id";
        var result = await _dbConnection.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Id = id });
        return result;
    }
}

