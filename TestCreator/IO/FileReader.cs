using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TestCreator.Models;

namespace TestCreator.IO;

public static class FileReader
{
    public static async Task<string[]> ReadTextFromFile(string filename)
    {
        return await File.ReadAllLinesAsync("Json/" + filename);
    }

    public static async Task<T> ReadFromJsonFile<T>(string filename)
    {
        using var r = new StreamReader("Json/" + filename);
        var json = await r.ReadToEndAsync();
        var variants = JsonSerializer.Deserialize<T>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return variants;
    }
}