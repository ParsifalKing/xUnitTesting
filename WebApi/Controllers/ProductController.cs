using Domain.DTOS.ProductDto;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService ProductService) : ControllerBase
{

    [HttpPost]
    public async Task<Response<string>> CreateProductAsync(CreateProductDto createProduct)
       => await ProductService.CreateProductAsync(createProduct);


    [HttpGet]
    public async Task<Response<List<GetProductDto>>> GetProductsAsync([FromQuery] ProductFilter ProductFilter)
        => await ProductService.GetProductsAsync(ProductFilter);

    [HttpGet("{ProductId:int}")]
    public async Task<Response<GetProductDto>> GetProductByIdAsync(int ProductId)
        => await ProductService.GetProductByIdAsync(ProductId);

    [HttpPut("update")]
    public async Task<Response<string>> UpdateProductAsync(UpdateProductDto Product)
        => await ProductService.UpdateProductAsync(Product);

    [HttpDelete("{ProductId:int}")]
    public async Task<Response<bool>> DeleteProductAsync(int ProductId)
        => await ProductService.DeleteProductAsync(ProductId);
}