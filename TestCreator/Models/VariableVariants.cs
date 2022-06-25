using System.Collections.Generic;

namespace TestCreator.Models;

public class VariableVariants
{
    public List<NameToResources> ProductToResources { get; }
    public List<NameToResources> Production { get; }
    public List<NameToResources> ExpensesVariable { get; }

    public VariableVariants(List<NameToResources> productToResources, List<NameToResources> production,
        List<NameToResources> expensesVariable)
    {
        ProductToResources = productToResources;
        Production = production;
        ExpensesVariable = expensesVariable;
    }
}