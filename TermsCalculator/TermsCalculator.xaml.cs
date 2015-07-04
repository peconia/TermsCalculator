﻿using System;
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

            //MessageBox.Show("Hello.");
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
            double result;
            if (!Double.TryParse(amountBox.Text, out result)) {
                MessageBox.Show("Please enter number as amount!");
            }
        }

        private void vatPercentage_LostFocus(object sender, RoutedEventArgs e)
        {

            checkPercentage(vatPercentage.Text);

        }

        private void checkPercentage(string entered_text)
        {
            double result;
            if (!Double.TryParse(entered_text, out result))
            {
                MessageBox.Show("Please enter a percentage between 0 and 100!");
                return;

            }

            double enteredAmount = Double.Parse(entered_text, NumberStyles.AllowDecimalPoint);

            if (enteredAmount <= 0)
            {
                MessageBox.Show("The percentage must be more than 0!");
            }
            else if (enteredAmount > 100.0)
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
