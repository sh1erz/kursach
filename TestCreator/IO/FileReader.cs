using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestCreator.IO;

public static class FileReader
{
    public static async Task<string[]> ReadTextFromFile(string filename)
    {
        return await File.ReadAllLinesAsync(filename);
    }
    
    public static async Task<Dictionary<string, List<string>>?> ReadVariantsFromJsonFile(string filename)
    {
        using var r = new StreamReader(filename);
        var json = await r.ReadToEndAsync();
        var variants = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(json);
        return variants;
    }
    
    public static async Task<Dictionary<string, string>> ReadVariablesFromJsonFile(string filename)
    {
        using var r = new StreamReader(filename);
        var json = await r.ReadToEndAsync();
        var variants = JsonSerializer.Deserialize<Dictionary<string,string>>(json);
        return variants;
    }
}