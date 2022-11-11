using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{

    public class TaxCalculator : BaseCalculator
    {
        public const string dollarIndex = "USD";
        public const string euroIndex = "EUR";
        public const string hryvniaIndex = "UAH";
        private double yearProfit;
        private string currency;
        private double profit;
        private double singleTaxRate = 0.05;
        private double socialContRate = 0.22;
        private const double MIN_SALARY = 6500;
        private double singleTax;
        private double socialCont;
        private double dollarRate = 39.77;
        private double euroRate = 39.4;
        private double hryvniaRate = 1;
        private double currencyVariant = 0;
        private string formatMoney = "{0:N}";

        TaxCalculatorView taxCalculatorView = new TaxCalculatorView();

        public TaxCalculator(string name, int id) : base(name, id)
        {
            base.name = name;
        }

        public string nameOfCalculator { set { name = value; } }

        public new void Start()
        {
            ShowGreeting();
            GettingInput();
            Calculation();
            AskFinalAnswer();
        }

        public override void GettingInput()
        {
            taxCalculatorView.AskFirstInput();
            currency = userInput.GetUserInput(TypeOfUserInput.currency);
            taxCalculatorView.CheckFirstInput(currency);
            taxCalculatorView.AskOfContinue();
        }

        public override void Calculation()
        {
            string[] months = { "Сiчень", "Лютий", "Березень", "Квiтень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
            string[] monthsProfit = new string[12];
            double[] monthsProfitDouble = new double[12];
            int count = 0;
            double result = 0;

            NumberFormatInfo formatComa = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ",",
            };
            NumberFormatInfo formatDot = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            for (count = 0; count < months.Length; count++)
            {
                taxCalculatorView.Clear();
                taxCalculatorView.AskSecondInput(months, count);
                monthsProfit[count] = userInput.GetUserInput(TypeOfUserInput.number);

                if (monthsProfit[count].Contains(","))
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count], formatComa);
                }
                else if (monthsProfit[count].Contains("."))
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count], formatDot);
                }
                else
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count]);
                }
                result += monthsProfitDouble[count];
            }

            if (currency == hryvniaIndex)
            {
                currencyVariant = hryvniaRate;
            }
            else if (currency == euroIndex)
            {
                currencyVariant = euroRate;
            }
            else if (currency == dollarIndex)
            {
                currencyVariant = dollarRate;
            }

            yearProfit = result;
            yearProfit = yearProfit * currencyVariant;
            singleTax = yearProfit * singleTaxRate;
            socialCont = MIN_SALARY * socialContRate;
            profit = yearProfit - singleTax - socialCont;

            taxCalculatorView.Clear();
            taxCalculatorView.CheckSecondInput(currency, formatMoney, result);
            taxCalculatorView.AskOfContinue();
            Console.ReadKey();
            taxCalculatorView.Clear();
            taxCalculatorView.ShowResult(yearProfit, singleTax, socialCont, profit, formatMoney);
        }
    }
}


