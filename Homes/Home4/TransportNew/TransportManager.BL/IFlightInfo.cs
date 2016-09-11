namespace TransportManager.BL
{
    public interface IFlightInfo
    {
        string Type { get; }
        string FlightNumber { get; set; }
        string Departure { get; set; }
        string Destination { get; set; }
    }
}