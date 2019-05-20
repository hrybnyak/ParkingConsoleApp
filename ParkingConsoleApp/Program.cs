using System;
using ParkingClassLibrary;
using System.IO;

namespace ParkingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                using (FileStream fs = new FileStream("transaction.log", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    var parking = new Parking();
                    StreamWriter w = new StreamWriter(fs);
                    TransactionManipulator.doTransactions(parking, w);
                    TransactionManipulator.deleteTransactions(parking);
                    uint key;
                    do
                    {
                        Console.WriteLine("Welcome to the parking, to choose one of the oprtions, please press key from the menu below");
                        Console.WriteLine("Press 1 to check parking balance");
                        Console.WriteLine("Press 2 to see the amount of money parking has earned for last minute");
                        Console.WriteLine("Press 3 to check number of available lots at the parking");
                        Console.WriteLine("Press 4 to see all last minute transactions");
                        Console.WriteLine("Press 5 to see all transactions");
                        Console.WriteLine("Press 6 to add transport to the parking");
                        Console.WriteLine("Press 7 to remove transport from the parking");
                        Console.WriteLine("Press 8 to see balance of certain transport");
                        Console.WriteLine("Press 9 to replanish balance of certain transport");
                        Console.WriteLine("Press 0 to exit program");
                        Console.WriteLine("Enter key: ");
                        key = Convert.ToUInt32(Console.ReadLine());

                        switch (key)
                        {
                            case 1:
                                Console.WriteLine($"A parking has balance of {parking.outBalance():C}");
                                break;
                            case 2:
                                Console.WriteLine($"A parking has earned {TransactionManipulator.showAmountOfMoneyEarned(parking):C}");
                                break;
                            case 3:
                                Console.WriteLine($"A parking has {TransportManipulator.countFreeLots(parking)} available lots");
                                break;
                            case 4:
                                Console.WriteLine($"Last minute transactions: ");
                                TransactionManipulator.showLastTransactions(parking);
                                break;
                            case 5:
                                Console.WriteLine($"All transactions: ");
                                StreamReader r = new StreamReader(fs);
                                TransactionManipulator.printAllTransactions(r);
                                break;
                                
                            case 6:
                                Console.WriteLine("Please, enter your transport type. Available options are: car, truck, motorcycle, bus");
                                string type = Console.ReadLine();
                                Console.WriteLine("Please, enter you transport balance");
                                decimal balance = Convert.ToDecimal(Console.ReadLine());
                                TransportManipulator.addTransport(parking, type, balance);
                                break;
                            case 7:
                                Console.WriteLine("Please, enter transport ID of a transport your want to remove.");
                                string idToRemove = Console.ReadLine();
                                TransportManipulator.removeTransport(parking, idToRemove);
                                break;
                            case 8:
                                Console.WriteLine("Please, enter transport ID of a transport of which you want to check balance.");
                                string idToCheckBalance = Console.ReadLine();
                                TransportManipulator.showTransportBalance(parking, idToCheckBalance);
                                break;
                            case 9:
                                Console.WriteLine("Please, enter transport ID of a transport of which you want to replanish balance.");
                                string idToReplanishBalance = Console.ReadLine();
                                Console.WriteLine("Please, enter amount of your replanishment");
                                decimal replanishment = Convert.ToDecimal(Console.ReadLine());
                                TransportManipulator.replanishBalance(parking, idToReplanishBalance, replanishment);
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("You entered invalid option, please try again, to exit press 0 after menu.");
                                break;
                        }


                    } while (key != 0);
                    w.Flush();
                }
            }
                catch (Exception ex)
               {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
                 }
        }

            
    }
}

