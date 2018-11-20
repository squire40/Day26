using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day26
{
    class Program
    {
        static void Main(string[] args)
        {
            var actual = Console.ReadLine();
            var expected = Console.ReadLine();

            Console.WriteLine(CalculateFine(actual, expected));
            Console.ReadKey();
        }

        private static int CalculateFine(string actual, string expected)
        {
            DateTime actualDate = ConvertInputToDate(actual);
            var expectedDate = ConvertInputToDate(expected);

            if (actualDate <= expectedDate)
            {
                return 0;
            }
            if (actualDate.Month == expectedDate.Month && actualDate.Year == expectedDate.Year)
            {
                return 15 * SubtractDays(actualDate, expectedDate);
            }
            if (actualDate.Year == expectedDate.Year)
            {
                return 500 * SubtractMonths(actualDate, expectedDate);
            }

            return 10000;
        }

        private static int SubtractMonths(DateTime actualDate, DateTime expectedDate)
        {
            return actualDate.Month - expectedDate.Month;
        }

        private static DateTime ConvertInputToDate(string input)
        {
            DateTime result;

            var arr = input.Split(' ');

            result = DateTime.Parse($"{arr[1]}/{arr[0]}/{arr[2]}");

            return result;
        }

        private static int SubtractDays(DateTime actualDate, DateTime expectedDate)
        {
            return Convert.ToInt32((actualDate - expectedDate).TotalDays);
        }
    }
}
