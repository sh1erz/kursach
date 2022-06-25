using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCreator.Models;
using static TestCreator.IO.FileReader;

namespace TestCreator;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        // var r = new Random();
        //
        // Console.WriteLine("Sentence 1");
        // var sentence1VariantsDict = await ReadVariantsFromJsonFile("sentence1");
        // var sentence1VariablesDict = await ReadVariantsFromJsonFile("sentence1");
        // var sentence1Parts = new List<string>();
        //
        // foreach (var part in sentence1VariantsDict)
        // {
        //     var values = part.Value;
        //     var randInt = r.Next(values.Count);
        //     
        //     var selectedVariant = values[randInt];
        //     string.Format(selectedVariant,)
        //     sentence1Parts.Add(selectedVariant);
        // }

        var product = "product111";
        var price = "333";
        var arr = new[] { product, price };
        var str1 = "name of pr is {Product}";
        var str2 = "price for {Product} is {Price}";

        str1 = string.Format(str1, arr);
        str2 = string.Format(str2, arr);
        Console.WriteLine(str1);

    }
}