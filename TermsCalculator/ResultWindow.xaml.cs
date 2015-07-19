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
using System.Windows.Shapes;

namespace TermsCalculator
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow(Calculator calculator)
        {
            InitializeComponent();
            amountWithoutTerms.Text = calculator.Amount.ToString();
            TermsAmountTextBox.Text = calculator.TermsAmount.ToString();
            totalWithTermsTextBox.Text = (calculator.Amount + calculator.TermsAmount).ToString();
            vatAmountTextBox.Text = calculator.VatAmount.ToString();
            totalTextBox.Text = calculator.TotalAmount.ToString();
            
            if (calculator.IsDiscountChecked == true)
            {             
                TermsAmountTextBlock.Text = String.Format("Discount Amount (-{0}%):", ((1 - calculator.TermsPercentageDecimal) * 100).ToString());
            }
            else
            {
                TermsAmountTextBlock.Text = String.Format("Service charge amount ({0}%):", ((calculator.TermsPercentageDecimal - 1) * 100).ToString());
            }

            if (calculator.VatAmount == 0)
            {
                vatAmountTextBlock.Visibility = Visibility.Hidden;
                vatAmountTextBox.Visibility = Visibility.Hidden;
                vatTotalTextBlock.Visibility = Visibility.Hidden;
                totalTextBox.Visibility = Visibility.Hidden;

            }

            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow termsCalculator = new MainWindow();
            //termsCalculator.Show();
            this.Close();

        }

        


    }
}
