namespace Domain.DTOS.ProductDto;

public class GetProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? PathPhoto { get; set; }
}
