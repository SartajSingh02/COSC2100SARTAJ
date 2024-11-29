// Author: Sartaj Singh
// Date: 2024-11-27
// Description: Defines the Card class, representing a single card with a suit and rank.

public class Card
{
    // Property to store the suit of the card (e.g., Hearts, Spades)
    public string Suit { get; set; }

    // Property to store the rank of the card (e.g., Ace, 2, King)
    public string Rank { get; set; }

    // Constructor to initialize a card with a specified suit and rank
    public Card(string suit, string rank)
    {
        // Assign the provided suit and rank to the Suit property
        Suit = suit; 
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
