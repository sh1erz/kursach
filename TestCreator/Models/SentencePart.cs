namespace TestCreator.Models;

public class SentencePart
{
    public string Part { get; set; }

    public SentencePart(string str, params object?[] args)
    {
        Part = string.Format(str, args);
    }
}