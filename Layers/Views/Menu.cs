using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views
{
    public static class Menu
    {
        public static void AppMenu()
        {
            Console.WriteLine("Menu with menu options");
        }

        public static char GetChoice()
        {
            char letter = 'A';
            return letter;
        }
    }
}
