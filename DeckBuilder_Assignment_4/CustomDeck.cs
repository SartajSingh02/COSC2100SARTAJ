public class CustomDeck : Deck
{
    // Method to add a custom card to the deck with a specific suit and rank
    public void AddCustomCard(string suit, string rank)
    {
        // Check if the suit and rank are not empty or only whitespace
        if (!string.IsNullOrWhiteSpace(suit) && !string.IsNullOrWhiteSpace(rank))
        {
            // If both suit and rank are valid, create a new card and add it to the deck
            AddCard(new Card(suit, rank));
        }
        else
        {
            // If suit or rank is empty, throw an error with a message
            throw new ArgumentException("Suit and Rank cannot be empty.");
        }
    }
}
