using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator_program
{
    public class AgeCalculator : BaseCalculator
    {
        public DateTime dayOfBirth;
        private DateTime timeNow = DateTime.Now;
        public string dayOfBirthString;
        private double fullYears;
        private double daysInYear = 365.24;
        private string userInputString;

        AgeCalculatorView ageCalculatorView = new AgeCalculatorView();

        public AgeCalculator(string name, int id) : base(name, id)
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
            ageCalculatorView.AskFirstInput();           
            userInputString = userInput.GetUserInput(TypeOfUserInput.date);
            dayOfBirth = DateTime.Parse(userInputString);         
            ageCalculatorView.Clear();
            dayOfBirthString = dayOfBirth.ToShortDateString();
            ageCalculatorView.CheckInput(dayOfBirthString);          
            ageCalculatorView.AskOfContinue();          
            Console.ReadKey();
            ageCalculatorView.Clear();           
        }

        public override void Calculation()
        {
            TimeSpan age = timeNow - dayOfBirth;
            fullYears = Math.Floor(age.TotalDays / daysInYear);
            ageCalculatorView.ShowResult(fullYears);       
        }
    }  
}
