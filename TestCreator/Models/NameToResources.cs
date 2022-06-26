using System.Collections.Generic;

namespace TestCreator.Models;

public class NameToResources
{
    public string ProductionName { get; }
    public List<string> Resources { get; }

    public NameToResources(string productionName, List<string> resources)
    {
        ProductionName = productionName;
        Resources = resources;
    }
}