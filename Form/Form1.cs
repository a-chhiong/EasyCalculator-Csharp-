using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyCalculatorLibrary;

namespace MyCalculatorForm
{
    public partial class Form1 : Form
    {
        private bool decimalEver = false;
        private bool euqalEver = false;
		
		private bool numberAhead = false;
		//private bool leftBracketAhead = false;
		private bool rightBracketAhead = false;
		private bool pointAhead = false;
		
        private string myExpression;
        private string myAnswer;

        public Form1()
        {
            InitializeComponent();

            myExpression = "";
            myAnswer = "start...";

            UpdateForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void UpdateForm()
        {
            labelEquation.Text = myExpression;

            labelAnswer.Text = myAnswer;
        }
        
        private void CheckAhead()
        {
            numberAhead = false;
            //leftBracketAhead = false;
            rightBracketAhead = false;
            pointAhead = false;

            if (myExpression.Length>0)
			{
				if (char.TryParse(myExpression.Substring(myExpression.Length - 1, 1), out char myASCII) == true)
				{
					if (myASCII >= 0x30 && myASCII <= 0x39)   // 0 ~ 9
					{
						numberAhead = true;
					}
					/*else if (myASCII == 0x28)    // (
					{
						leftBracketAhead = true;
					}*/
					else if (myASCII == 0x29)    // )
					{
						rightBracketAhead = true;
					}
					else if (myASCII == 0x2E)    // .
					{
						pointAhead = true;
					}
				}
			}
		}
		
        private void Clean_Click(object sender, EventArgs e)
        {
            myExpression = "";

            myAnswer = "0";

            decimalEver = false;

            euqalEver = false;

            UpdateForm();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            //myExpression...

            myAnswer = "0";

            euqalEver = false;

            UpdateForm();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (myExpression.Length == 0)
            {
                decimalEver = false;

                myExpression = "";
            }
            else
            {
				CheckAhead();
				
                if (pointAhead == true)
                {
                    decimalEver = false;
                }

                myExpression = myExpression.Remove(myExpression.Length-1, 1);
            }

            if (euqalEver == true)
            {
                euqalEver = false;

                myAnswer = "0";
            }

            UpdateForm();
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                if (myExpression.Length > 0)
                {
                    MyCompute SimpleCal = new MyCompute();

                    myAnswer = "Answer: " + SimpleCal.Execution(myExpression);

                    euqalEver = true;
                }
            }

            UpdateForm();
        }
		
        private void Left_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "(";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += ")";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
				CheckAhead();
				
                if (numberAhead == true || rightBracketAhead == true)
                {
                    decimalEver = false;
                    myExpression += "+";
                }
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
				CheckAhead();
				
                if (numberAhead == true || rightBracketAhead == true)
                {
                    decimalEver = false;
                    myExpression += "-";
                }
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Time_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
				CheckAhead();
				
                if (numberAhead == true || rightBracketAhead == true)
                {
                    decimalEver = false;
                    myExpression += "×";
                }
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Over_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
				CheckAhead();
				
                if (numberAhead == true || rightBracketAhead == true)
                {
                    decimalEver = false;
                    myExpression += "÷";
                }
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "0";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void One_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "1";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Two_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "2";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Three_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "3";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Four_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "4";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Five_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "5";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Six_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "6";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "7";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "8";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
                myExpression += "9";
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Point_Click(object sender, EventArgs e)
        {
            if (euqalEver == false)
            {
				CheckAhead();
				
                if (numberAhead == true)
                {
                    if (decimalEver == false)
                    {
                        decimalEver = true;
                        myExpression += ".";
                    }
                }
            }
            else
            {
                MessageBox.Show("Press <CE> or <C> for next operation");
            }

            UpdateForm();
        }

        private void Expression_TextChanged(object sender, EventArgs e)
        {

        }
    }
}