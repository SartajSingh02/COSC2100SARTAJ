public class StandardDeck : Deck
{
    private readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private readonly string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

    public StandardDeck()
    {
        // Use for loops instead of foreach
        for (int i = 0; i < suits.Length; i++)
        {
            for (int j = 0; j < ranks.Length; j++)
            {
                AddCard(new Card(suits[i], ranks[j]));
            }
        }
    }
}
