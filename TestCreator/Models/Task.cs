namespace TestCreator.Models;

public class Task
{
    public string TaskStr { get; }
    public MathModel MathModel { get; }

    public Task(string task, MathModel mathModel)
    {
        TaskStr = task;
        MathModel = mathModel;
    }
}