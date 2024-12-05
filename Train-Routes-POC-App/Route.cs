public class Route
{
    public Town From { get; }
    public Town To { get; }
    public int Distance { get; }

    public Route(Town from, Town to, int distance)
    {
        From = from;
        To = to;
        Distance = distance;
    }
}
