using Domain.DTOS.ProductDto;
using Infrastructure.Services.FileService;
using Infrastructure.Services.ProductService;
using Moq;
using xUnitApp.FakeDbContext;

namespace xUnitApp.TestServices.TestProductMethods;

public class Edit
{
    [Fact]
    public async Task Edit_ProductService_Success()
    {
        const int id = 1;
        // Arrange
        var Product = new UpdateProductDto()
        {
            Id = id,
            Name = "testNew-update",
            Price = 1
        };
        var context = new FakeDbContextFactory();
        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await ProductService.UpdateProductAsync(Product);

        // Assert
        Assert.Equal(200, res.StatusCode);
    }

    [Fact]
    public async Task Edit_ProductService_Failure()
    {
        // Arrange
        var Product = new UpdateProductDto();
        var context = new FakeDbContextFactory();

        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await ProductService.UpdateProductAsync(Product);

        // Assert
        Assert.Equal(400, res.StatusCode);
    }
}
