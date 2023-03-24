using CocktailsProject.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CocktailsProject;

public class DatabaseManager
{
    private readonly string _connectionString;
    
    public DatabaseManager(IConfiguration configuration)
    {
        // Get the database configuration from appsettings.json
        var section = configuration.GetSection("Database");
        var user = section["DB_USER"];
        var password = section["DB_PASSWORD"];
        var host = section["DB_HOST"];
        var port = section["DB_PORT"];
        var database = section["DB_NAME"];

        // Create the connection string
        _connectionString = $"User ID={user};Password={password};Host={host};Port={port};Database={database};Pooling=true;";
    }
    
    private CocktailsContext GetContext()
    {
        // Create the database context
        var optionsBuilder = new DbContextOptionsBuilder<CocktailsContext>();
        optionsBuilder.UseNpgsql(_connectionString);
        return new CocktailsContext(optionsBuilder.Options);
    }
    
    public IRepository<T> EntityManager<T>() where T : class => GetContext().GetRepository<T>();
}