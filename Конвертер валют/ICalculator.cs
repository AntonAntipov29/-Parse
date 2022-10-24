using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculator_program
{
    internal interface ICalculator
    {
        void Show();
        
        void GettingInput();

        void Calculation();

        void ShowGreeting();

        void AskFinalAnswer();
        
    }
}
