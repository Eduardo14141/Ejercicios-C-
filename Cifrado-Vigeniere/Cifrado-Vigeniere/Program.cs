using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrado_Vigeniere
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic.Logic logic = new Logic.Logic();
            logic.CreateMatrix();
            logic.startActivity();
        }
    }
}
