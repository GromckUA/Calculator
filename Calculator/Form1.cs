using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBoxResult.Text == "0") || (isOperationPerformed))
                textBoxResult.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBoxResult.Text.Contains("."))
                {
                    textBoxResult.Text = textBoxResult.Text + button.Text;
                }
            }
            else
                textBoxResult.Text = textBoxResult.Text + button.Text;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                SumButton.PerformClick();
                operationPerformed = button.Text;
                CurrentOperationLabel.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(textBoxResult.Text);
                CurrentOperationLabel.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void CeButton_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            resultValue = 0;
        }

        private void SumButton_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBoxResult.Text = (resultValue + double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (resultValue - double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "*":
                    textBoxResult.Text = (resultValue * double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (resultValue / double.Parse(textBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(textBoxResult.Text);
            CurrentOperationLabel.Text = "";
        }
    }
}