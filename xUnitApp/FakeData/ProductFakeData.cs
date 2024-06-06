using Domain.Entities;

namespace xUnitApp.FakeData;

public class ProductFakeData
{
    public IEnumerable<Product> GetAllPost()
    {
        var posts = new List<Product>();
        posts.Add(new Product { Id = 1, Price = 1, Name = "test1" });
        posts.Add(new Product { Id = 2, Price = 2, Name = "test2" });
        posts.Add(new Product { Id = 3, Price = 3, Name = "test3" });
        posts.Add(new Product { Id = 4, Price = 4, Name = "test4" });
        posts.Add(new Product { Id = 5, Price = 5, Name = "test5" });
        return posts;
    }
}
