using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class Calculator : Form
    {
        enum Operator { Add, Substract, Multiply, Division }
        Operator calcOperator = Operator.Add;
        int phase = 0;
        decimal num1 = 0, num2 = 0;
        public Calculator()
        {
            InitializeComponent();
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (resultLabel.Text == "0")
            {
                resultLabel.Text = "";
            }
            resultLabel.Text += button.Tag.ToString();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            resultLabel.Text = "0";
            phase = 0;
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            decimal.TryParse(resultLabel.Text, out num2);
            switch (calcOperator)
            {
                case Operator.Add:
                    num1 = num1 + num2;
                    break;
                case Operator.Substract:
                    num1 = num1 - num2;
                    break;
                case Operator.Multiply:
                    num1 = num1 * num2;
                    break;
                case Operator.Division:
                    try
                    {
                        num1 = num1 / num2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            resultLabel.Text = num1.ToString();
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch (button.Tag)
            {
                case "0":
                    calcOperator = Operator.Add;
                    break;
                case "1":
                    calcOperator = Operator.Substract;
                    break;
                case "2":
                    calcOperator = Operator.Multiply;
                    break;
                case "3":
                    calcOperator = Operator.Division;
                    break;
            }
            decimal.TryParse(resultLabel.Text, out num1);
            resultLabel.Text = "0";
            phase = 1;
            Debug.WriteLine("operator : {0}", button.Tag);
        }
    }

}
