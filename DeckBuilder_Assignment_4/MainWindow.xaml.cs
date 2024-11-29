using System;
using System.Windows;

namespace DeckBuilder
{
    public partial class MainWindow : Window
    {
        private StandardDeck standardDeck;

        public MainWindow()
        {
            InitializeComponent();
            standardDeck = new StandardDeck(); // Initialize with a standard deck
        }

        private void AddCustomButton_Click(object sender, RoutedEventArgs e)
        {
            string suit = SuitTextBox.Text.Trim();
            string rank = RankTextBox.Text.Trim();

            // Validate Suit
            if (string.IsNullOrWhiteSpace(suit))
            {
                MessageBox.Show("Suit cannot be empty or only spaces.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validate Rank
            if (string.IsNullOrWhiteSpace(rank))
            {
                MessageBox.Show("Rank cannot be empty or only spaces.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Add the card to the deck
            standardDeck.AddCard(new Card(suit, rank));

            // Clear input fields
            SuitTextBox.Clear();
            RankTextBox.Clear();

            // Display success message
            MessageBox.Show("Custom card added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Refresh deck display
            ViewDeckButton_Click(null, null);
        }


        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(DrawTextBox.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for cards to draw.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (count > standardDeck.Cards.Count)
            {
                MessageBox.Show("Not enough cards in the deck to draw the specified number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DealtCardsListBox.Items.Clear();

            for (int i = 0; i < count; i++)
            {
                var card = standardDeck.Deal();
                DealtCardsListBox.Items.Add(card.ToString());
            }

            // Refresh the deck display
            ViewDeckButton_Click(null, null);

            MessageBox.Show($"{count} card(s) dealt successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.Shuffle();

            // Refresh the deck display
            ViewDeckButton_Click(null, null);

            MessageBox.Show("Deck shuffled successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.ResetDeck(); // Reset the deck to its original state
            DeckListView.Items.Clear();
            foreach (var card in standardDeck.Cards)
            {
                DeckListView.Items.Add(card.ToString());
            }
        }

        private void ViewDeckButton_Click(object sender, RoutedEventArgs e)
        {
            DeckListView.Items.Clear();

            foreach (var card in standardDeck.Cards)
            {
                DeckListView.Items.Add(card.ToString());
            }
        }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Confirm exit and reset action
            MessageBoxResult result = MessageBox.Show(
                "Do you want to reset unsaved changes before exiting?",
                "Exit Confirmation",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                // Reset the deck before exiting
                standardDeck.ResetDeck();
                Application.Current.Shutdown();
            }
            else if (result == MessageBoxResult.No)
            {
                // Exit without resetting
                Application.Current.Shutdown();
            }
            // Cancel does nothing
        }


        private void SaveDeckMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "deck.json";
                standardDeck.SaveToJson(filePath);
                MessageBox.Show("Deck saved successfully to JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving deck: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void LoadDeckMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "deck.json";
                standardDeck.LoadFromJson(filePath);
                MessageBox.Show("Deck loaded successfully from JSON.");
                ViewDeckButton_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading deck: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportToXmlMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "deck.xml";
                standardDeck.SaveToXml(filePath);
                MessageBox.Show("Deck exported successfully to XML.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting deck: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportToJsonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "deck.json";
                standardDeck.SaveToJson(filePath);
                MessageBox.Show("Deck exported successfully to JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting deck: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearAllMenuItem_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.ClearDeck();
            DeckListView.Items.Clear();
            DealtCardsListBox.Items.Clear();
            MessageBox.Show("All cards cleared from the deck.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This application allows you to build, shuffle, and manage a deck of cards.", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("DeckBuilder Application\nVersion 1.0\nCreated by Sartaj Singh", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}