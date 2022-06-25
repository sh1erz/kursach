using System.Collections.Generic;
using System.Linq;

namespace TestCreator.Models;

public class Sentence
{
    public string ResultSentence { get; set; }

    public Sentence(List<SentencePart> parts)
    {
        ResultSentence = string.Join(" ", parts);
    }
}