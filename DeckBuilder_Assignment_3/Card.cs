public class Card
{
    // Property for the suit of the card
    public string Suit { get; set; }

    // Property for the rank of the card
    public string Rank { get; set; }

    // Constructor to create a new card with a specific suit and rank
    public Card(string suit, string rank)
    {
        // Sets the card's suit
        Suit = suit;
        // Sets the card's rank
        Rank = rank;
    }

    // Method to return the card as a string in the format "Rank of Suit"
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
