using System;
using System.Collections.Generic;
using TestCreator.Models;

namespace TestCreator.SentenceGenerator;

public class VariableProvider
{
    //Variables
    private string ProductionName { get; }
    private string Production1 { get; }
    private string Production2 { get; }
    private string Resource1 { get; }
    private string Resource2 { get; }

    private bool IsPositive { get; } = new Random().Next(2) == 0;
    private string Expenses { get; }

    public VariableProvider(VariableVariants variableVariants)
    {
        var nameToRes = ChooseAndRemove(variableVariants.NameToResources);
        ProductionName = nameToRes.ProductName;
        Resource1 = ChooseAndRemove(nameToRes.Resources);
        Resource2 = ChooseAndRemove(nameToRes.Resources);

        var productions = ChooseAndRemove(variableVariants.Production).Split();
        Production1 = productions[0];
        Production2 = productions[1];

        Expenses = ChooseAndRemove(variableVariants.ExpensesVariable);
    }

    private static T ChooseAndRemove<T>(List<T> list)
    {
        var index = new Random().Next(list.Count);
        var value = list[index];
        list.RemoveAt(index);
        return value;
    }
}