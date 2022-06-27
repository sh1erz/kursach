using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCreator.Generators;
using static TestCreator.IO.FileReader;

namespace TestCreator;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var variableVariants = await ReadVariablesFromJsonFile("variables.json");

        var sentenceVariants = new List<Dictionary<string, List<string>>>();
        for (int i = 0; i < Sentences; i++)
        {
            var sentenceVariantsDict = await ReadVariantsFromJsonFile($"sentence{i + 1}.json");
            sentenceVariants.Add(sentenceVariantsDict);
        }

        var variableProvider = new VariableProvider(variableVariants);
        var generator = new SentenceGenerator(variableProvider);

        Console.WriteLine(generator.GenerateSentences(sentenceVariants));
        Console.WriteLine(generator.PrintMathModel());
    }

    public const int Sentences = 4;
}