// Author: sartaj singh
// Date: 2024-11-27
// Description: class implements the IDeckPersistence
// interface to handle saving and loading of Deck objects using XML serialization.

using System.IO;
using System.Xml.Serialization;

// Implements XML-based persistence for saving and loading Deck objects.
public class XmlDeckPersistence : IDeckPersistence
{
    // Saves the given Deck to a specified file path using XML serialization.
    public void Save(Deck deck, string filePath)
    {
        // Create an XML serializer for a list of cards.
        XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));

        // Serialize the deck's cards to the specified file.
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, deck.Cards);
        }
    }

    // Loads a Deck from the specified XML file.
    public Deck Load(string filePath)
    {
        // Check if the file exists before attempting to load it.
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The XML file does not exist.");

        // Create an XML serializer for a list of cards.
        XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));

        // Deserialize the XML content into a list of cards and reconstruct the Deck.
        using (StreamReader reader = new StreamReader(filePath))
        {
            var cards = (List<Card>)serializer.Deserialize(reader); // Deserialize into a list of cards.
            Deck deck = new Deck();
            foreach (var card in cards) // Add each card to the deck.
            {
                deck.AddCard(card);
            }
            return deck;
        }
    }
}
