using System;
using System.Collections.Generic;

public class Deck
{
    // List to store all the cards in the deck
    protected List<Card> cards;

    // Constructor to create a new deck and initialize the list of cards
    public Deck()
    {
        cards = new List<Card>();
    }

    // Method to shuffle the deck by randomly swapping cards
    public void Shuffle()
    {
        Random rand = new Random(); // Random number generator
        for (int i = 0; i < cards.Count; i++)
        {
            int j = rand.Next(cards.Count);
            var temp = cards[i]; 
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    // Method to deal (remove and return) the top card from the deck
    public Card Deal()
    {
        // Check if there are any cards left to deal
        if (cards.Count == 0) throw new InvalidOperationException("No cards left in the list.");

        // Get the top card
        var dealtCard = cards[0]; 
        cards.RemoveAt(0);
        return dealtCard; 
    }

    // Method to add a card to the deck
    public void AddCard(Card card)
    {
        // Adds the specified card to the end of the list
        cards.Add(card);
    }

    // Property to access the list of cards in the deck
    public IEnumerable<Card> Cards => cards;
}
