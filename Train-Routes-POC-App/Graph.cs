public class Graph
{
    private Dictionary<string, Town> towns = new Dictionary<string, Town>();

    // Add a town to the graph
    public void AddTown(string townName)
    {
        if (!towns.ContainsKey(townName))
        {
            towns[townName] = new Town(townName);
        }
    }

    // Add a route between two towns
    public void AddRoute(string fromTown, string toTown, int distance)
    {
        var from = towns[fromTown];
        var to = towns[toTown];
        var route = new Route(from, to, distance);
        from.AddRoute(route);
    }

    // Get a town by name
    public Town GetTown(string name)
    {
        return towns.ContainsKey(name) ? towns[name] : null;
    }

    // Get all towns in the graph
    public IEnumerable<Town> GetTowns()
    {
        return towns.Values;
    }
}
