using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Deck
{
    [JsonProperty]
    protected List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
    }

    public void Shuffle()
    {
        Random rand = new Random();
        for (int i = 0; i < cards.Count; i++)
        {
            int j = rand.Next(cards.Count);
            var temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card Deal()
    {
        if (cards.Count == 0) throw new InvalidOperationException("No cards left in the deck.");
        var dealtCard = cards[0];
        cards.RemoveAt(0);
        return dealtCard;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public IEnumerable<Card> Cards => cards;
}
