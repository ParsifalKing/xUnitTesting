using Infrastructure.Services.FileService;
using Infrastructure.Services.ProductService;
using Moq;
using xUnitApp.FakeDbContext;
namespace xUnitApp.TestServices.TestProductMethods;

public class GetById
{
    [Fact]
    public async Task GetById_ProductService_Success()
    {
        const int id = 1;

        // Arrange
        var context = new FakeDbContextFactory();

        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await ProductService.GetProductByIdAsync(id);

        // Assert
        Assert.Equal(200, res.StatusCode);
    }

    [Fact]
    public async Task GetById_ProductService_Failure()
    {
        // Arrange
        var context = new FakeDbContextFactory();

        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var res = await ProductService.GetProductByIdAsync(0);

        // Assert
        Assert.Equal(400, res.StatusCode);
    }

}
