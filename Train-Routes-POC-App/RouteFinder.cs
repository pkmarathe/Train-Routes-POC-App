public class RouteFinder
{
    private Graph graph;

    public RouteFinder(Graph graph)
    {
        this.graph = graph;
    }

    // Method to calculate the distance of a route
    public int CalculateRouteDistance(List<string> route)
    {
        int distance = 0;
        for (int i = 0; i < route.Count - 1; i++)
        {
            var fromTown = graph.GetTown(route[i]);
            var toTown = graph.GetTown(route[i + 1]);

            var routeDistance = fromTown.Routes.FirstOrDefault(r => r.To == toTown)?.Distance;

            if (routeDistance == null) return -1; // Return -1 for non-existent route
            distance += routeDistance.Value;
        }
        return distance;
    }

    // Method to find the shortest route using Dijkstra's Algorithm
    public int FindShortestRoute(string from, string to)
    {
        var distances = new Dictionary<string, int>();
        var priorityQueue = new PriorityQueue<string, int>();

        foreach (var town in graph.GetTowns())
        {
            distances[town.Name] = int.MaxValue;
        }
        distances[from] = 0;
        priorityQueue.Enqueue(from, 0);

        while (priorityQueue.Count > 0)
        {
            var currentTown = priorityQueue.Dequeue();

            foreach (var route in graph.GetTown(currentTown).Routes)
            {
                var newDist = distances[currentTown] + route.Distance;
                if (newDist < distances[route.To.Name])
                {
                    distances[route.To.Name] = newDist;
                    priorityQueue.Enqueue(route.To.Name, newDist);
                }
            }
        }

        return distances[to] == int.MaxValue ? -1 : distances[to];
    }

    // Method to count trips with a maximum number of stops
    public int CountTrips(string from, string to, int maxStops)
    {
        var trips = new List<List<string>>();
        FindTrips(from, to, maxStops, new List<string> { from }, trips);
        return trips.Count;
    }

    private void FindTrips(string currentTown, string toTown, int maxStops, List<string> currentRoute, List<List<string>> trips)
    {
        if (currentRoute.Count > maxStops + 1) return;

        if (currentTown == toTown && currentRoute.Count <= maxStops + 1)
        {
            trips.Add(new List<string>(currentRoute));
        }

        foreach (var route in graph.GetTown(currentTown).Routes)
        {
            currentRoute.Add(route.To.Name);
            FindTrips(route.To.Name, toTown, maxStops, currentRoute, trips);
            currentRoute.RemoveAt(currentRoute.Count - 1);
        }
    }
}
