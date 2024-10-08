<<<<<<< HEAD
﻿// Name - Sartaj Singh
// Date - 2024 - 10 - 08
// Modified - 2024 - 10 - 08
// Description - This C# WPF Tic Tac Toe game
// allows two players to play, checks for win conditions.

using System;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe_Sartaj_Singh
{
    public partial class MainWindow : Window
    {
        // Variables to store the current player and the game board state
        private string currentPlayer = "X";
        private Button[,] board = new Button[3, 3];
        // Score for player X
        private int xScore = 0;
        // Score for player O
        private int oScore = 0;
        // Score for cat games
        private int catsScore = 0;

        public MainWindow()
        {
            // Initialize the components
            InitializeComponent();
            InitializeBoard();
            // Update the display for the current player
            UpdateCurrentPlayerLabel();
        }

        // Initialize the buttons in the 2D array
        private void InitializeBoard()
        {
            // Assign each button on the board 
            board[0, 0] = Btn1;
            board[0, 1] = Btn2;
            board[0, 2] = Btn3;
            board[1, 0] = Btn4;
            board[1, 1] = Btn5;
            board[1, 2] = Btn6;
            board[2, 0] = Btn7;
            board[2, 1] = Btn8;
            board[2, 2] = Btn9;
        }

        // Handle button click events for Tic Tac Toe
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // sender to a Button so we know which button was clicked
            Button clickedButton = sender as Button;

            // Check if the button is empty
            if (clickedButton != null && string.IsNullOrEmpty(clickedButton.Content?.ToString()))
            {
                // Set the button content to the current player
                clickedButton.Content = currentPlayer;
                clickedButton.IsEnabled = false;

                // Check for a win condition
                if (CheckForWin())
                {
                    // Get the winner's name from the text box
                    string winnerName = currentPlayer == "X" ? PlayerXName.Text : PlayerOName.Text;
                    // Display a message box announcing the winner
                    MessageBox.Show($"{winnerName} ({currentPlayer}) is the Winner!", "Winner Announcement");
                    // Update the score for the winner
                    IncrementScore(currentPlayer);
                    // Reset the board but keep the scores
                    ResetBoard(false);
                    // Exit the function after a win
                    return;
                }

                // Check if the board is full and no one has won 
                if (IsBoardFull())
                {
                    // Show a message box for a draw
                    MessageBox.Show("It's a draw!", "Cats Game");
                    // Increase the draw score and update the label
                    catsScore++;
                    CatsScoreLabel.Content = catsScore.ToString();
                    // Reset the board but keep the scores
                    ResetBoard(false);
                    // Exit the function after a draw
                    return; 
                }

                // Switch to the other player
                currentPlayer = (currentPlayer == "X") ? "O" : "X";
                UpdateCurrentPlayerLabel();
            }
        }

        // Update the label showing the current player
        private void UpdateCurrentPlayerLabel()
        {
            // Display the player turn
            CurrentPlayerLabel.Content = currentPlayer;
        }

        // Check for a win condition
        private bool CheckForWin()
        {
            // Check each row and each column for three identical symbols
            for (int i = 0; i < 3; i++)
            {
                // Check each row for a win
                if (board[i, 0].Content != null && board[i, 0].Content.ToString() == currentPlayer &&
                    board[i, 1].Content != null && board[i, 1].Content.ToString() == currentPlayer &&
                    board[i, 2].Content != null && board[i, 2].Content.ToString() == currentPlayer)
                    return true;

                // Check each column for a win
                if (board[0, i].Content != null && board[0, i].Content.ToString() == currentPlayer &&
                    board[1, i].Content != null && board[1, i].Content.ToString() == currentPlayer &&
                    board[2, i].Content != null && board[2, i].Content.ToString() == currentPlayer)
                    return true;
            }

            // Check the two diagonals for a win
            if (board[0, 0].Content != null && board[0, 0].Content.ToString() == currentPlayer &&
                board[1, 1].Content != null && board[1, 1].Content.ToString() == currentPlayer &&
                board[2, 2].Content != null && board[2, 2].Content.ToString() == currentPlayer)
                return true;

            if (board[0, 2].Content != null && board[0, 2].Content.ToString() == currentPlayer &&
                board[1, 1].Content != null && board[1, 1].Content.ToString() == currentPlayer &&
                board[2, 0].Content != null && board[2, 0].Content.ToString() == currentPlayer)
                return true;

            // No player won 
            return false;
        }

        // Check if the board is full 
        private bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(board[i, j].Content?.ToString()))
                        return false;
                }
            }
            return true;
        }

        // Increase the score for the winning player
        private void IncrementScore(string player)
        {
            // Player 1 is the winner
            if (player == "X") 
            {
                xScore++;
                XScoreLabel.Content = xScore.ToString();
            }
            // Player 2 is the winner
            else if (player == "O")
            {
                oScore++;
                OScoreLabel.Content = oScore.ToString();
            }
        }

        // Reset the game board
        private void ResetBoard(bool resetScores)
        {
      
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j].Content = "";
                    board[i, j].IsEnabled = true;
                    board[i, j].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB9B7B7"));
                }
            }


            if (resetScores) 
            {
                // Reset all the scores and update the labels
                xScore = 0;
                oScore = 0;
                catsScore = 0;
                XScoreLabel.Content = xScore.ToString();
                OScoreLabel.Content = oScore.ToString();
                CatsScoreLabel.Content = catsScore.ToString();
            }

            // Reset the game to start with player
            currentPlayer = "X";
            UpdateCurrentPlayerLabel();
        }

        // Reset button click event
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetBoard(true);
        }

        // Exit button click event
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            this.Close();
        }

        // Choose a random starting player
        private void ChooseStartingPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            currentPlayer = (random.Next(2) == 0) ? "X" : "O";
            // Update the display to show the current player
            UpdateCurrentPlayerLabel();
        }
=======
﻿using System.Windows;
using System.Windows.Controls;
using static System.Formats.Asn1.AsnWriter;

namespace TicTacToe_Sartaj
{
    public partial class MainWindow : Window
    {
        private bool isPlayerOneTurn = true;
        private int turnCount = 0;
        private int xScore = 0, oScore = 0, catsGameScore = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Content.ToString() == " ")
            {
                button.Content = isPlayerOneTurn ? "X" : "O";
                CurrentPlayer.Text = isPlayerOneTurn ? "O" : "X"; // Update current player label
                isPlayerOneTurn = !isPlayerOneTurn;
                turnCount++;

                if (turnCount >= 5) // Only start checking for a winner after 5 moves
                {
                    if (CheckForWinner())
                    {
                        if (!isPlayerOneTurn) xScore++;
                        else oScore++;

                        MessageBox.Show($"{(isPlayerOneTurn ? OPlayerName.Text : XPlayerName.Text)} wins!");
                        UpdateScores();
                        ResetBoard();
                    }
                    else if (turnCount == 9)
                    {
                        catsGameScore++;
                        MessageBox.Show("It's a draw!");
                        UpdateScores();
                        ResetBoard();
                    }
                }
            }
        }

        private bool CheckForWinner()
        {
            var buttons = new Button[3, 3]
            {
                { Button0, Button1, Button2 },
                { Button3, Button4, Button5 },
                { Button6, Button7, Button8 }
            };

            for (int i = 0; i < 3; i++)
            {
                // Check rows
                if (buttons[i, 0].Content == buttons[i, 1].Content && buttons[i, 1].Content == buttons[i, 2].Content && buttons[i, 0].Content.ToString() != " ")
                    return true;
                // Check columns
                if (buttons[0, i].Content == buttons[1, i].Content && buttons[1, i].Content == buttons[2, i].Content && buttons[0, i].Content.ToString() != " ")
                    return true;
            }
            // Check diagonals
            if (buttons[0, 0].Content == buttons[1, 1].Content && buttons[1, 1].Content == buttons[2, 2].Content && buttons[0, 0].Content.ToString() != " ")
                return true;
            if (buttons[0, 2].Content == buttons[1, 1].Content && buttons[1, 1].Content == buttons[2, 0].Content && buttons[0, 2].Content.ToString() != " ")
                return true;

            return false;
        }

        private void UpdateScores()
        {
            XScore.Text = xScore.ToString();
            OScore.Text = oScore.ToString();
            CatsScore.Text = catsGameScore.ToString();
        }

        private void ResetBoard()
        {
            Button0.Content = Button1.Content = Button2.Content =
            Button3.Content = Button4.Content = Button5.Content =
            Button6.Content = Button7.Content = Button8.Content = " ";
            isPlayerOneTurn = true;
            turnCount = 0;
            CurrentPlayer.Text = "X"; // Reset current player to X
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetBoard();
            xScore = oScore = catsGameScore = 0; // Reset scores
            UpdateScores();
            XPlayerName.Text = OPlayerName.Text = ""; // Clear player names
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ChooseStartingPlayer_Click(object sender, RoutedEventArgs e)
        {
            isPlayerOneTurn = (MessageBox.Show("Should Player X start?", "Choose Starting Player", MessageBoxButton.YesNo) == MessageBoxResult.Yes);
            CurrentPlayer.Text = isPlayerOneTurn ? "X" : "O"; // Set the current player display
        }
>>>>>>> 3265b7c (final commit)
    }
}
