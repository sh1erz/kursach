using System.Collections.Generic;

namespace TestCreator.Models;

public class VariableVariants
{
    public List<NameToResources> NameToResources { get; }
    public List<string> Production { get; }
    public List<string> Expenses { get; }

    public VariableVariants(List<NameToResources> nameToResources, List<string> production,
        List<string> expenses)
    {
        NameToResources = nameToResources;
        Production = production;
        Expenses = expenses;
    }
}