using AdvancedQuery.Tests;
using AdvancedQuery.Tests.Data;


var contextFactory = new ElementsContextFactory();

using (ElementsContext context = contextFactory.CreateDbContext(new string[] { }))
{
    try
    {
        DbSeed.SeedDatabase(context);
    } catch (Exception ex)
    {
        Console.WriteLine($"Failed to seed database: {ex.ToString()}");
    }

    Console.WriteLine("Hello, World!");
}
