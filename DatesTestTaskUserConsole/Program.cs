using DatesTestTaskUserConsole.UserInputHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;

namespace DatesTestTaskUserConsole
{
    class Program
    {
        static DateTime From;
        static DateTime To;
        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            var serviceProvider = DependencyInjector.Setup(new ServiceCollection(), builder.Build()).BuildServiceProvider();

            var dateService = serviceProvider.GetService<IDateService>();

            //dateService.InsertDates(DateTime.Now, DateTime.Now.AddDays(1));
            dateService.GetIntersection(DateTime.Now, DateTime.Now);

            //int a = 0;
            //using var client = new HttpClient();

            //bool checker = false;
            //Console.WriteLine("Press the number to choose an option: 1 - Add new Period of time to Database, 2 - Type datesRange and Find if database contains DatesPeriods that intersects with your period");
            //while (checker != true) {
            //    try 
            //    { 
            //        a = Convert.ToInt32(Console.ReadLine());
            //        if ((a == 1) || (a == 2))
            //        {
            //            checker = true;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Incorrect input, please type 1 or 2 to select an option ");
            //        }
                    
            //    }
            //    catch { Console.WriteLine("Incorrect input, please type 1 or 2 to select an option "); };
            //}
            //checker = false;

            //switch (a)
            //{
            //    case 1:
            //        {
            //            while (checker != true)
            //            {
            //                Console.WriteLine("Type the date From in the following format : YYYY.MM.DD");
            //                try
            //                {
            //                    From = Convert.ToDateTime(Console.ReadLine());

            //                    bool checker2 = false;
            //                    while (checker2 != true) 
            //                    {
            //                        Console.WriteLine("And now type the date To in the following format : YYYY.MM.DD");
            //                        try
            //                        {
            //                            Console.WriteLine(From.ToString());
            //                            To = Convert.ToDateTime(Console.ReadLine());

            //                            Console.WriteLine(From.ToString());
            //                            Console.WriteLine(To.ToString());                                                                                
                                                                                   
            //                        }
            //                        catch { Console.WriteLine("Invalid input try again"); }
            //                        if(From != null && To != null)
            //                        {
            //                            checker2 = true;
            //                        }                                    
            //                    }

            //                }
            //                catch { Console.WriteLine("Invalid input, try again"); };
            //                checker = true;
            //            }
            //            Console.WriteLine(From.ToString());
            //            Console.WriteLine(To.ToString());
            //            Console.ReadKey();


            //            break;
            //        }
            //    case 2:
            //        {
            //            while (checker != true)
            //            {
            //                Console.WriteLine("Type the date From in the following format : YYYY.MM.DD");
            //                try
            //                {
            //                    From = Convert.ToDateTime(Console.ReadLine());

            //                    bool checker2 = false;
            //                    while (checker2 != true)
            //                    {
            //                        Console.WriteLine("And now type the date To in the following format : YYYY.MM.DD");
            //                        try
            //                        {
            //                            To = Convert.ToDateTime(Console.ReadLine());                                       
            //                        }

            //                        catch 
            //                        { 
            //                            Console.WriteLine("Invalid input try again"); 
            //                        }
            //                        if (From != null && To != null)
            //                        {
            //                            checker2 = true;
            //                            Console.WriteLine("Rabota case2");
            //                        }
            //                    }
            //                }
            //                catch { Console.WriteLine("Invalid input, try again"); };
            //                checker = true;
            //            }

            //            Console.WriteLine(From.ToString());
            //            Console.WriteLine(To.ToString());
            //            Console.ReadKey();

            //            // создать объект ДТО с помощью введённых данных и передать его в метод поиска пересечения
            //            break;
            //        }

            //}
            //Console.WriteLine("EndOfProgramme");
            Console.ReadKey();
        }
    }
}
