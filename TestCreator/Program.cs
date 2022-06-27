using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCreator.Generators;
using TestCreator.Models;
using static TestCreator.IO.FileReader;

namespace TestCreator;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var variableVariants = await ReadFromJsonFile<VariableVariants>("variables.json");
        var variableProvider = new VariableProvider(variableVariants);

        var sentenceVariants = new List<Dictionary<string, List<string>>>();
        for (int i = 0; i < Sentences; i++)
        {
            var sentenceVariantsDict = await ReadFromJsonFile<Dictionary<string, List<string>>>($"sentence{i + 1}.json");
            sentenceVariants.Add(sentenceVariantsDict);
        }

        var task = SentenceGenerator.GenerateSentences();
        Console.WriteLine(task);
    }

    public const int Sentences = 4;
}