using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using Newtonsoft.Json;

namespace DeckBuilder
{
    public partial class MainWindow : Window
    {
        private StandardDeck standardDeck;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                LoadDeckFromJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load deck from file. Starting with a new deck.\n" + ex.Message);
                standardDeck = new StandardDeck();
            }
        }

        private void AddCustomButton_Click(object sender, RoutedEventArgs e)
        {
            string suit = SuitTextBox.Text;
            string rank = RankTextBox.Text;
            try
            {
                if (!string.IsNullOrWhiteSpace(suit) && !string.IsNullOrWhiteSpace(rank))
                {
                    standardDeck.AddCard(new Card(suit, rank));
                    MessageBox.Show($"Added Custom Card: {rank} of {suit}");
                    LogOperation("AddCustomCard", $"Added Custom Card: {rank} of {suit}");
                    DisplayDeck();
                }
                else
                {
                    throw new ArgumentException("Suit and Rank cannot be empty.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(DrawTextBox.Text, out int drawCount) && drawCount > 0)
                {
                    DealtCardsListBox.Items.Clear();
                    string dealtCardsStr = "";
                    for (int i = 0; i < drawCount; i++)
                    {
                        var dealtCard = standardDeck.Deal();
                        DealtCardsListBox.Items.Add(dealtCard.ToString());
                        dealtCardsStr += dealtCard.ToString() + ", ";
                    }

                    LogOperation("Deal", $"Dealt {drawCount} cards: {dealtCardsStr.TrimEnd(',', ' ')}");
                }
                else
                {
                    MessageBox.Show("Please enter a valid positive number for the draw count.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void ViewDeckButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayDeck();
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck.Shuffle();
            DisplayDeck();
            LogOperation("Shuffle", "Deck shuffled");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            standardDeck = new StandardDeck();
            DeckListView.Items.Clear();
            LogOperation("Reset", "Deck reset to original state");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            LogOperation("Exit", "Application exited");
            Application.Current.Shutdown();
        }

        private void DisplayDeck()
        {
            DeckListView.Items.Clear();
            foreach (var card in standardDeck.Cards)
            {
                DeckListView.Items.Add(card.ToString());
            }
        }

        private void LoadDeckFromJson()
        {
            string filePath = "deck.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                standardDeck = JsonConvert.DeserializeObject<StandardDeck>(json) ?? new StandardDeck();
            }
            else
            {
                standardDeck = new StandardDeck();
            }
        }

        private void SaveDeckToJson()
        {
            string filePath = "deck.json";
            string json = JsonConvert.SerializeObject(standardDeck, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void LogOperation(string operation, string details)
        {
            string filePath = "operations_log.json";
            try
            {
                var logs = File.Exists(filePath)
                    ? JsonConvert.DeserializeObject<List<LogEntry>>(File.ReadAllText(filePath)) ?? new List<LogEntry>()
                    : new List<LogEntry>();

                logs.Add(new LogEntry
                {
                    Timestamp = DateTime.Now,
                    Operation = operation,
                    Details = details
                });

                File.WriteAllText(filePath, JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented));
            }
            catch
            {
                // Handle logging failures silently
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            SaveDeckToJson();
        }
    }

    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Operation { get; set; }
        public string Details { get; set; }
    }
}
