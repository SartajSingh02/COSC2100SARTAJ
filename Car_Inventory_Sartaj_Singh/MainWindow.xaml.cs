// Name - Sartaj Singh
// Date - 10/16/2024
// Modified - 10/16/2024
// Description - This program is a WPF application in C#
// that lets users add, update, and view a list of cars with details
// like Make, Model, Colour, Year, Price, and whether the car is new or used.

using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Windows;

namespace CarInventoryApp
{
    public partial class MainWindow : Window
    {
        // Collection to store cars
        private List<Car> carCollection = new List<Car>();

        public MainWindow()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        // Populates the Make and Year ComboBoxes with options.
        private void PopulateComboBoxes()
        {
            // Populate car makes
            comboMake.Items.Add("Volkswagen");
            comboMake.Items.Add("Toyota");
            comboMake.Items.Add("Ford");
            comboMake.Items.Add("Honda");
            comboMake.Items.Add("BMW");
            comboMake.Items.Add("Mercedes");
            comboMake.Items.Add("Tesla");
            comboMake.Items.Add("Audi");
            comboMake.Items.Add("Hyundai");
            comboMake.Items.Add("Lexus");

            // Adds the past 50 years to the Year ComboBox.
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 50; year--)
            {
                comboYear.Items.Add(year);
            }
        }

        // Validate form inputs
        private bool ValidateForm()
        {
            lblMessage.Content = ""; // Clear any previous error messages

            if (comboMake.SelectedItem == null)
            {
                lblMessage.Content = "Please select a make.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                lblMessage.Content = "Please enter a model.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtColour.Text))
            {
                lblMessage.Content = "Please enter a colour.";
                return false;
            }
            if (comboYear.SelectedItem == null)
            {
                lblMessage.Content = "Please select a year.";
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                lblMessage.Content = "Please enter a valid price.";
                return false;
            }

            return true;
        }

        // Add or update car when the Enter button is clicked
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm())
                return;

            decimal.TryParse(txtPrice.Text, out decimal price);

            // Check if a car is selected for modification
            if (dataGridCars.SelectedItem is Car selectedCar)
            {
                // Update the fields
                selectedCar.Make = comboMake.Text;
                selectedCar.Model = txtModel.Text;
                selectedCar.Colour = txtColour.Text;
                selectedCar.Year = (int)comboYear.SelectedItem;
                selectedCar.Price = price;
                selectedCar.NewStatus = NewStatus.IsChecked == true;

                lblMessage.Content = "Car updated!";

                ResetForm(); // Clear the inputs
            }
            else
            {
                // Create a new car
                Car newCar = new Car(comboMake.Text, txtModel.Text, txtColour.Text, (int)comboYear.SelectedItem, price, NewStatus.IsChecked == true);
                carCollection.Add(newCar);

                lblMessage.Content = "It Worked!";

                ResetForm(); // Clear the form
            }

            // Refresh the DataGrid
            dataGridCars.ItemsSource = null;
            dataGridCars.ItemsSource = carCollection;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // Clear the form inputs
            ResetForm();
            dataGridCars.SelectedIndex = -1;
            // Clear the message label
            lblMessage.Content = "";
        }

        // Exit the application when the Exit button is clicked
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Clear form inputs and reset output fields
        private void ResetForm()
        {
            // Reset the make selection
            comboMake.SelectedItem = null;
            // Clear the model input
            txtModel.Clear();
            // Clear the colour input
            txtColour.Clear();
            // Reset the year selection
            comboYear.SelectedItem = null;
            // Clear the price input
            txtPrice.Clear();
            NewStatus.IsChecked = false;
        }
    }
}
