using System.IO;
using System.Text.Json;

public class JsonDeckPersistence : IDeckPersistence
{
    public void Save(Deck deck, string filePath)
    {
        string json = JsonSerializer.Serialize(deck.Cards);
        File.WriteAllText(filePath, json);
    }

    public Deck Load(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The JSON file does not exist.");

        string json = File.ReadAllText(filePath);
        var cards = JsonSerializer.Deserialize<List<Card>>(json);
        Deck deck = new Deck();
        foreach (var card in cards)
        {
            deck.AddCard(card);
        }
        return deck;
    }
}