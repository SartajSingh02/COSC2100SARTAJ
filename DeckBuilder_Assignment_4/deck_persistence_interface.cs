public interface IDeckPersistence
{
    void Save(Deck deck, string filePath);
    Deck Load(string filePath);
}