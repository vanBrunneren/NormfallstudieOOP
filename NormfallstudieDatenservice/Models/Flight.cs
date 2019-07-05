namespace NormfallstudieDatenservice.Models
{
    public class Flight
    {
        public Destination StartDestination { get; set; }
        public Destination EndDestination { get; set; }
        public string Date { get; set; }
        public int EmptyPlaces { get; set; }
    }
}