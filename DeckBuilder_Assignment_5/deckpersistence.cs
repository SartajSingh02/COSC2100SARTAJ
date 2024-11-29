// Author: sartaj singh
// Date: 2024-11-27

// Interface for deck persistence, allowing saving and loading Deck objects with different implementations.
public interface IDeckPersistence
{
    // Saves the given Deck to a specified file path.
    void Save(Deck deck, string filePath);

    // Loads a Deck from the specified file path.
    Deck Load(string filePath);
}
