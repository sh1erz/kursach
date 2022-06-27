using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestCreator.IO;

// ReSharper disable once InconsistentNaming
public static class FileIO
{
    public static async Task<T> ReadFromJsonFile<T>(string filename)
    {
        using var r = new StreamReader("Json/" + filename);
        var json = await r.ReadToEndAsync();
        var variants = JsonSerializer.Deserialize<T>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return variants;
    }

    public static async Task WriteToTextFile(string output)
    {
        await using StreamWriter file = new("Problems.txt", true);
        var formattedOutput = output + "\n\n";
        await file.WriteAsync(formattedOutput);
    }
}