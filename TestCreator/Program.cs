using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCreator.SentenceGenerator;
using static TestCreator.IO.FileReader;

namespace TestCreator;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var r = new Random();
        var variableVariants = await ReadVariablesFromJsonFile("variables.json");
        var variableProvider = new VariableProvider(variableVariants);

        Console.WriteLine("Sentence 1");
        var sentence1VariantsDict = await ReadVariantsFromJsonFile("sentence1.json");
        var sentence1Parts = new List<string>();

        foreach (var part in sentence1VariantsDict)
        {
            var values = part.Value;
            var randInt = r.Next(values.Count);

            var selectedVariant = values[randInt];
            selectedVariant = string.Format(selectedVariant, variableProvider.Expenses);
            sentence1Parts.Add(selectedVariant);
        }
    }
}