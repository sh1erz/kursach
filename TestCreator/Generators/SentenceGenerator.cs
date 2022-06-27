using System;
using System.Collections.Generic;
using System.Linq;
using TestCreator.Models;

namespace TestCreator.Generators;

public class SentenceGenerator
{
    public const int RandLowerBound = 10;
    public const int RandUpperBound = 40;

    private VariableProvider _variableProvider { get; }

    private MathModel MathModel { get; } = new();

    public SentenceGenerator(VariableProvider variableProvider)
    {
        _variableProvider = variableProvider;
    }

    //**Generates variables x1, x2**//
    private string GenerateSentence1(Dictionary<string, List<string>> sentenceParts)
    {
        MathModel.X1 =
            $"х1 - кількість {_variableProvider.ProductionName} типу {_variableProvider.Production1}";
        MathModel.X2 =
            $"х2 - кількість {_variableProvider.ProductionName} типу {_variableProvider.Production2}";

        return ConstructSentence(sentenceParts, _variableProvider.ToList());
    }

    //**Generates coefficients for constraints
    //k1x1 + k2x2 (<>=) res1
    //k3x1 + k4x2 (<>=) res2**//
    private string GenerateSentence2(Dictionary<string, List<string>> sentenceParts)
    {
        var variables = _variableProvider.ToList();
        var r = new Random();
        var ks = new List<string>();
        for (var i = 0; i < 4; i++)
        {
            var k = r.Next(RandLowerBound, RandUpperBound);
            ks.Add(k.ToString());
            variables.Add(k.ToString());
        }

        MathModel.Constraint1 = string.Format("{0}x1 + {1}x2 ", ks.ToArray());
        MathModel.Constraint2 = string.Format("{2}x1 + {3}x2 ", ks.ToArray());
        return ConstructSentence(sentenceParts, variables);
    }

    //**Generates sign and value for constraints**//

    private string GenerateSentence3(Dictionary<string, List<string>> sentenceParts)
    {
        var r = new Random();
        //<=, >=, =
        var sign1 = r.Next(3);
        var sign2 = r.Next(3);
        var unusedSigns1 = new List<string>();
        var unusedSigns2 = new List<string>();
        switch (sign1)
        {
            //<=
            case 0:
                MathModel.Constraint1 += "<= ";
                unusedSigns1.Add("2 (>=)");
                unusedSigns1.Add("2 (=)");
                break;
            //>=
            case 1:
                MathModel.Constraint1 += ">= ";
                unusedSigns1.Add("2 (<=)");
                unusedSigns1.Add("2 (=)");
                break;
            //=
            case 2:
                MathModel.Constraint1 += "= ";
                unusedSigns1.Add("2 (>=)");
                unusedSigns1.Add("2 (<=)");
                break;
        }

        switch (sign2)
        {
            //<=
            case 0:
                MathModel.Constraint2 += "<= ";
                unusedSigns2.Add("4 (>=)");
                unusedSigns2.Add("4 (=)");
                break;
            //>=
            case 1:
                MathModel.Constraint2 += ">= ";
                unusedSigns2.Add("4 (<=)");
                unusedSigns2.Add("4 (=)");
                break;
            //=
            case 2:
                MathModel.Constraint2 += "= ";
                unusedSigns2.Add("4 (>=)");
                unusedSigns2.Add("4 (<=)");
                break;
        }

        //extract from 2 and 4 part
        sentenceParts = sentenceParts.Where(x =>
                !(x.Key.Contains(unusedSigns1[0]) || x.Key.Contains(unusedSigns1[1]) ||
                  x.Key.Contains(unusedSigns2[0]) || x.Key.Contains(unusedSigns2[1])))
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        //generate numbers
        var variables = _variableProvider.ToList();

        var res1 = r.Next(RandLowerBound, RandUpperBound);
        var res2 = r.Next(RandLowerBound, RandUpperBound);
        variables.Add(res1.ToString());
        variables.Add(res2.ToString());
        MathModel.Constraint1 += res1;
        MathModel.Constraint2 += res2;

        return ConstructSentence(sentenceParts, variables);
    }

    //**Generates target function**//
    private string GenerateSentence4(Dictionary<string, List<string>> sentenceParts)
    {
        //min/max z = k1x1 , k2x2
        var zf = _variableProvider.IsPositive ? "max" : "min";
        if (_variableProvider.IsPositive)
            sentenceParts = sentenceParts.Where(x => !x.Key.Contains("false")).ToDictionary(pair => pair.Key,
                pair => pair.Value);
        else
            sentenceParts = sentenceParts.Where(x => !x.Key.Contains("true")).ToDictionary(pair => pair.Key,
                pair => pair.Value);

        var r = new Random();
        var k1 = r.Next(RandLowerBound, RandUpperBound);
        var k2 = r.Next(RandLowerBound, RandUpperBound);
        var variables = _variableProvider.ToList();
        variables.Add(k1.ToString());
        variables.Add(k2.ToString());
        MathModel.TargetFunction = $"{zf} z= {k1}x1 + {k2}x2";
        return ConstructSentence(sentenceParts, variables);
    }

    private string ConstructSentence(Dictionary<string, List<string>> sentencePartsDictionary, List<string> variables)
    {
        var parts = new List<string>();
        foreach (var part in sentencePartsDictionary)
        {
            var values = part.Value;
            var randInt = new Random().Next(values.Count);
            var selectedVariant = values[randInt];
            selectedVariant = string.Format(selectedVariant, variables.ToArray());
            parts.Add(selectedVariant);
        }

        return string.Join(" ", parts);
    }

    public string FormatSentences(
        List<Dictionary<string, List<string>>> sentencesPartsVariants)
    {
        var sentences = new List<string>();

        sentences.Add(GenerateSentence1(sentencesPartsVariants[0]));
        sentences.Add(GenerateSentence2(sentencesPartsVariants[1]));
        sentences.Add(GenerateSentence3(sentencesPartsVariants[2]));
        sentences.Add(GenerateSentence4(sentencesPartsVariants[3]));

        return string.Join(" ", sentences);
    }

    public string FormatMathModel()
    {
        return
            $"{MathModel.X1},\n{MathModel.X2}\n{MathModel.Constraint1}\n{MathModel.Constraint2}\n{MathModel.TargetFunction}";
    }
}