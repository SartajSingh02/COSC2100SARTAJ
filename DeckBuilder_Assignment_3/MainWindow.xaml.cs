// Name: Sartaj Singh
// Date: 11/10/2024
// Modified: 11/11/2024
// Description: Code creates a card deck app where users can add custom cards, shuffle, deal and view the deck.
using System.Windows;

namespace DeckBuilder
{
    public partial class MainWindow : Window
    {
        // The standard deck of cards
        private StandardDeck standardDeck;
        // The custom deck where user-added cards are stored
        private CustomDeck customDeck;

        public MainWindow()
        {
            InitializeComponent();
            // Creates a new standard deck
            standardDeck = new StandardDeck();
            // Creates a new empty custom deck
            customDeck = new CustomDeck();
        }

        // Adds a custom card with user-provided suit and rank
        private void AddCustomButton_Click(object sender, RoutedEventArgs e)
        {
            // Get suit from SuitTextBox
            string suit = SuitTextBox.Text;
            // Get rank from RankTextBox
            string rank = RankTextBox.Text;
            try
            {
                // Adds the custom card to the custom deck
                customDeck.AddCustomCard(suit, rank);
                MessageBox.Show($"Added Custom Card: {rank} of {suit}");
            }
            catch (Exception ex)
            {
                // Prompt for Error Message
                MessageBox.Show(ex.Message);
            }
        }

        // Deals a specific number of cards from the standard deck
        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the number of cards to draw from DrawTextBox
                if (int.TryParse(DrawTextBox.Text, out int drawCount) && drawCount > 0)
                {
                    DealtCardsListBox.Items.Clear();
                    for (int i = 0; i < drawCount; i++)
                    {
                        var dealtCard = standardDeck.Deal();
                        DealtCardsListBox.Items.Add(dealtCard.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid positive number for the draw count.");
                }
            }
            catch (InvalidOperationException ex)
            {
                // Show an error if there’s an issue with dealing cards
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Shows the current deck in the DeckListView
        private void ViewDeckButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayDeck();
        }

        // Shuffles the deck and updates the display to show the new order
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.Shuffle();
            DisplayDeck();
        }

        // Resets the deck to its original state
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck = new StandardDeck();
            DeckListView.Items.Clear();
        }

        // Closes the application
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Displays all cards in the deck in DeckListView
        private void DisplayDeck()
        {
            DeckListView.Items.Clear();

            var cardList = standardDeck.Cards.ToList();
            for (int i = 0; i < cardList.Count; i++)
            {
                DeckListView.Items.Add(cardList[i].ToString());
            }
        }
    }
}
