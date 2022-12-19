using System;
using System.IO;
using System.Text.Json;
using AdvancedQuery.Tests.Data;

namespace AdvancedQuery.Tests;


internal class DomainData
{
    public int Id { get; set; }
    public List<ElementGroup> Groups { get; set; }
    public List<Element> Elements { get; set; }
}
public class DbSeed
{
    public static void SeedDatabase(ElementsContext context)
    {
        string dataStr = File.ReadAllText($"{Path.GetFullPath(@"..\..\..\")}/Data/Data.json");
        DomainData? data = JsonSerializer.Deserialize<DomainData>(dataStr);
        if (data == null) throw new Exception("Failed to load seed data. ");
        SeedGroups(context, data.Groups);
        SeedElements(context, data.Elements);
    }

    public static void SeedGroups(ElementsContext context, List<ElementGroup> groups)
    {
        if (!context.ElementGroups.Any())
        {
            context.ElementGroups.AddRange(groups);
            context.SaveChanges();
        }
    }

    public static void SeedElements(ElementsContext context, List<Element> elems)
    {
        if (!context.Elements.Any())
        {
            context.Elements.AddRange(elems);
            context.SaveChanges();
        }
    }
}
