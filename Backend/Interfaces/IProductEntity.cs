namespace Backend.Interfaces
{
    public interface IProductEntity
    {
        string Category { get; set; }
        string? Color { get; set; }
        string? Description { get; set; }
        string? Gender { get; set; }
        Guid Id { get; set; }
        string? ImageName { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        float? RatingStar { get; set; }
        List<string> Size { get; set; }
        string? Specification { get; set; }
        List<string> Tags { get; set; }
    }
}