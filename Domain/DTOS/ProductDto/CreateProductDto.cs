using Microsoft.AspNetCore.Http;

namespace Domain.DTOS.ProductDto;

public class CreateProductDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public IFormFile? PathPhoto { get; set; }
}
