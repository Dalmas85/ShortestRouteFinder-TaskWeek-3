public class Route
{
    public string StartingPoint { get; set; }
    public string Destination { get; set; }
    public double Distance { get; set; }

    public Route(string startingPoint, string destination, double distance)
    {
        StartingPoint = startingPoint;
        Destination = destination;
        Distance = distance;

    }
}
