using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj7_1_Dudda
{
    public partial class frmSimpleCalculator : Form
    {
        public frmSimpleCalculator()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // validation needed before we let the program continue
            if (HasValidInput())
            {
                // if validation is successful, go ahead and do the math
                decimal result = Calculate();
                // then we output the result with four decimals.
                txtResult.Text = result.ToString("n4");
            }
        }

        // clear the box when text boxes are changed
        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

private bool HasValidInput()
{
            if (!ValidateOperand(txtOperand1.Text))
            {
                MessageBox.Show("Please enter a number between 0 and 1,000,000 for Operand 1.");
                return false;
            }
            else if (!ValidateOperand(txtOperand2.Text))
            {
                MessageBox.Show("Please enter a number between 0 and 1,000,000 for Operand 2.");
                return false;
            }
            else if (!IsOperator(txtOperator.Text))
            {
                MessageBox.Show("Please enter a valid operator.  It must be one of:\n + - * /");
                return false;
            }
            else
            {
                return true;
            }
}

        private decimal Calculate()
        {
            // for now, just make sure we can get a result
            decimal operand1 = decimal.Parse(txtOperand1.Text);
            decimal operand2 = decimal.Parse(txtOperand2.Text);
            string op1 = txtOperator.Text;
            decimal result = 0m;
           
            switch (op1)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;
                default:
                    // do nothing, we didn't get a valid operator
                    break;
            }
            return result;
        }


        // validate the operands
        private bool ValidateOperand(string oper)
        {
            return IsPresent(oper) && IsDecimal(oper) && IsValidData(oper);
        }

        // validation methods for operands
        private bool IsPresent(string toCheck)
        {
            return toCheck != "";
        }

        private bool IsDecimal(string toCheck)
        {
            decimal whatevs;  // disposable local variable to keep code from breaking
            if (decimal.TryParse(toCheck, out whatevs))
            { 
                return true; 
            }
            else { return false; }
        }

        private bool IsValidData(string toCheck)
        {
            decimal someNumber = decimal.Parse(toCheck);
            if (someNumber <= 0 || someNumber >= 1000000) 
            {
                return false;
            }
            else { return true; }
        }

        // validate the operator
        private bool IsOperator(string symbol)
        {
            return symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";
        }

        
    } // end frmSimpleCalculator
}
