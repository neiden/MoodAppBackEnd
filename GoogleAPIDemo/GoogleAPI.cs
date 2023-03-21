
using System;
using Google.Cloud.Language.V1;

namespace NaturalLanguageApi;

public class GoogleAPI
{
    public static double AnalyzeSentiment(string text)
    {
        var client = LanguageServiceClient.Create();
        var response = client.AnalyzeSentiment(Document.FromPlainText(text));
        var sentiment = response.DocumentSentiment;
        //Console.WriteLine($"Score: {sentiment.Score}");
        //Console.WriteLine($"Magnitude: {sentiment.Magnitude}");
        return sentiment.Score;
    }
}