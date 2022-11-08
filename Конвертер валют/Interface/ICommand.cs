using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    internal interface ICommand
    {
        void OnExitEntered();

        void OnMainMenuEntered();
    }
}
