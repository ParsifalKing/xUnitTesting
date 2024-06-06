using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace xUnitApp.FakeDbContext;

public class FakeDbContextFactory
{
    public DataContext DbContextFactory()
    {

        var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("InMem").Options;

        var context = new DataContext(options);

        context.Database.EnsureCreated();
        context.AddRange(
             new Product { Id = 1, Price = 1, Name = "test1" },
             new Product { Id = 2, Price = 1, Name = "test2" },
             new Product { Id = 3, Price = 1, Name = "test3" },
             new Product { Id = 4, Price = 1, Name = "test4" },
             new Product { Id = 5, Price = 1, Name = "test5" }
        );
        context.SaveChanges();
        return context;
    }
}
