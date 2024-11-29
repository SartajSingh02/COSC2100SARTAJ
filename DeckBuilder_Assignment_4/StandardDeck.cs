using System.Collections.Generic;

public class StandardDeck : Deck
{
    private readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private readonly string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

    public StandardDeck()
    {
        ResetDeck();
    }

    public void ClearDeck()
    {
        cards.Clear(); // Remove all cards from the deck
    }

    public void ResetDeck()
    {
        cards.Clear();
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                AddCard(new Card(suit, rank));
            }
        }
    }
}
