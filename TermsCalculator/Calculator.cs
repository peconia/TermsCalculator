using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TermsCalculator
{
    class Calculator
    {

        private decimal amount, vatAmount, vatPercentageDecimal, termsPercentageDecimal, termsAmount, totalAmount, result;

        public decimal TotalAmount
        {
            get { return Math.Round(totalAmount, 2); }
            set { totalAmount = value; }
        }

        public decimal TermsAmount
        {
            get { return Math.Round(termsAmount, 2); }
            set { termsAmount = value; }
        }

        public decimal TermsPercentageDecimal
        {
            get { return termsPercentageDecimal; }
            set { termsPercentageDecimal = value; }
        }

        public decimal VatPercentageDecimal
        {
            get { return vatPercentageDecimal; }
            set { vatPercentageDecimal = value; }
        }

        public decimal VatAmount
        {
            get { return Math.Round(vatAmount, 2); }
            set { vatAmount = value; }
        }

        public decimal Amount
        {
            get { return Math.Round(amount, 2); }
            set { amount = value; }
        }

        private string amountText, termsText, vatText;
        private bool isDiscountChecked, termsAlreadyIncluded, includeVATCalculation, vatAlreadyIncluded;

        public bool IncludeVATCalculation
        {
            get { return includeVATCalculation; }
            set { includeVATCalculation = value; }
        }

        public bool IsDiscountChecked
        {
            get { return isDiscountChecked; }
            set { isDiscountChecked = value; }
        }

        public Calculator()
        {
            this.amountText = "";
            this.termsText = "";
            this.vatText = "";
            this.isDiscountChecked = false;
            this.termsAlreadyIncluded = false;
            this.includeVATCalculation = false;
            this.vatAlreadyIncluded = false;
        }

        public void updateCalculator(string amountText, string termsText, bool isDiscountChecked, bool termsAlreadyIncluded)
        {
            this.amountText = amountText;
            this.termsText = termsText;
            this.IsDiscountChecked = isDiscountChecked;
            this.termsAlreadyIncluded = termsAlreadyIncluded;
            

        }

        public void updateCalculator(string amountText, string termsText, string vatText, bool isDiscountChecked, bool termsAlreadyIncluded, bool vatAlreadyIncluded)
        {
            this.amountText = amountText;
            this.termsText = termsText;
            this.IsDiscountChecked = isDiscountChecked;
            this.termsAlreadyIncluded = termsAlreadyIncluded;
            this.vatAlreadyIncluded = vatAlreadyIncluded;
            this.vatText = vatText;

        }

        
        
        public void updateFigures()
        {

            // ensure the amount entered is amount double
            if (!Decimal.TryParse(this.amountText, out result))
            {
                MessageBox.Show("Please enter an amount to start calculating!");
                return;
            }
            else
            {
                this.Amount = Decimal.Parse(amountText, NumberStyles.AllowDecimalPoint);
            }


            // ensure the terms have been entered correctly and calculate percentage
            if (!String.IsNullOrEmpty(this.termsText))
            {
                this.TermsPercentageDecimal = Decimal.Parse(this.termsText, NumberStyles.AllowDecimalPoint);
                if (this.IsDiscountChecked == true)
                {
                    this.TermsPercentageDecimal = (100 - this.TermsPercentageDecimal) / 100;
                }
                else
                {
                    this.TermsPercentageDecimal = (100 + this.TermsPercentageDecimal) / 100;
                }

            }
            
            else
            {
                MessageBox.Show("please enter the service carge or discount %");
                return;
            }

            // Calculate values for all cases

            // If VAT is not included
            if (this.IncludeVATCalculation == false)
            {
                this.VatAmount = 0;

                // terms not already included
                if (this.termsAlreadyIncluded == false)
                {
                    this.TermsAmount = this.Amount * this.TermsPercentageDecimal - this.Amount;
                }
                // terms already included in amount
                else
                {
                    this.Amount = this.Amount / this.TermsPercentageDecimal;
                    this.TermsAmount = this.Amount * this.TermsPercentageDecimal - this.Amount;
                }
            }
            else
            {
                // VAT is to be calculated
                // check VAT has been entered correctly
                if (String.IsNullOrEmpty(this.vatText))
                {
                    MessageBox.Show("Please enter the VAT %");
                    return;
                }
                else
                {
                    this.VatPercentageDecimal = (Decimal.Parse(this.vatText) + 100) / 100;
                }


                // VAT already included in amount
                if (vatAlreadyIncluded == true)
                {
                    // terms not already included
                    if (termsAlreadyIncluded == false)
                    {
                        // remove VAT first
                        this.Amount = this.Amount / this.VatPercentageDecimal;

                        this.TermsAmount = this.Amount * this.TermsPercentageDecimal - this.Amount;
                        this.VatAmount = (this.Amount + this.TermsAmount) * this.VatPercentageDecimal - (this.Amount + this.TermsAmount);
                    }
                    // terms already included in amount
                    else
                    {
                        // remove VAT first
                        this.Amount = this.Amount / this.VatPercentageDecimal;
                        // then remove terms
                        this.Amount = this.Amount / this.TermsPercentageDecimal;

                        this.TermsAmount = this.Amount * this.TermsPercentageDecimal - this.Amount;
                        this.VatAmount = (this.Amount + this.TermsAmount) * this.VatPercentageDecimal - (this.Amount + this.TermsAmount);
                    }
                }
                else
                {
                    // VAT not already included
                    if (termsAlreadyIncluded == false)
                    {
                        this.TermsAmount = this.Amount * this.TermsPercentageDecimal - this.Amount;
                        this.VatAmount = (this.Amount + this.TermsAmount) * this.VatPercentageDecimal - (this.Amount + this.TermsAmount);
                    }
                    // terms already included in amount
                    else
                    {
                        //  remove terms
                        this.Amount = this.Amount / this.TermsPercentageDecimal;

                        this.TermsAmount = this.Amount * this.TermsPercentageDecimal - this.Amount;
                        this.VatAmount = (this.Amount + this.TermsAmount) * this.VatPercentageDecimal - (this.Amount + this.TermsAmount);
                    }
                }
            }
            this.TotalAmount = this.Amount + this.TermsAmount + this.VatAmount;
            totalAmount = amount + termsAmount + vatAmount;

            MessageBox.Show("The amount with no Terms is: " + Math.Round(amount, 2) + "\n"
                + "The terms amount is: " + Math.Round(termsAmount, 2) + "\n"
                + "The amount including terms is: " + Math.Round((amount + termsAmount), 2) + "\n"
                + "The VAT amount is: " + Math.Round(vatAmount, 2) + "\n"
                + "the total is: " + Math.Round(totalAmount, 2));

            
        }
            



                
            }


                //private void discountRadioButton_Checked(object sender, RoutedEventArgs e)
                //{
                //    servOrDiscTextBlock.Text = "Discount %";
                //}

                //private void scRadioButton_Click(object sender, RoutedEventArgs e)
                //{
                //    servOrDiscTextBlock.Text = "Service Charge %";

                //    }

                //    private void calculateVATCheckBox_Click(object sender, RoutedEventArgs e)
                //    {
                //        // enable all the VAT related fields if checkbox is checked
                //        if (calculateVATCheckBox.IsChecked == true)
                //        {
                //            vatPercentage.IsEnabled = true;
                //            vatAlredyIncludedCheckBox.IsEnabled = true;
                //            vatAlredyIncludedCheckBox.Foreground = Brushes.Black;
                //            vatPercentageTextBlock.IsEnabled = true;
                //            vatPercentageTextBlock.Foreground = Brushes.Black;
                //        }
                //        else
                //        {
                //            vatPercentage.IsEnabled = false;
                //            vatAlredyIncludedCheckBox.IsEnabled = false;
                //            vatAlredyIncludedCheckBox.Foreground = Brushes.Gray;
                //            vatPercentageTextBlock.IsEnabled = false;
                //            vatPercentageTextBlock.Foreground = Brushes.Gray;
                //        }
                //    }


                //    private void amountBox_LostFocus(object sender, RoutedEventArgs e)
                //    {
                //        decimal result;
                //        if (!Decimal.TryParse(amountBox.Text, out result)) {
                //            MessageBox.Show("Please enter number as amount!");
                //        }
                //    }

                //    private void vatPercentage_LostFocus(object sender, RoutedEventArgs e)
                //    {

                //        checkPercentage(vatPercentage.Text);

                //    }

                //    private void checkPercentage(string entered_text)
                //    {
                //        decimal result;
                //        if (!Decimal.TryParse(entered_text, out result))
                //        {
                //            MessageBox.Show("Please enter a percentage between 0 and 100!");
                //            return;

                //        }

                //        decimal enteredAmount = Decimal.Parse(entered_text, NumberStyles.AllowDecimalPoint);

                //        if (enteredAmount <= 0)
                //        {
                //            MessageBox.Show("The percentage must be more than 0!");
                //        }
                //        else if (enteredAmount > 100)
                //        {
                //            MessageBox.Show("The percentage must be less than 100!");
                //        }
                //    }

                //    private void termsPercentage_LostFocus(object sender, RoutedEventArgs e)
                //    {
                //        checkPercentage(termsPercentage.Text);
                //    }




                //}
            }



        
    

