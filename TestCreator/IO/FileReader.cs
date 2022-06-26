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

    public static async Task<Dictionary<string, List<string>>?> ReadVariantsFromJsonFile(string filename)
    {
        using var r = new StreamReader("Json/" + filename);
        var json = await r.ReadToEndAsync();
        var variants = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return variants;
    }

    public static async Task<VariableVariants?> ReadVariablesFromJsonFile(string filename)
    {
        using var r = new StreamReader("Json/" + filename);
        var json = await r.ReadToEndAsync();
        var variants = JsonSerializer.Deserialize<VariableVariants>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return variants;
    }
}