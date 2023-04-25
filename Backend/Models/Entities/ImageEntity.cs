namespace Backend.Models.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string Source { get; set; } = null!;
        public string Alt { get; set; } = null!;
    }
}
