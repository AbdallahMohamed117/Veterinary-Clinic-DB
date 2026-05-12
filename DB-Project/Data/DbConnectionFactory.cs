using Microsoft.Data.SqlClient;

namespace DB_Project.Data;

public class DbConnectionFactory(IConfiguration configuration)
{
    private readonly string _connectionString =
        configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    public SqlConnection Create() => new(_connectionString);
}
