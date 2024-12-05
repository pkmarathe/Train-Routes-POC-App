public class Program
{
    public static void Main(string[] args)
    {
        // Create the graph
        var graph = new Graph();


        string currentDirectory = Directory.GetCurrentDirectory();

        string projectDirectory = Directory.GetParent(Directory.GetParent(currentDirectory).Parent.FullName).Parent.FullName;

        // Step 3: Combine the project directory with the relative file path
        string filePath = Path.Combine(projectDirectory, "Input.txt");

        var fileReader = new FileReader();
        var routes = fileReader.ReadFile(filePath);

        // Parse the input file and populate the graph
        foreach (var route in routes)
        {
          
            var parts = route.Split(',');
            var fromTown = parts[0].Trim();
            var toTown = parts[1].Trim();
            var distance = int.Parse(parts[2].Trim());

            graph.AddTown(fromTown);
            graph.AddTown(toTown);

            graph.AddRoute(fromTown, toTown, distance);
        }

        // Initialize RouteFinder
        var routeFinder = new RouteFinder(graph);

        // Run tests
        var testRunner = new TestRunner(routeFinder);
        testRunner.RunTests();
    }
}
