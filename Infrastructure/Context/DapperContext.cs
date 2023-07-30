using Npgsql;

namespace Infrastructure.Context;

public class DapperContext
{
    private string _connectoinString =
        "Server=localhost;Port=5432;Database=quotedb;User Id=postgres;Password=12345;";

    public NpgsqlConnection Connection() => new NpgsqlConnection(_connectoinString);
}