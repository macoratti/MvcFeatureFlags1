namespace MvcFeatureFlags.Models;
public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public decimal Discount { get; set; } = 5.0m;
    public string? Image {  get; set; }
    public double Stock { get; set; } = 1.0d;
    public bool IsActive { get; set; } = true;
}
