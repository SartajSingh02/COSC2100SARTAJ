// Author: Sartaj Singh
// Date: 2024-11-27
// Description: Defines the MainWindow class for the DeckBuilder application.
// This application allows users to manage a deck of cards, including viewing, shuffling, dealing,
// saving/loading, and switching between XML and JSON persistence.

using System;
using System.Windows;

namespace DeckBuilder
{
    public partial class MainWindow : Window
    {
        // Represents the current deck being managed
        private StandardDeck standardDeck;
        // Handles saving/loading operations
        private PersistenceManager persistenceManager;

        // Constructor: Initializes the main window and sets the default persistence strategy to JSON
        public MainWindow()
        {
            InitializeComponent();
            // Initialize a standard deck
            standardDeck = new StandardDeck();
            // Default persistence is JSON
            persistenceManager = new PersistenceManager(new JsonDeckPersistence()); 
        }

        // Displays the current deck in the DeckListView UI element
        private void ViewDeckButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the existing deck view
            DeckListView.Items.Clear();
            // Add each card from the deck
            foreach (var card in standardDeck.Cards)
            {
                DeckListView.Items.Add(card.ToString());
            }
        }

        // Shuffles the current deck and refreshes the UI
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.Shuffle();
            // Refresh the deck view
            ViewDeckButton_Click(null, null);
            MessageBox.Show("Deck shuffled successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Deals a specified number of cards from the deck
        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate user input for the number of cards to deal
            if (!int.TryParse(DrawTextBox.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for cards to draw.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Ensure there are enough cards in the deck
            if (count > standardDeck.Cards.Count)
            {
                MessageBox.Show("Not enough cards in the deck to draw the specified number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Clear the dealt cards list
            DealtCardsListBox.Items.Clear();
            // Deal the specified number of cards
            for (int i = 0; i < count; i++) 
            {
                var card = standardDeck.Deal();
                DealtCardsListBox.Items.Add(card.ToString());
            }

            ViewDeckButton_Click(null, null);
            MessageBox.Show($"{count} card(s) dealt successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Saves the current deck to a file based on the active persistence strategy (XML/JSON)
        private void SaveDeckMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = persistenceManager is XmlDeckPersistence ? "deck.xml" : "deck.json"; 
                persistenceManager.SaveDeck(standardDeck, filePath);
                MessageBox.Show($"Deck saved successfully to {filePath}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving deck: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Loads a deck from a file based on the active persistence strategy (XML/JSON)
        private void LoadDeckMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = persistenceManager is XmlDeckPersistence ? "deck.xml" : "deck.json";
                standardDeck = (StandardDeck)persistenceManager.LoadDeck(filePath);
                MessageBox.Show($"Deck loaded successfully from {filePath}.");
                ViewDeckButton_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading deck: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Switches persistence strategy to XML
        private void SwitchToXml_Click(object sender, RoutedEventArgs e)
        {
            persistenceManager.SetPersistence(new XmlDeckPersistence());
            MessageBox.Show("Switched to XML persistence.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Switches persistence strategy to JSON
        private void SwitchToJson_Click(object sender, RoutedEventArgs e)
        {
            persistenceManager.SetPersistence(new JsonDeckPersistence());
            MessageBox.Show("Switched to JSON persistence.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Clears all cards from the deck and updates the UI
        private void ClearAllMenuItem_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.ClearDeck(); // Clear the deck
            DeckListView.Items.Clear(); // Clear the deck view
            DealtCardsListBox.Items.Clear(); // Clear the dealt cards list
            MessageBox.Show("All cards cleared from the deck.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Displays help information
        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This application allows you to build, shuffle, and manage a deck of cards.", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Displays information about the application and its author
        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("DeckBuilder Application Version 1.0 Created by Sartaj Singh", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Handles application exit, with an option to reset unsaved changes
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Do you want to reset unsaved changes before exiting?",
                "Exit Confirmation",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                // Reset the deck
                standardDeck.ResetDeck();
                // Exit application
                Application.Current.Shutdown(); 
            }
            else if (result == MessageBoxResult.No)
            {
                // Exit application without resetting
                Application.Current.Shutdown(); 
            }
        }

        // Exports the deck to a JSON file
        private void ExportToJsonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // File path for JSON export
                string filePath = "deck.json";
                persistenceManager.SaveDeck(standardDeck, filePath);
                MessageBox.Show("Deck exported successfully to JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting deck to JSON: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Exports the deck to an XML file
        private void ExportToXmlMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // File path for XML export
                string filePath = "deck.xml";
                persistenceManager.SaveDeck(standardDeck, filePath);
                MessageBox.Show("Deck exported successfully to XML.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting deck to XML: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Adds a custom card to the deck based on user input
        private void AddCustomButton_Click(object sender, RoutedEventArgs e)
        {
            // Get suit and rank input
            string suit = SuitTextBox.Text.Trim();
            string rank = RankTextBox.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(suit))
            {
                MessageBox.Show("Suit cannot be empty or only spaces.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(rank))
            {
                MessageBox.Show("Rank cannot be empty or only spaces.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Add the custom card
            standardDeck.AddCard(new Card(suit, rank)); 
            SuitTextBox.Clear();
            RankTextBox.Clear();
            ViewDeckButton_Click(null, null); 
            MessageBox.Show("Custom card added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Resets the deck to its original state
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.ResetDeck(); 
            DeckListView.Items.Clear(); 
            ViewDeckButton_Click(null, null);
            MessageBox.Show("Deck reset to its original state.", "Reset", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Represents a Joker card with a customizable color
        public class JokerCard : Card
        {
            // Color of the joker
            public string Color { get; set; }

            // Initialize base card with "Joker"
            public JokerCard(string color) : base("None", "Joker") 
            {
                Color = color;
            }

            public override string ToString()
            {
                // Return a string representation of the joker card
                return $"{Color} Joker";
            }
        }

        // Represents a Wild card with a special ability
        public class WildCard : Card
        {
            // Special ability of the wild card
            public string SpecialAbility { get; set; }

            // Initialize base card with "Wild"
            public WildCard(string specialAbility) : base("None", "Wild")
            {
                SpecialAbility = specialAbility;
            }

            public override string ToString()
            {
                // Return a string representation of the wild card
                return $"Wild Card with Ability: {SpecialAbility}";
            }
        }

        // Adds a Joker card to the deck with user-specified color
        private void AddJokerButton_Click(object sender, RoutedEventArgs e)
        {
            string color = JokerColorTextBox.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(color))
            {
                MessageBox.Show("Joker color cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            standardDeck.AddCard(new JokerCard(color));
            JokerColorTextBox.Clear(); 
            ViewDeckButton_Click(null, null); 
            MessageBox.Show("Joker card added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Adds a Wild card to the deck with user-specified ability
        private void AddWildCardButton_Click(object sender, RoutedEventArgs e)
        {
            string ability = WildAbilityTextBox.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(ability))
            {
                MessageBox.Show("Wild card ability cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            standardDeck.AddCard(new WildCard(ability)); 
            WildAbilityTextBox.Clear(); 
            ViewDeckButton_Click(null, null); 
            MessageBox.Show("Wild card added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
