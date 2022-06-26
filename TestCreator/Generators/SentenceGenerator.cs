using System;
using System.Collections.Generic;

namespace TestCreator.Generators;

public class SentenceGenerator
{

    private VariableProvider _variableProvider { get; }

    public SentenceGenerator(VariableProvider variableProvider)
    {
        _variableProvider = variableProvider;
    }

    public string GenerateSentence1()
    {
        
    }
    
    public string GenerateSentences(
        List<Dictionary<string, List<string>>> sentencesPartsVariants)
    {
        var r = new Random();
        var sentences = new List<string>();
        foreach (var sentencePartsVariants in sentencesPartsVariants)
        {
            // for one sentence
            var sentenceParts = new List<string>();
            foreach (var part in sentencePartsVariants)
            {
                var values = part.Value;
                var randInt = r.Next(values.Count);
                var variables = _variableProvider
                    .ToList();
                variables.Add(r.Next(RandLowerBound, RandUpperBound).ToString());
                var selectedVariant = values[randInt];
                selectedVariant = string.Format(
                    selectedVariant,
                    variables.ToArray());
                sentenceParts.Add(selectedVariant);
            }

            sentences.Add(string.Join(" ", sentenceParts));
        }

        return string.Join(" ", sentences);
    }

    public const int RandLowerBound = 10;
    public const int RandUpperBound = 40;
}