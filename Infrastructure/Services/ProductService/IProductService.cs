using Domain.DTOS.ProductDto;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    Task<PagedResponse<List<GetProductDto>>> GetProductsAsync(ProductFilter filter);
    Task<Response<GetProductDto>> GetProductByIdAsync(int ProductId);
    Task<Response<string>> CreateProductAsync(CreateProductDto createProduct);
    Task<Response<string>> UpdateProductAsync(UpdateProductDto updateProduct);
    Task<Response<bool>> DeleteProductAsync(int ProductId);
}
