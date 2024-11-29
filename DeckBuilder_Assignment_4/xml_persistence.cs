using System.IO;
using System.Xml.Serialization;

public class XmlDeckPersistence : IDeckPersistence
{
    public void Save(Deck deck, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, deck.Cards);
        }
    }

    public Deck Load(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The XML file does not exist.");

        XmlSerializer serializer = new XmlSerializer(typeof(List<Card>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            var cards = (List<Card>)serializer.Deserialize(reader);
            Deck deck = new Deck();
            foreach (var card in cards)
            {
                deck.AddCard(card);
            }
            return deck;
        }
    }
}