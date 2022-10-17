﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator_program
{
    public class AgeCalculator : BaseCalculator
    {
        private DateTime dayOfBirth;
        private DateTime timeNow = DateTime.Now;
        private double fullYears;
        private double daysInYear = 365.24;

        public AgeCalculator(string name, int id) : base(name, id)
        {
            base.name = name;
        }

        public string nameOfCalculator
        {
            set { name = value; }
        }

        public void Show()
        {
            GettingInput();
            Calculation();
            AskFinalAnswer();
        }

        private void GettingInput()
        {

            Console.WriteLine($"Ви обрали {name}.");
            Console.WriteLine("Введiть дату народження в форматi дд.мм.рррр :");
            string userInputString = userInput.GetUserInput(TypeOfUserInput.date);
            dayOfBirth = DateTime.Parse(userInputString);
            Console.Clear();
            Console.WriteLine($"Ви ввели дату: {dayOfBirth.ToShortDateString()}");
            Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
            Console.ReadKey();
            Console.Clear();
        }

        private void Calculation()
        {
            TimeSpan age = timeNow - dayOfBirth;
            fullYears = age.TotalDays / daysInYear;
            Console.WriteLine("Вам " + Math.Floor(fullYears) + " рокiв");
            Console.WriteLine(" ");
        }
    }
}
