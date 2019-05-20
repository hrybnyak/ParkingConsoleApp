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
                var timer = new Timer(x =>
                {
                    task.Invoke();
                }, null, TimeSpan.Zero, TimeSpan.FromSeconds(intervalInSecond));
                timers.Add(timer);
            }
        }
        public static void doTransactions(Parking parking, TextWriter w)
        {
                SchedulerService.Instance.ScheduleTask(DefaultConfigurations.timePeriodInSeconds, () =>
                {
                     foreach (Transport t in parking.transports.ToArray())
                    {
                        decimal parkingCost = 0.0M;
                        if (t.checkBalance() == true)
                        {
                            parkingCost = Convert.ToDecimal(DefaultConfigurations.timePeriodInSeconds) * t.parkingCost;
                        }
                        else
                        {
                            parkingCost = Convert.ToDecimal(DefaultConfigurations.timePeriodInSeconds) * t.parkingCost * Convert.ToDecimal(DefaultConfigurations.penaltyRatio);
                        }
                        t.replenishBalance(-parkingCost);
                        parking.replenishBalance(parkingCost);
                        var transaction = new Transaction(parkingCost, t.transportId());
                        transaction.log(w);
                        parking.transactionsJournal.Add(transaction);
                    }
                });
        }
        public static void deleteTransactions(Parking parking)
        {
                SchedulerService.Instance.ScheduleTask(DefaultConfigurations.timePeriodInSeconds-1, () =>
                {
                    foreach (Transaction tr in parking.transactionsJournal.ToArray())
                    {
                        TimeSpan difference = DateTime.Now - tr.transactionTime;
                        if (difference.TotalMinutes >= 1)
                        {
                            parking.transactionsJournal.Remove(tr);
                        }
                    }
                });
        }
        public static void showLastTransactions(Parking parking)
        {
                foreach (Transaction tr in parking.transactionsJournal)
                {
                    Console.WriteLine($"{tr.transactionTime:dddd, d MMM yy}----------{tr.transactionTime:HH:mm:ss}----------{tr.transportID}----------{tr.transferredMoney:C}");
                }
        }
        public static decimal showAmountOfMoneyEarned(Parking parking)
        {
                decimal amount = 0.0M;
                foreach (Transaction tr in parking.transactionsJournal)
                {
                    amount += tr.transferredMoney;

                }
                return amount;
        }
        
        public static void printAllTransactions(StreamReader r)
        {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
        }
    }
}
