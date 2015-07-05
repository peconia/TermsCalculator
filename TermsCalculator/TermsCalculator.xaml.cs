using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace TermsCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {

            decimal amount, vatAmount, vatPercentageDecimal, termsPercentageDecimal, termsAmount, totalAmount, result;
            
           // ensure the amount entered is amount double
            if (!Decimal.TryParse(amountBox.Text, out result))
            {
                MessageBox.Show("Please enter an amount to start calculating!");
                return;
            }
            else
            {
                amount = Decimal.Parse(amountBox.Text, NumberStyles.AllowDecimalPoint);
                
            }

            // ensure the terms have been entered correctly and calculate percentage
            if (!String.IsNullOrEmpty(termsPercentage.Text))
            {
                termsPercentageDecimal = Decimal.Parse(termsPercentage.Text, NumberStyles.AllowDecimalPoint);
                if (discountRadioButton.IsChecked == true)
                {
                    termsPercentageDecimal = (100 - termsPercentageDecimal) / 100;
                }
                else
                {
                    termsPercentageDecimal = (100 + termsPercentageDecimal) / 100;
                }
            }
            else
            {
                MessageBox.Show("Please enter the service carge or discount %");
                return;
            }

            // Calculate values for all cases

            // If VAT is not included
            if (calculateVATCheckBox.IsChecked == false)
            {
                vatAmount = 0;
         

                // terms not already included
                if (termsIncludedCheckBox.IsChecked == false)
                {
                    termsAmount = amount * termsPercentageDecimal - amount;
                }
                // terms already included in amount
                else
                {
                    amount = amount / termsPercentageDecimal;
                    termsAmount = amount * termsPercentageDecimal - amount;
                }
            }
            else
            {
            // VAT is to be calculated
                // check VAT has been entered correctly
                if (String.IsNullOrEmpty(vatPercentage.Text))
                {
                    MessageBox.Show("Please enter the VAT %");
                    return;
                }
                else
                {
                    vatPercentageDecimal = (Decimal.Parse(vatPercentage.Text) + 100) / 100;
                }
            

                // VAT already included in amount
                if (vatAlredyIncludedCheckBox.IsChecked == true)
                {
                    // terms not already included
                    if (termsIncludedCheckBox.IsChecked == false)
                    {
                        // remove VAT first
                        amount = amount / vatPercentageDecimal;

                        termsAmount = amount * termsPercentageDecimal - amount;
                        vatAmount = (amount + termsAmount) * vatPercentageDecimal - (amount + termsAmount);
                    }
                    // terms already included in amount
                    else
                    {
                        // remove VAT first
                        amount = amount / vatPercentageDecimal;
                        // then remove terms
                        amount = amount / termsPercentageDecimal;

                        termsAmount = amount * termsPercentageDecimal - amount;
                        vatAmount = (amount + termsAmount) * vatPercentageDecimal - (amount + termsAmount);
                    }
                }
                else
                {
                    // VAT not already included
                    if (termsIncludedCheckBox.IsChecked == false)
                    {
                        termsAmount = amount * termsPercentageDecimal - amount;
                        vatAmount = (amount + termsAmount) * vatPercentageDecimal - (amount + termsAmount);
                    }
                    // terms already included in amount
                    else
                    {
                        //  remove terms
                        amount = amount / termsPercentageDecimal;

                        termsAmount = amount * termsPercentageDecimal - amount;
                        vatAmount = (amount + termsAmount) * vatPercentageDecimal - (amount + termsAmount);
                    }
                }
            }
                
          

            totalAmount = amount + termsAmount + vatAmount;

            MessageBox.Show("The amount with no Terms is: " + amount + "\n"
                + "The terms amount is: " + termsAmount + "\n"
                + "The amount including terms is: " + (amount + termsAmount) + "\n"
                + "The VAT amount is: " + vatAmount + "\n"
                + "the total is: " + totalAmount);
        }


        private void discountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            servOrDiscTextBlock.Text = "Discount %";
        }

        private void scRadioButton_Click(object sender, RoutedEventArgs e)
        {
            servOrDiscTextBlock.Text = "Service Charge %";
            
        }

        private void calculateVATCheckBox_Click(object sender, RoutedEventArgs e)
        {
            // enable all the VAT related fields if checkbox is checked
            if (calculateVATCheckBox.IsChecked == true)
            {
                vatPercentage.IsEnabled = true;
                vatAlredyIncludedCheckBox.IsEnabled = true;
                vatAlredyIncludedCheckBox.Foreground = Brushes.Black;
                vatPercentageTextBlock.IsEnabled = true;
                vatPercentageTextBlock.Foreground = Brushes.Black;
            }
            else
            {
                vatPercentage.IsEnabled = false;
                vatAlredyIncludedCheckBox.IsEnabled = false;
                vatAlredyIncludedCheckBox.Foreground = Brushes.Gray;
                vatPercentageTextBlock.IsEnabled = false;
                vatPercentageTextBlock.Foreground = Brushes.Gray;
            }
        }


        private void amountBox_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal result;
            if (!Decimal.TryParse(amountBox.Text, out result)) {
                MessageBox.Show("Please enter number as amount!");
            }
        }

        private void vatPercentage_LostFocus(object sender, RoutedEventArgs e)
        {

            checkPercentage(vatPercentage.Text);

        }

        private void checkPercentage(string entered_text)
        {
            decimal result;
            if (!Decimal.TryParse(entered_text, out result))
            {
                MessageBox.Show("Please enter a percentage between 0 and 100!");
                return;

            }

            decimal enteredAmount = Decimal.Parse(entered_text, NumberStyles.AllowDecimalPoint);

            if (enteredAmount <= 0)
            {
                MessageBox.Show("The percentage must be more than 0!");
            }
            else if (enteredAmount > 100)
            {
                MessageBox.Show("The percentage must be less than 100!");
            }
        }

        private void termsPercentage_LostFocus(object sender, RoutedEventArgs e)
        {
            checkPercentage(termsPercentage.Text);
        }

   


    }
}
