
using System;
using Google.Cloud.Language.V1;

namespace NaturalLanguageApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "It's going alright, not too bad not too good.";
            var client = LanguageServiceClient.Create();
            var response = client.AnalyzeSentiment(Document.FromPlainText(text));
            var sentiment = response.DocumentSentiment;
            Console.WriteLine($"Score: {sentiment.Score}");
            Console.WriteLine($"Magnitude: {sentiment.Magnitude}");
        }
    }
}