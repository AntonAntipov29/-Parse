using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    internal interface IVisible
    {
        void Show(string writeLineInput);

        void ShowOnThirdLine(string writeLineInput);

        void Clear();

        void ShowSeparatorLine();
    }
}
