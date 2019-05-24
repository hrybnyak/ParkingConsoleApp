using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ParkingClassLibrary
{
    public class TransactionManipulator
    {
        internal class SchedulerService
        {
            private static SchedulerService _instance;
            private List<Timer> timers = new List<Timer>();
            private SchedulerService() { }
            public static SchedulerService Instance => _instance ?? (_instance = new SchedulerService());
            public void ScheduleTask(double intervalInSecond, Action task)
            {
                try
                {
                    var timer = new Timer(x =>
                    {
                        task.Invoke();
                    }, null, TimeSpan.Zero, TimeSpan.FromSeconds(intervalInSecond));
                    timers.Add(timer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                    Console.ReadLine();
                }
            }
        }
        public static void DoTransactions(Parking parking, TextWriter w)
        {
                SchedulerService.Instance.ScheduleTask(DefaultConfigurations.timePeriodInSeconds, () =>
                {
                    try {
                        foreach (Transport t in parking.transports.ToArray())
                        {
                            decimal parkingCost = 0.0M;
                            if (t.CheckBalance() == true)
                            {
                                parkingCost = Convert.ToDecimal(DefaultConfigurations.timePeriodInSeconds) * t.parkingCost;
                            }
                            else
                            {
                                parkingCost = Convert.ToDecimal(DefaultConfigurations.timePeriodInSeconds) * t.parkingCost * Convert.ToDecimal(DefaultConfigurations.penaltyRatio);
                            }
                            t.ReplenishBalance(-parkingCost);
                            parking.ReplenishBalance(parkingCost);
                            var transaction = new Transaction(parkingCost, t.TransportId());
                            transaction.Log(w);
                            parking.transactionsJournal.Add(transaction);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                        Console.ReadLine();
                    }
                });
        }
        public static void DeleteTransactions(Parking parking)
        {
                SchedulerService.Instance.ScheduleTask(DefaultConfigurations.timePeriodInSeconds-1, () =>
                {
                    try
                    {
                        foreach (Transaction tr in parking.transactionsJournal.ToArray())
                        {
                            TimeSpan difference = DateTime.Now - tr.transactionTime;
                            if (difference.TotalMinutes >= 1)
                            {
                                parking.transactionsJournal.Remove(tr);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                        Console.ReadLine();
                    }
                });
        }
        public static void ShowLastTransactions(Parking parking)
        {
            try
            {
                foreach (Transaction tr in parking.transactionsJournal)
                {
                    Console.WriteLine($"{tr.transactionTime:dddd, d MMM yy}----------{tr.transactionTime:HH:mm:ss}----------{tr.transportID}----------{tr.transferredMoney:C}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }
        public static decimal ShowAmountOfMoneyEarned(Parking parking)
        {
            try
            {
                decimal amount = 0.0M;
                foreach (Transaction tr in parking.transactionsJournal)
                {
                    amount += tr.transferredMoney;

                }
                return amount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
                return 0.0M;
            }
        }
        public static void PrintAllTransactions(StreamReader r)
        {
            try
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Console.WriteLine(line);
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
