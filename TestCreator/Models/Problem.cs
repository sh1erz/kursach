namespace TestCreator.Models;

public class Problem
{
    public string ProblemString { get; }
    public MathModel MathModel { get; }

    public Problem(string problemDescription, MathModel mathModel)
    {
        ProblemString = problemDescription;
        MathModel = mathModel;
    }
}