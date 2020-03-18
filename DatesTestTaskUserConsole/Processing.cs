using DatesTestTaskUserConsole.UserInputHandler;
using System;

namespace DatesTestTaskUserConsole
{
    public interface IProcessing
    {
        void ProcessingUserInput();
    }
    public class Processing : IProcessing
    {
        private readonly IDateService _dateService;
        public Processing(IDateService dateService)
        {
            _dateService = dateService;
        }

        static DateTime From;
        static DateTime To;
        public void ProcessingUserInput()
        {
            int a = 0;
            bool checker = false;
            Console.WriteLine("Press the number to choose an option: 1 - Add new Period of time to Database, 2 - Type datesRange and Find if database contains DatesPeriods that intersects with your period");
            while (checker != true)
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if ((a == 1) || (a == 2))
                    {
                        checker = true;
                    }

                }
                catch { Console.WriteLine("Incorrect input, please type 1 or 2 to select an option "); };
            }
            checker = false;

            switch (a)
            {
                case 1:
                    {
                        while (checker != true)
                        {
                            Console.WriteLine("Type the date From in the following format : YYYY.MM.DD");
                            try
                            {
                                From = Convert.ToDateTime(Console.ReadLine());

                                bool checker2 = false;
                                while (checker2 != true)
                                {
                                    Console.WriteLine("And now type the date To in the following format : YYYY.MM.DD");
                                    try
                                    {
                                        To = Convert.ToDateTime(Console.ReadLine());

                                    }
                                    catch { Console.WriteLine("Invalid input try again"); }
                                    if (From != null && To != null)
                                    {
                                        checker2 = true;
                                    }
                                }

                            }
                            catch { Console.WriteLine("Invalid input, try again"); };
                            checker = true;
                        }
                        _dateService.InsertDates(From, To);
                   
                        break;
                    }
                case 2:
                    {
                        while (checker != true)
                        {
                            Console.WriteLine("Type the date From in the following format : YYYY.MM.DD");
                            try
                            {
                                From = Convert.ToDateTime(Console.ReadLine());

                                bool checker2 = false;
                                while (checker2 != true)
                                {
                                    Console.WriteLine("And now type the date To in the following format : YYYY.MM.DD");
                                    try
                                    {
                                        To = Convert.ToDateTime(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Invalid input try again");
                                    }
                                    if (From != null && To != null)
                                    {
                                        checker2 = true;
                                    }
                                }
                            }
                            catch { Console.WriteLine("Invalid input, try again"); };
                            checker = true;
                        }
                        _dateService.GetIntersection(From, To);
                        break;
                    }

            }
        }
    }
}
