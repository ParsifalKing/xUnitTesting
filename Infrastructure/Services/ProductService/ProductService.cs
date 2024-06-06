using System.Net;
using Domain.DTOS.ProductDto;
using Domain.Entities;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Services.FileService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.ProductService;

public class ProductService(DataContext context, IFileService fileService) : IProductService
{
    #region GetProductsAsync

    public async Task<PagedResponse<List<GetProductDto>>> GetProductsAsync(ProductFilter filter)
    {
        try
        {
            var Products = context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                Products = Products.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));


            var response = await Products.Select(x => new GetProductDto()
            {
                Name = x.Name,
                Price = x.Price,
                PathPhoto = x.PathPhoto,
                Id = x.Id,
            }).Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            var totalRecord = await Products.CountAsync();

            return new PagedResponse<List<GetProductDto>>(response, totalRecord, filter.PageNumber, filter.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<GetProductDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region GetProductByIdAsync

    public async Task<Response<GetProductDto>> GetProductByIdAsync(int ProductId)
    {
        try
        {
            var existing = await context.Products.FirstOrDefaultAsync(x => x.Id == ProductId);
            if (existing == null) return new Response<GetProductDto>(HttpStatusCode.BadRequest, "Not Found");
            var response = new GetProductDto()
            {
                Name = existing.Name,
                Price = existing.Price,
                PathPhoto = existing.PathPhoto,
                Id = existing.Id,
            };
            return new Response<GetProductDto>(response);
        }
        catch (Exception e)
        {
            return new Response<GetProductDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region CreateProductAsync

    public async Task<Response<string>> CreateProductAsync(CreateProductDto createProduct)
    {
        try
        {
            if (createProduct == null)
            {
                return new Response<string>(HttpStatusCode.BadRequest, "product coming null");
            }

            var Product = new Product()
            {
                Name = createProduct.Name,
                Price = createProduct.Price,
            };
            if (createProduct.PathPhoto != null) Product.PathPhoto = await fileService.CreateFile(createProduct.PathPhoto);

            await context.Products.AddAsync(Product);
            await context.SaveChangesAsync();
            return new Response<string>("Successfully created Product");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }



    #endregion

    #region UpdateProductAsync

    public async Task<Response<string>> UpdateProductAsync(UpdateProductDto updateProduct)
    {
        try
        {

            var existingProduct = await context.Products.FirstOrDefaultAsync(x => x.Id == updateProduct.Id);
            if (existingProduct == null) return new Response<string>(HttpStatusCode.BadRequest, "Product not found");

            if (updateProduct.PathPhoto != null)
            {
                if (existingProduct.PathPhoto != null) fileService.DeleteFile(existingProduct.PathPhoto);
                existingProduct.PathPhoto = await fileService.CreateFile(updateProduct.PathPhoto);
            }

            existingProduct.Name = updateProduct.Name;
            existingProduct.Price = updateProduct.Price;
            if (updateProduct.PathPhoto != null)
                existingProduct.PathPhoto = await fileService.CreateFile(updateProduct.PathPhoto);

            await context.SaveChangesAsync();
            return new Response<string>("Successfully updated the Product");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region DeleteProductAsync

    public async Task<Response<bool>> DeleteProductAsync(int ProductId)
    {
        try
        {

            var existing = await context.Products.FirstOrDefaultAsync(x => x.Id == ProductId);
            if (existing == null) return new Response<bool>(HttpStatusCode.BadRequest, "Not Found");
            if (existing.PathPhoto != null) fileService.DeleteFile(existing.PathPhoto);
            context.Products.Remove(existing);
            await context.SaveChangesAsync();
            return new Response<bool>(true);

        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion
}
