using System.Collections.Generic;

namespace TestCreator.Models;

public class VariableVariants
{
    public List<NameToResources> NameToResources { get; }
    public List<string> Production { get; }
    public List<string> ExpensesVariable { get; }

    public VariableVariants(List<NameToResources> nameToResources, List<string> production,
        List<string> expensesVariable)
    {
        NameToResources = nameToResources;
        Production = production;
        ExpensesVariable = expensesVariable;
    }
}