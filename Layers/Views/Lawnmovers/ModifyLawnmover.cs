using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Views.Lawnmovers
{
    internal class ModifyLawnmover
    {
        public static string Property(char property)
        {
            string key = property switch
            {
                '1' => "Available",
                '2' => "Model",
                '3' => "PricePerDay",
                '4' => "PricePerWeek",
                '5' => "DateOfRent",
                '6' => "DateOfReturn",
                _ => ""
            };

            Console.WriteLine($"Please enter new {key}:");
            return Console.ReadLine();
        }
    }
}
