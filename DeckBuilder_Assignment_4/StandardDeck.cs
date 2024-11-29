// Author: Sartaj Singh
// Date: 2024-11-27
// Description: Defines the StandardDeck class, representing a standard deck of cards.
//  Includes methods to initialize, reset, and clear the deck.

using System.Collections.Generic;


// Represents a standard deck of playing cards.
// Inherits from the Deck class and includes methods to initialize and manage a deck.
public class StandardDeck : Deck
{
    // Array of standard suits for playing cards
    private readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

    // Array of standard ranks for playing cards
    private readonly string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

   
    // Constructor that initializes the deck with standard playing cards.
    public StandardDeck()
    {
        ResetDeck(); // Populate the deck with standard cards
    }


    // Removes all cards from the deck.
    public void ClearDeck()
    {
        cards.Clear(); // Clears the list of cards in the deck
    }


    // Resets the deck to its initial state with standard playing cards.
    // Clears the current deck and adds all 52 standard cards.
    public void ResetDeck()
    {
        cards.Clear(); // Start with an empty deck

        // Nested loops to iterate through suits and ranks
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                // Create a new card with the current suit and rank and add it to the deck
                AddCard(new Card(suit, rank));
            }
        }
    }
}
