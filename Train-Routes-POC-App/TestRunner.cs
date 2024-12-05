using System;
using System.Collections.Generic;

public class TestRunner
{
    private RouteFinder routeFinder;

    public TestRunner(RouteFinder routeFinder)
    {
        this.routeFinder = routeFinder;
    }

    public void RunTests()
    {
        // Test #1: The distance of the route A=>B=>C is 9
        var route1 = new List<string> { "A", "B", "C" };
        Console.WriteLine($"Test #1: Distance of A=>B=>C is {routeFinder.CalculateRouteDistance(route1)}");

        // Test #2: The distance of the route A=>D is 5
        var route2 = new List<string> { "A", "D" };
        Console.WriteLine($"Test #2: Distance of A=>D is {routeFinder.CalculateRouteDistance(route2)}");

        // Test #3: The distance of the route A=>D=>C is 13
        var route3 = new List<string> { "A", "D", "C" };
        Console.WriteLine($"Test #3: Distance of A=>D=>C is {routeFinder.CalculateRouteDistance(route3)}");

        // Test #4: The distance of the route A=>E=>B=>C=>D is 22
        var route4 = new List<string> { "A", "E", "B", "C", "D" };
        Console.WriteLine($"Test #4: Distance of A=>E=>B=>C=>D is {routeFinder.CalculateRouteDistance(route4)}");

        // Test #5: Route A=>E=>D doesn't exist
        var route5 = new List<string> { "A", "E", "D" };
        Console.WriteLine($"Test #5: Distance of A=>E=>D is {routeFinder.CalculateRouteDistance(route5)}");

        // Test #6: Number of trips from C to C with maximum 3 stops is 2
        Console.WriteLine($"Test #6: Number of trips from C to C with max 3 stops is {routeFinder.CountTrips("C", "C", 3)}");

        // Test #7: Number of trips from A to C with exactly 4 stops is 3
        Console.WriteLine($"Test #7: Number of trips from A to C with exactly 4 stops is {routeFinder.CountTrips("A", "C", 4)}");

        // Test #8: The length of the shortest route from A to C is 9
        Console.WriteLine($"Test #8: Shortest route from A to C is {routeFinder.FindShortestRoute("A", "C")}");

        // Test #9: The length of the shortest route from B to B is 9
        Console.WriteLine($"Test #9: Shortest route from B to B is {routeFinder.FindShortestRoute("B", "B")}");

        // Test #10: The number of trips from C to C with distance less than 30 is 7
        Console.WriteLine($"Test #10: Number of trips from C to C with distance < 30 is {routeFinder.CountTrips("C", "C", 5)}");
    }
}
