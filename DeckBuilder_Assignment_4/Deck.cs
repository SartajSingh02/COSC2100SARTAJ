using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Deck
{
    protected List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public Card Deal()
    {
        if (cards.Count == 0) throw new InvalidOperationException("No cards left in the deck.");
        Card topCard = cards[0];
        cards.RemoveAt(0);
        return topCard;
    }

    public List<Card> Cards => new List<Card>(cards); // Returns a copy of the cards list

    public void Shuffle()
    {
        Random rng = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            int k = rng.Next(n--);
            var temp = cards[n];
            cards[n] = cards[k];
            cards[k] = temp;
        }
    }

    // Save to JSON file
    public void SaveToJson(string filePath)
    {
        try
        {
            string json = JsonSerializer.Serialize(cards);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            throw new IOException($"Error saving deck to JSON: {ex.Message}");
        }
    }

    // Load from JSON file
    public void LoadFromJson(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The JSON file does not exist.");

            string json = File.ReadAllText(filePath);
            cards = JsonSerializer.Deserialize<List<Card>>(json) ?? new List<Card>();
        }
        catch (Exception ex)
        {
            throw new IOException($"Error loading deck from JSON: {ex.Message}");
        }
    }

    // Save to XML file
    public void SaveToXml(string filePath)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));
            using StreamWriter writer = new StreamWriter(filePath);
            serializer.Serialize(writer, cards);
        }
        catch (Exception ex)
        {
            throw new IOException($"Error saving deck to XML: {ex.Message}");
        }
    }

    // Load from XML file
    public void LoadFromXml(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The XML file does not exist.");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));
            using StreamReader reader = new StreamReader(filePath);
            cards = (List<Card>)serializer.Deserialize(reader) ?? new List<Card>();
        }
        catch (Exception ex)
        {
            throw new IOException($"Error loading deck from XML: {ex.Message}");
        }
    }
}
