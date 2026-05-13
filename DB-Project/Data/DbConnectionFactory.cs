using Microsoft.Data.SqlClient;

namespace DB_Project.Data;

public class DbConnectionFactory(IConfiguration configuration)
{
    // HARDCODE the string exactly as it is in Rider
    private readonly string _connectionString = 
        "Server=localhost,1433;Database=VetClinicDB;User Id=sa;Password=UbuntuDatabase2026;Encrypt=True;TrustServerCertificate=True;Connect Timeout=30;";
    public SqlConnection Create() => new(_connectionString);
}
