// Author: Sartaj Singh
// Date: 2024-11-27
// Description: Defines the CustomDeck class, extending the Deck class
// with a method for adding custom cards by specifying suit and rank.

public class CustomDeck : Deck
{
    // Method to add a custom card to the deck with a specific suit and rank
    public void AddCustomCard(string suit, string rank)
    {
        // Validate that the suit and rank are not null, empty, or consist only of whitespace
        if (!string.IsNullOrWhiteSpace(suit) && !string.IsNullOrWhiteSpace(rank))
        {
            // If the inputs are valid, create a new Card instance and add it to the deck
            AddCard(new Card(suit, rank));
        }
        else
        {
            // Throw an exception if suit or rank is invalid
            throw new ArgumentException("Suit and Rank cannot be empty.");
        }
    }
}
