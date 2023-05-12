namespace Backend.Interfaces
{
    public interface ICreditCard 
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvvCode { get; set; }
    }
}
