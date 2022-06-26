using System;
using System.Collections.Generic;
using TestCreator.Models;

namespace TestCreator.SentenceGenerator;

public class VariableProvider
{
    //Variables
    
    public string ProductionName { get; } //0
    public string Production1 { get; } //1
    public string Production2 { get; } //2
    public string Resource1 { get; } //3 
    public string Resource2 { get; } //4
    public string Expenses { get; } //5

    public bool IsPositive { get; } = new Random().Next(2) == 0;

    public VariableProvider(VariableVariants? variableVariants)
    {
        var nameToRes = ChooseAndRemove(variableVariants.NameToResources);
        ProductionName = nameToRes.ProductName;
        Resource1 = ChooseAndRemove(nameToRes.Resources);
        Resource2 = ChooseAndRemove(nameToRes.Resources);

        var productions = ChooseAndRemove(variableVariants.Production).Split();
        Production1 = productions[0];
        Production2 = productions[1];

        Expenses = ChooseAndRemove(variableVariants.Expenses);
    }

    private static T ChooseAndRemove<T>(List<T> list)
    {
        var index = new Random().Next(list.Count);
        var value = list[index];
        list.RemoveAt(index);
        return value;
    }

    public List<string> GetAsList()
    {
        return new List<string> { };
    }
}