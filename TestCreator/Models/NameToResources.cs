namespace TestCreator.Models;

public class NameToResources
{
    public string ProductName { get; }
    public string Resources { get; }

    public NameToResources(string productName, string resources)
    {
        ProductName = productName;
        Resources = resources;
    }
}