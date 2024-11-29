// Author: sartaj singh
// Date: 2024-11-27
// Description: class implements the IDeckPersistence
// interface to handle saving and loading of Deck objects using JSON serialization


using System.IO;
using System.Text.Json;

// Implements JSON-based persistence for saving and loading Deck objects.
public class JsonDeckPersistence : IDeckPersistence
{
    // Saves the given Deck to a specified file path using JSON serialization.
    public void Save(Deck deck, string filePath)
    {
        // Serialize the deck's cards to a JSON string.
        string json = JsonSerializer.Serialize(deck.Cards);

        // Write the JSON string to the specified file.
        File.WriteAllText(filePath, json);
    }

    // Loads a Deck from the specified JSON file.
    public Deck Load(string filePath)
    {
        // Check if the file exists before attempting to load it.
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The JSON file does not exist.");

        // Read the JSON string from the file.
        string json = File.ReadAllText(filePath);

        // Deserialize the JSON string into a list of cards.
        var cards = JsonSerializer.Deserialize<List<Card>>(json);

        // Reconstruct the Deck object by adding the deserialized cards.
        Deck deck = new Deck();
        foreach (var card in cards)
        {
            deck.AddCard(card);
        }

        // Return the reconstructed Deck.
        return deck;
    }
}
