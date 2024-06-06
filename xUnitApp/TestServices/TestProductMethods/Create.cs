using Domain.DTOS.ProductDto;
using Domain.Entities;
using Infrastructure.Services.FileService;
using Infrastructure.Services.ProductService;
using Moq;
using xUnitApp.FakeDbContext;

namespace xUnitApp.TestServices.TestProductMethods;

public class Create()
{

    [Fact]
    public async Task Add_ProductService_Success()
    {
        // Arrange
        var product = new CreateProductDto()
        {
            Name = "product",
            Price = 1,
        };

        var context = new FakeDbContextFactory();
        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await ProductService.CreateProductAsync(product);

        // Assert
        Assert.Equal(200, res.StatusCode);
    }

    [Fact]
    public async Task Add_ProductService_Failure()
    {
        var context = new FakeDbContextFactory();

        // Arrange
        var file = new Mock<IFileService>();
        var productService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await productService.CreateProductAsync(null);

        // Assert
        Assert.Equal(400, res.StatusCode);
    }
}
