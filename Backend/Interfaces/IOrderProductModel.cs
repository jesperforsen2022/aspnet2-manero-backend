namespace Backend.Interfaces
{
    public interface IOrderProductModel
    {
        string? Color { get; set; }
        string? Description { get; set; }
        string? Gender { get; set; }
        Guid Id { get; set; }
        string? Name { get; set; }
        decimal? Price { get; set; }
        decimal? Quantity { get; set; }
        string? Size { get; set; }
    }
}