public class FileReader
{
    public List<string> ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file '{filePath}' was not found.");
        }

        var routes = new List<string>();
        foreach (var line in File.ReadLines(filePath))
        {
            routes.Add(line);
        }
        return routes;
    }
}
