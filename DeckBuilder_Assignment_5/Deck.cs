// Author: sartaj singh
// Date: 2024-11-27
// Description: Defines the Deck class, representing a
// collection of cards with methods for adding, shuffling

using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

// Represents a collection of cards with methods for adding,
// shuffling, dealing, and persistence.
public class Deck
{
    // Internal list to store cards in the deck.
    protected List<Card> cards;

    // Constructor to initialize an empty deck.
    public Deck()
    {
        cards = new List<Card>();
    }

    // Adds a card to the deck.
    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    // Deals (removes and returns) the top card from the deck.
    // Throws an exception if the deck is empty.
    public Card Deal()
    {
        if (cards.Count == 0)
            throw new InvalidOperationException("No cards left in the deck.");

        Card topCard = cards[0];
        cards.RemoveAt(0);
        return topCard;
    }

    // Returns a copy of the cards in the deck to ensure encapsulation.
    public List<Card> Cards => new List<Card>(cards);

    // Shuffles the cards in the deck using Fisher-Yates algorithm.
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

    // Saves the current deck to a JSON file at the specified path.
    public void SaveToJson(string filePath)
    {
        try
        {
            // Serialize the list of cards to JSON format.
            string json = JsonSerializer.Serialize(cards);
            // Write the JSON string to the file.
            File.WriteAllText(filePath, json); 
        }
        catch (Exception ex)
        {
            // Throw an IOException with a custom message if an error occurs.
            throw new IOException($"Error saving deck to JSON: {ex.Message}");
        }
    }

    // Loads a deck from a JSON file at the specified path.
    public void LoadFromJson(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The JSON file does not exist.");

            // Read the JSON string from the file.
            string json = File.ReadAllText(filePath);
            // Deserialize the JSON string into a list of cards.
            cards = JsonSerializer.Deserialize<List<Card>>(json) ?? new List<Card>();
        }
        catch (Exception ex)
        {
            // Throw an IOException with a custom message if an error occurs.
            throw new IOException($"Error loading deck from JSON: {ex.Message}");
        }
    }

    // Saves the current deck to an XML file at the specified path.
    public void SaveToXml(string filePath)
    {
        try
        {
            // Create an XmlSerializer for the list of cards.
            XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));
            using StreamWriter writer = new StreamWriter(filePath);
            // Serialize the list of cards to XML format and write to the file.
            serializer.Serialize(writer, cards);
        }
        catch (Exception ex)
        {
            // Throw an IOException with a custom message if an error occurs.
            throw new IOException($"Error saving deck to XML: {ex.Message}");
        }
    }

    // Loads a deck from an XML file at the specified path.
    public void LoadFromXml(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The XML file does not exist.");

            // Create an XmlSerializer for the list of cards.
            XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));
            using StreamReader reader = new StreamReader(filePath);
            // Deserialize the XML content into a list of cards.
            cards = (List<Card>)serializer.Deserialize(reader) ?? new List<Card>();
        }
        catch (Exception ex)
        {
            // Throw an IOException with a custom message if an error occurs.
            throw new IOException($"Error loading deck from XML: {ex.Message}");
        }
    }
}
