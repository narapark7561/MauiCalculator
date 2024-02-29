using System;
using Microsoft.Maui.Controls;

namespace Lab4NaraCalculator
{
    public partial class MainPage : ContentPage
    {
        // Variables to keep track of the number entered and the current operation.
        double currentNumber = 0;
        string currentOperation = "";

        public MainPage()
        {
            InitializeComponent();
        }

        // Handles clicks on number buttons.
        public void OnNumberClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (DisplayLabel.Text == "0" || currentOperation != "")
                DisplayLabel.Text = button.Text;
            else
                DisplayLabel.Text += button.Text;

        }

        // Handles clicks on operator buttons (+, -, ×, ÷).
        public void OnOperatorClick(object sender, EventArgs e)
        {
            currentNumber = double.Parse(DisplayLabel.Text);
            currentOperation = (sender as Button).Text;

        }

        // Calculates the result when the equals button is clicked.
        public void OnCalculateClick(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(DisplayLabel.Text);
            double result = 0;


            // Performs calculation based on the operation.
            switch (currentOperation)
            {
                case "+": result = currentNumber + secondNumber; break;
                case "-": result = currentNumber - secondNumber; break;
                case "×": result = currentNumber * secondNumber; break; 
                case "÷": 
                    if (secondNumber == 0)
                    {
                        DisplayLabel.Text = "Error"; 
                        return; 
                    }
                    result = currentNumber / secondNumber;
                    break;
                default: return; 
            }

            DisplayLabel.Text = result.ToString();
            currentOperation = ""; 
        }

        // Resets the calculator to its initial state.
        public void OnClearClick(object sender, EventArgs e)
        {
            currentNumber = 0;
            currentOperation = "";
            DisplayLabel.Text = "0";
        }
    }
}
