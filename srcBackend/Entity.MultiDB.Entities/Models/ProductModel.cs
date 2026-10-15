
namespace Entity.MultiDB.Entities.Models;

public class ProductModel
{
    public Guid ProductId { get; set; } = Guid.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string BaseUnit { get; set; } = string.Empty;
    public string ProductType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
