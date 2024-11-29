// Author: sartaj singh
// Date: 2024-11-27
// Description: class handles saving and loading Deck
// objects using a configurable and switchable persistence strategy.

// Manages saving and loading of Deck objects using a specified persistence strategy.
public class PersistenceManager
{
    // The persistence strategy to be used for saving and loading decks
    private IDeckPersistence persistence;

    // Constructor to initialize the PersistenceManager with a specified persistence strategy
    public PersistenceManager(IDeckPersistence persistence)
    {
        this.persistence = persistence;
    }

    // Sets or switches the persistence strategy at runtime
    public void SetPersistence(IDeckPersistence persistence)
    {
        this.persistence = persistence;
    }

    // Saves the given Deck object to a file using the current persistence strategy
    public void SaveDeck(Deck deck, string filePath)
    {
        persistence.Save(deck, filePath); // Delegate the save operation to the persistence strategy
    }

    // Loads a Deck object from a file using the current persistence strategy
    public Deck LoadDeck(string filePath)
    {
        return persistence.Load(filePath); // Delegate the load operation to the persistence strategy
    }
}
