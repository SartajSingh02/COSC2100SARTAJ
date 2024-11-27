public class StandardDeck : Deck
{
    private readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private readonly string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

    public StandardDeck()
    {
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                AddCard(new Card(suit, rank));
            }
        }
    }
}
