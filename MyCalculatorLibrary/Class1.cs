using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculatorLibrary
{
    public class MyCompute
    {
        #region Fields

        private int countBefore;
        private int countAfter;
        private int countRemain;
        private double answer;
        private string expression;
        private string result;
        private string wrongCode;
        private string[] equation = new string[100];

        #endregion Fields

        #region Properties

        public int Before
        {
            get
            {
                return this.countBefore;
            }
        }

        public int After
        {
            get
            {
                return this.countAfter;
            }
        }

        public int Remain
        {
            get
            {
                return this.countRemain;
            }
        }

        public double Answer
        {
            get
            {
                return this.answer;
            }
        }

        public string Expression
        {
            get
            {
                return this.expression;
            }
            set
            {
                this.expression = value;
            }
        }

        public string Result
        {
            get
            {
                return this.result;
            }
        }

        #endregion Properties

        #region Constructor

        public MyCompute()
        {
            this.answer = 0;
            this.result = "";
        }

        #endregion Constructor

        #region Method

        public string Execution(string myExpression)
        {
            this.expression = myExpression;
            this.countBefore = myExpression.Length;
            this.countAfter = 0;
            this.countRemain = 0;
            this.wrongCode = "";
            this.answer = 0;
            this.result = "";

            for (int index = 0; index < 100; index++)
            {
                this.equation[index] = "";
            }

            if (this.countBefore > 100)
            {
                this.wrongCode = "10";
            }
            else if (this.countBefore == 0)
            {
                this.wrongCode = "11";
            }

            if (wrongCode == "") //no anything wrong so-far...
            {
                bool decimalEver = false;
                bool seperateEver = false;

                bool numberAhead = false;
                bool leftBracketAhead = false;
                bool rightBracketAhead = false;


                int leftCount = 0;
                int index = 0;
                do
                {
                    numberAhead = false;
                    leftBracketAhead = false;
                    rightBracketAhead = false;

                    if (index > 0)
                    {
                        if (char.TryParse(myExpression.Substring(index - 1, 1), out char myASCII) == true)
                        {
                            if (myASCII >= 0x30 && myASCII <= 0x39)   // 0 ~ 9
                            {
                                numberAhead = true;
                            }
                            else if (myASCII == 0x28)   //(
                            {
                                leftBracketAhead = true;
                            }
                            else if (myASCII == 0x29)    // )
                            {
                                rightBracketAhead = true;
                            }
                        }
                    }

                    switch (myExpression.Substring(index, 1))
                    {
                        case "=":
                            if (index != this.countBefore - 1) //not at the very last one...
                            {
                                this.wrongCode = "03";
                            }
                            break;

                        case "(":

                            leftCount++;

                            if (numberAhead == true || rightBracketAhead == true)
                            {
                                this.countAfter++;

                                this.equation[this.countAfter] = "×";
                            }

                            if (index > 0) //initially...
                            {
                                this.countAfter++;
                            }

                            this.equation[this.countAfter] = "(";

                            seperateEver = true;

                            decimalEver = false;

                            break;

                        case ")":
                            if (leftCount > 0)
                            {
                                leftCount--;

                                if (leftBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "0";
                                }

                                this.countAfter++;

                                this.equation[this.countAfter] = ")";

                                seperateEver = true;

                                decimalEver = false;
                            }
                            else
                            {
                                this.wrongCode = "04";
                            }

                            break;

                        case "+":
                            if (numberAhead == true || rightBracketAhead == true)
                            {
                                this.countAfter++;

                                this.equation[this.countAfter] = "+";

                                seperateEver = true;

                                decimalEver = false;
                            }
                            else
                            {
                                this.wrongCode = "01";
                            }
                            break;

                        case "-":
                            if (numberAhead == true || rightBracketAhead == true)
                            {
                                this.countAfter++;

                                this.equation[this.countAfter] = "-";

                                seperateEver = true;

                                decimalEver = false;
                            }
                            else
                            {
                                this.wrongCode = "01";
                            }
                            break;

                        case "×":
                        case "*":
                            if (numberAhead == true || rightBracketAhead == true)
                            {
                                this.countAfter++;

                                this.equation[this.countAfter] = "×";

                                seperateEver = true;

                                decimalEver = false;
                            }
                            else
                            {
                                this.wrongCode = "01";
                            }
                            break;

                        case "÷":
                        case "/":
                            if (numberAhead == true || rightBracketAhead == true)
                            {
                                this.countAfter++;

                                this.equation[this.countAfter] = "÷";

                                seperateEver = true;

                                decimalEver = false;
                            }
                            else
                            {
                                this.wrongCode = "01";
                            }
                            break;

                        case "0":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "0";

                            break;

                        case "1":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "1";

                            break;

                        case "2":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "2";

                            break;

                        case "3":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "3";

                            break;

                        case "4":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "4";

                            break;

                        case "5":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "5";

                            break;

                        case "6":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "6";

                            break;

                        case "7":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "7";

                            break;

                        case "8":
                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "8";

                            break;

                        case "9":

                            if (seperateEver == true)
                            {
                                seperateEver = false;

                                if (rightBracketAhead == true)
                                {
                                    this.countAfter++;

                                    this.equation[this.countAfter] = "×";
                                }

                                this.countAfter++;
                            }

                            this.equation[this.countAfter] += "9";

                            break;

                        case ".":
                            if (numberAhead == true)
                            {
                                if (decimalEver == false)
                                {
                                    decimalEver = true;

                                    this.equation[this.countAfter] += ".";
                                }
                                else
                                {
                                    this.wrongCode = "02";
                                }
                            }
                            else
                            {
                                this.wrongCode = "02";
                            }
                            break;

                        default:
                            this.wrongCode = "99";
                            break;
                    }

                    index++;
                }
                while (index < this.countBefore && this.wrongCode == "");

                if (this.wrongCode == "")
                {
                    while (leftCount > 0)
                    {
                        this.countAfter++;

                        this.equation[this.countAfter] = ")";

                        leftCount--;
                    }

                    this.countRemain = this.countAfter;
                }
            }

            if (this.wrongCode == "") //no anything wrong so-far...
            {
                int leftCount = 0;
                int leftIndex = 0;
                int rightIndex = 0;
                int index = 0;

                do
                {
                    if (this.equation[index] == "(")
                    {
                        leftCount++;

                        leftIndex = index;

                        index++;
                    }
                    else if (this.equation[index] == ")")
                    {
                        if (leftCount > 0)
                        {
                            leftCount = 0;

                            rightIndex = index;

                            Arithmetic(leftIndex, rightIndex);

                            index = 0;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    else
                    {
                        index++;
                    }

                }
                while (index <= this.countRemain && this.wrongCode == "");

                if (this.wrongCode == "") //no anything wrong so-far...
                {
                    Arithmetic(0, this.countRemain);

                    if (this.countRemain > 0)
                    {
                        this.wrongCode = "20";
                    }
                }
            }

            if (this.wrongCode == "") //no anything wrong so-far...
            {
                this.result = this.equation[this.countRemain];

                return Result;
            }
            else
            {
                switch (this.wrongCode)
                {
                    default:
                        return "Unknown Error";

                    case "01":
                        return "Incorrect operator expression";

                    case "02":
                        return "Incorrect decimal point expression";

                    case "03":
                        return "Incorrect equal sign expression";

                    case "04":
                        return "Incorrect bracket expression";

                    case "10":
                        return "Beyond limitation?!";

                    case "11":
                        return "Nothing to start with...";

                    case "30":
                        return "Arithmetic Overflow";

                    case "31":
                        return "Arithmetic Error";

                    case "99":
                        return "Unsupported expression";
                }
            }
        }

        private void Arithmetic(int start, int finish)
        {
            this.answer = 0;

            int index;
            int element;

            double operandLeft;
            double operandRight;

            if (this.equation[start] == "(" && this.equation[finish] == ")")
            {
                this.countRemain -= 1;

                for (element = finish; element <= this.countRemain; element++)
                {
                    this.equation[element] = this.equation[element + 1];
                }

                finish -= 1;

                //////////////////////////////

                this.countRemain -= 1;

                for (element = start; element <= this.countRemain; element++)
                {
                    this.equation[element] = this.equation[element + 1];
                }

                finish -= 1;
            }
            else if (this.equation[start] == "(" || this.equation[finish] == ")")
            {
                this.wrongCode = "31";
            }

            if (this.wrongCode == "")
            {
                index = start;

                do
                {
                    if (this.equation[index] == "×" || this.equation[index] == "÷")
                    {
                        if (double.TryParse(this.equation[index - 1], out operandLeft) == false)
                        {
                            this.wrongCode = "31";
                        }

                        if (double.TryParse(this.equation[index + 1], out operandRight) == false)
                        {
                            this.wrongCode = "31";
                        }

                        if (this.wrongCode == "")
                        {
                            if (this.equation[index] == "×")
                            {
                                checked
                                {
                                    try
                                    {
                                        answer = operandLeft * operandRight;
                                    }
                                    catch (OverflowException)
                                    {
                                        answer = 0;
                                        this.wrongCode = "30";
                                    }
                                }
                            }
                            else if (this.equation[index] == "÷")
                            {
                                checked
                                {
                                    try
                                    {
                                        answer = operandLeft / operandRight;
                                    }
                                    catch (OverflowException)
                                    {
                                        answer = 0;
                                        this.wrongCode = "30";
                                    }
                                }
                            }

                            this.equation[index - 1] = Convert.ToString(answer);

                            this.countRemain -= 2;

                            for (element = index; element <= this.countRemain; element++)
                            {
                                this.equation[element] = this.equation[element + 2];
                            }

                            finish -= 2;
                        }
                    }
                    else
                    {
                        index++;
                    }
                }
                while (index <= finish && this.wrongCode == "");
            }

            if (this.wrongCode == "")
            {
                answer = 0;

                index = start;  //from 1 rather than 0...
                do
                {
                    if (this.equation[index] == "+" || this.equation[index] == "-")
                    {
                        if (double.TryParse(this.equation[index - 1], out operandLeft) == false)
                        {
                            this.wrongCode = "31";
                        }

                        if (double.TryParse(this.equation[index + 1], out operandRight) == false)
                        {
                            this.wrongCode = "31";
                        }

                        if (this.wrongCode == "")
                        {
                            if (this.equation[index] == "+")
                            {
                                checked
                                {
                                    try
                                    {
                                        answer = operandLeft + operandRight;
                                    }
                                    catch (OverflowException)
                                    {
                                        answer = 0;
                                        this.wrongCode = "30";
                                    }
                                }
                            }
                            else if (this.equation[index] == "-")
                            {
                                checked
                                {
                                    try
                                    {
                                        answer = operandLeft - operandRight;
                                    }
                                    catch (OverflowException)
                                    {
                                        answer = 0;
                                        this.wrongCode = "30";
                                    }
                                }
                            }

                            this.equation[index - 1] = Convert.ToString(answer);

                            this.countRemain -= 2;

                            for (element = index; element <= this.countRemain; element++)
                            {
                                this.equation[element] = this.equation[element + 2];
                            }

                            finish -= 2;
                        }
                    }
                    else
                    {
                        index++;
                    }
                }
                while (index <= finish && this.wrongCode == "");
            }
        }

        #endregion Method
    }
}