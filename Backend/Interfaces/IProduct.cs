namespace Backend.Interfaces
{
    public interface IProduct
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
        List<string>? Review { get; set; }
        List<string> Size { get; set; }
        List<string> Tags { get; set; }
    }
}