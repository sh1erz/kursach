using System.Collections.Generic;

namespace TestCreator.Models;

public class NameToResources
{
    public string ProductName { get; }
    public List<string> Resources { get; }

    public NameToResources(string productName, List<string> resources)
    {
        ProductName = productName;
        Resources = resources;
    }
}