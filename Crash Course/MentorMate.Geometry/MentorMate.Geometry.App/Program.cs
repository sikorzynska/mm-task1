using MentorMate.Geometry.Models.Models;

public static class Program
{
    public static async Task Main()
    {
        var path = Path.Combine("logs.txt");

        using StreamWriter file = new (path);

        Shape triangle = new Triangle(5, 6, 7);

        var trianglePerimeter = triangle.CalculatePerimeter();
        var triangleSurface = triangle.CalculateSurface();

        var perimeterMessage = $"Perimeter is: {trianglePerimeter}";
        var surfaceMessage = $"Surface is: {triangleSurface}";

        await file.WriteLineAsync(perimeterMessage);
        await file.WriteLineAsync(surfaceMessage);

        Console.WriteLine(perimeterMessage);
        Console.WriteLine(surfaceMessage);
    }
}
