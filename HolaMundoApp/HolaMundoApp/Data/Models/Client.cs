namespace HolaMundoApp.Data.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Dna { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }


    }
}
