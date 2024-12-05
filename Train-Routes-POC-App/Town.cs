public class Town
{
    public string Name { get; }
    public List<Route> Routes { get; }

    public Town(string name)
    {
        Name = name;
        Routes = new List<Route>();
    }

    public void AddRoute(Route route)
    {
        Routes.Add(route);
    }
}
