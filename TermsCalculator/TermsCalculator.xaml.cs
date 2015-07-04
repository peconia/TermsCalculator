using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            MessageBox.Show("Hello.");
        }

        private void discountRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            servOrDiscTextBlock.Text = "Discount %";
        }

        private void scRadioButton_Click(object sender, RoutedEventArgs e)
        {
           // if (sender == null) return;
            servOrDiscTextBlock.Text = "Service Charge %";
            
        }

        private void calculateVATCheckBox_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
