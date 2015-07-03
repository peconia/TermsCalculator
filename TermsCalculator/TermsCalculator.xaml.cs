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
    }
}
