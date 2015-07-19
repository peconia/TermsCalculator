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
                TermsAmountTextBlock.Text = "Discount Amount:";
            }
            else
            {
                TermsAmountTextBlock.Text = "Service Charge Amount:";
            }
            
        }

        


    }
}
