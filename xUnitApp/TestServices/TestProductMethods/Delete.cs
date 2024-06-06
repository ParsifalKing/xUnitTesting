using Infrastructure.Services.FileService;
using Infrastructure.Services.ProductService;
using Moq;
using xUnitApp.FakeDbContext;

namespace xUnitApp.TestServices.TestProductMethods;

public class Delete
{
    [Fact]
    public async Task Delete_ProductService_Success()
    {
        const int id = 1;
        // Arrange
        var context = new FakeDbContextFactory();

        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await ProductService.DeleteProductAsync(id);

        // Assert
        Assert.True(res.Data);
    }

    [Fact]
    public async Task Delete_ProductService_Failure()
    {
        // Arrange
        var context = new FakeDbContextFactory();

        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await ProductService.DeleteProductAsync(0);

        // Assert
        Assert.False(res.Data);
    }
}
