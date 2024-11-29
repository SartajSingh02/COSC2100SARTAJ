public class PersistenceManager
{
    private IDeckPersistence persistence;

    public PersistenceManager(IDeckPersistence persistence)
    {
        this.persistence = persistence;
    }

    public void SetPersistence(IDeckPersistence persistence)
    {
        this.persistence = persistence;
    }

    public void SaveDeck(Deck deck, string filePath)
    {
        persistence.Save(deck, filePath);
    }

    public Deck LoadDeck(string filePath)
    {
        return persistence.Load(filePath);
    }
}