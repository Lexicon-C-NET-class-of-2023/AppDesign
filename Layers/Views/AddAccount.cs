using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views
{
    public static class AddAccount
    {
        public static string NewAccount()
        {
            string name;
            string age;
            bool invalid = true;
            
            do
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();
                Console.WriteLine("Please enter your age:");
                age = Console.ReadLine();
                if (!name.Contains(',') && !age.Contains(',')) invalid = false;
            } while (invalid);

            return $"{name},{age}";
        }
    }
}
