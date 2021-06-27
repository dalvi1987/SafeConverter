using System;

namespace SafeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string isContinue = "y";
            while (isContinue.ToLower() == "y")
            {
                Console.Clear();
                int partEval = 0;

                InvalidInput:
                Console.WriteLine("Please enter evaluation method - 1 or 2:");
                Int32.TryParse(Console.ReadLine(), out partEval);
                if(partEval == 0)
                {
                    Console.WriteLine("Invalid Choice!");
                    goto InvalidInput;
                }

                Console.WriteLine("Enter string needs to be convert to int:");               
                
                string numberInput = Console.ReadLine();
                int numberOutput = 0;

                switch (partEval)
                {
                    case 1:
                        SafeIntConverter safeConverter = new SafeIntConverter();
                        numberOutput = safeConverter.ToSafeInt(numberInput);
                        break;
                    case 2:
                        Console.WriteLine("Enter default value:");
                        int defultValue = 0;
                        Int32.TryParse(Console.ReadLine(), out defultValue);
                        numberOutput = numberInput.ToSafeInt(defultValue);
                        break;                      
                }

                

                Console.WriteLine($"Converted number is {numberOutput}");
                Console.Write("Do you want to continue y/n?: ");
                isContinue = Console.ReadLine();
            }

            //Console.ReadLine();
        }
    }

    //Part 1 
    public class SafeIntConverter
    {
        public int ToSafeInt(string numberStr)
        {
            int number;
            Int32.TryParse(numberStr, out number);
            return number;
        }
    }

    //Part2
    public static class Extension
    {
        public static int ToSafeInt(this String numberStr, int defaultValue)
        {
            SafeIntConverter safeConverter = new SafeIntConverter();
            if (numberStr == "0")
                return 0;
            else 
            {
                int number = safeConverter.ToSafeInt(numberStr);
                return number == 0 ? defaultValue : number;
            }
        }
    }
}
