using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using AdvancedQuery.Tests;

namespace AdvancedQuery.Tests.Data;

public class ElementsContext : DbContext
{
    public ElementsContext(DbContextOptions<ElementsContext> options) : base(options) { }
    public DbSet<Element> Elements { get; set; }
    public DbSet<ElementGroup> ElementGroups { get; set; }
    public DbSet<Electron> Electrons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElementGroup>().ToTable("ElementGroups");

        modelBuilder.Entity<Electron>().ToTable("Electrons")
            .HasOne(e => e.Element)
            .WithMany(e => e.Electrons)
            .HasForeignKey(e => e.ElementId);

        modelBuilder.Entity<Element>().ToTable("Elements")
            .HasOne(e => e.ElementGroup)
            .WithMany(g => g.Elements)
            .HasForeignKey(e => e.GroupId);
    }
}

public class ElementsContextFactory : IDesignTimeDbContextFactory<ElementsContext>
{
    public ElementsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ElementsContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Elements;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        return new ElementsContext(optionsBuilder.Options);
    }
}
