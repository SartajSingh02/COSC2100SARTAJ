// Name - Sartaj Singh
// Date - 10/16/2024
// Modified - 10/16/2024
// Description - This program is a WPF application in C#
// that lets users add, update, and view a list of cars with details
// like Make, Model, Colour, Year, Price, and whether the car is new or used.

using System;
using System.Collections.Generic;
using System.Windows;

namespace CarInventoryApp
{
    public partial class MainWindow : Window
    {
        // Collection to store cars
        private List<Car> carCollection = new List<Car>();
        // Tracks car identification numbers.
        private int nextCarId = 1;

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

            // Adds the past 50 years to the Year ComboBox.
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 50; year--)
            {
                comboYear.Items.Add(year);
            }
        }

        // Validate form inputs
        private bool ValidateForm()
        {
            if (comboMake.SelectedItem == null)
            {
                MessageBox.Show("Please select a make.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Please enter a model.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtColour.Text))
            {
                MessageBox.Show("Please enter a colour.");
                return false;
            }
            if (comboYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a year.");
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.");
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
                var updatedFields = new List<string>();

                // Check and update the fields
                selectedCar.Make = CheckAndUpdateField(selectedCar.Make, comboMake.Text, "Make", updatedFields);
                selectedCar.Model = CheckAndUpdateField(selectedCar.Model, txtModel.Text, "Model", updatedFields);
                selectedCar.Colour = CheckAndUpdateField(selectedCar.Colour, txtColour.Text, "Colour", updatedFields);
                selectedCar.Year = CheckAndUpdateField(selectedCar.Year, (int)comboYear.SelectedItem, "Year", updatedFields);
                selectedCar.Price = CheckAndUpdateField(selectedCar.Price, price, "Price", updatedFields);
                selectedCar.NewStatus = CheckAndUpdateField(selectedCar.NewStatus, NewStatus.IsChecked == true, "New Status", updatedFields);

                // Refresh the DataGrid
                dataGridCars.ItemsSource = null;
                dataGridCars.ItemsSource = carCollection;

                // Show updated fields
                if (updatedFields.Count > 0)
                {
                    MessageBox.Show($"Updated fields: {string.Join(", ", updatedFields)}");
                }
                else
                {
                    MessageBox.Show("No fields were updated.");
                }

                ResetForm(); // Clear the inputs
                lblMessage.Content = ""; // Clear the message label
            }
            else
            {
                // Create a new car
                var newCar = new Car(comboMake.Text, txtModel.Text, txtColour.Text, (int)comboYear.SelectedItem, price, NewStatus.IsChecked == true);
                carCollection.Add(newCar);

                // Refresh the DataGrid
                dataGridCars.ItemsSource = null;
                dataGridCars.ItemsSource = carCollection;

                MessageBox.Show("Car added!");
                ResetForm(); // Clear the form
                lblMessage.Content = ""; // Clear the message label
            }
        }

        // Utility function to check and update a field
        private T CheckAndUpdateField<T>(T oldValue, T newValue, string fieldName, List<string> updatedFields)
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                updatedFields.Add(fieldName);
                return newValue;
            }
            return oldValue;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();  // Clear the form inputs
            dataGridCars.ItemsSource = null;  // Clear the DataGrid
            lblMessage.Content = "";  // Clear the message label
        }

        // Exit the application when the Exit button is clicked
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Clear form inputs and reset output fields
        private void ResetForm()
        {
            comboMake.SelectedItem = null;  // Reset the make selection
            txtModel.Clear();  // Clear the model input
            txtColour.Clear();  // Clear the colour input
            comboYear.SelectedItem = null;  // Reset the year selection
            txtPrice.Clear();  // Clear the price input
            NewStatus.IsChecked = false;  // Uncheck the "New" status checkbox
        }
    }

    // Car class definition
    public class Car
    {
        // Static property to track the total number of cars created
        public static int Count { get; private set; } = 0;

        // ReadOnly property for car's unique ID
        public int IdentificationNumber { get; }

        // Other car properties
        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool NewStatus { get; set; }

        // Default constructor: increments Count and assigns IdentificationNumber
        public Car()
        {
            Count++;
            IdentificationNumber = Count; // Assign a unique ID based on the count
        }

        // Parameterized constructor: calls the default constructor and assigns values
        public Car(string make, string model, string colour, int year, decimal price, bool newStatus) : this()
        {
            Make = make;
            Model = model;
            Colour = colour;
            Year = year;
            Price = price;
            NewStatus = newStatus;
        }
    }
}
