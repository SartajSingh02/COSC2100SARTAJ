using System;
using System.Windows;
using System.Windows.Input;

namespace DeckBuilder
{
    public partial class MainWindow : Window
    {
        private StandardDeck standardDeck;
        private PersistenceManager persistenceManager;

        public MainWindow()
        {
            InitializeComponent();
            standardDeck = new StandardDeck();
            persistenceManager = new PersistenceManager(new JsonDeckPersistence());
        }

        private void ViewDeckButton_Click(object sender, RoutedEventArgs e)
        {
            DeckListView.Items.Clear();
            foreach (var card in standardDeck.Cards)
            {
                DeckListView.Items.Add(card.ToString());
            }
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.Shuffle();
            ViewDeckButton_Click(null, null);
            MessageBox.Show("Deck shuffled successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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

            ViewDeckButton_Click(null, null);
            MessageBox.Show($"{count} card(s) dealt successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

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

        private void SwitchToXml_Click(object sender, RoutedEventArgs e)
        {
            persistenceManager.SetPersistence(new XmlDeckPersistence());
            MessageBox.Show("Switched to XML persistence.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SwitchToJson_Click(object sender, RoutedEventArgs e)
        {
            persistenceManager.SetPersistence(new JsonDeckPersistence());
            MessageBox.Show("Switched to JSON persistence.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
            MessageBox.Show("DeckBuilder Application Version 1.0 Created by Sartaj Singh", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

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
                standardDeck.ResetDeck();
                Application.Current.Shutdown();
            }
            else if (result == MessageBoxResult.No)
            {
                Application.Current.Shutdown();
            }
        }

        private void ExportToJsonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "deck.json";
                persistenceManager.SaveDeck(standardDeck, filePath);
                MessageBox.Show("Deck exported successfully to JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting deck to JSON: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportToXmlMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "deck.xml";
                persistenceManager.SaveDeck(standardDeck, filePath);
                MessageBox.Show("Deck exported successfully to XML.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting deck to XML: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddCustomButton_Click(object sender, RoutedEventArgs e)
        {
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

            standardDeck.AddCard(new Card(suit, rank));
            SuitTextBox.Clear();
            RankTextBox.Clear();
            ViewDeckButton_Click(null, null);
            MessageBox.Show("Custom card added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.ResetDeck();
            DeckListView.Items.Clear();
            ViewDeckButton_Click(null, null);
            MessageBox.Show("Deck reset to its original state.", "Reset", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public class JokerCard : Card
        {
            public string Color { get; set; }

            public JokerCard(string color) : base("None", "Joker")
            {
                Color = color;
            }

            public override string ToString()
            {
                return $"{Color} Joker";
            }
        }

        public class WildCard : Card
        {
            public string SpecialAbility { get; set; }

            public WildCard(string specialAbility) : base("None", "Wild")
            {
                SpecialAbility = specialAbility;
            }

            public override string ToString()
            {
                return $"Wild Card with Ability: {SpecialAbility}";
            }
        }

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