using ConsoleApp1.Car.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Car.Cars;

namespace ConsoleApp1.Car.Manager
{
    internal class ScanManager
    {
        public static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                PrintError("duzgun melumat deyil,yeniden daxil edin");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }
        public static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                PrintError("duzgun melumat deyil,yeniden daxil edin");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        internal static string ReadString(string v)
        {
            throw new NotImplementedException();
        }

        public static string Readstring(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("duzgun melumat deyil,yeniden daxil edin");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static Menu ReadMenu(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!Enum.TryParse(Console.ReadLine(),out Menu m))
            {
                PrintError("Menudan secin");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
        public static FuelType ReadFuel(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!Enum.TryParse(Console.ReadLine(), out Menu m))
            {
                PrintError("Menudan secin");
                goto l1;
            }
            Console.ResetColor();
            return (FuelType)m;
        }


        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
