using Domain.Filters;
using Infrastructure.Services.FileService;
using Infrastructure.Services.ProductService;
using Moq;
using xUnitApp.FakeDbContext;

namespace xUnitApp.TestServices.TestProductMethods;

public class GetAll
{
    [Fact]
    public async Task GetAll_ProductService_Success()
    {
        // Arrange
        var context = new FakeDbContextFactory();

        var file = new Mock<IFileService>();
        var ProductService = new ProductService(context.DbContextFactory(), file.Object);
        // Act
        var filter = new ProductFilter();
        var res = await ProductService.GetProductsAsync(filter);

        // Assert
        Assert.NotNull(res.Data);
        Assert.Equal(200, res.StatusCode);
    }


}
