using System.Collections.Generic;
using TestCreator.Generators;
using TestCreator.IO;
using TestCreator.Models;
using Task = System.Threading.Tasks.Task;

namespace TestCreator;

internal static class Program
{
    private const int Sentences = 4;

    public static async Task Main()
    {
        for (int z = 0; z < 100; z++)
        {
            var variableVariants = await FileIO.ReadFromJsonFile<VariableVariants>("variables.json");
            var variableProvider = new VariableProvider(variableVariants);

            var sentenceVariants = new List<Dictionary<string, List<string>>>();
            for (var i = 0; i < Sentences; i++)
            {
                var sentenceVariantsDict =
                    await FileIO.ReadFromJsonFile<Dictionary<string, List<string>>>($"sentence{i + 1}.json");
                sentenceVariants.Add(sentenceVariantsDict);
            }

            var generator = new SentenceGenerator(variableProvider);
            var problemDescription = generator.FormatSentences(sentenceVariants);
            var mathModel = generator.FormatMathModel();

            await FileIO.WriteToTextFile(problemDescription);
            await FileIO.WriteToTextFile(mathModel);
        }
    }
}