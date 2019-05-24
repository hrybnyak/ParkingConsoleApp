using System;
using System.Collections.Generic;

namespace ParkingClassLibrary
{
     public class Parking
    {
        private static Parking instance;
        public uint transportCounter = 0;
        private decimal balance;
        internal List<Transport> transports = new List<Transport>();
        internal List<Transaction> transactionsJournal = new List<Transaction>();
        public Parking()
        {
            try
            {
                balance = DefaultConfigurations.initialBalance;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }
        public static Parking getInstance()
        {
            if (instance == null)
                instance = new Parking();
            return instance;
        }
        public void ReplenishBalance(decimal replenishment)
        {
            try
            {
                balance += replenishment;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }

        public decimal OutBalance() => balance;
        public uint OutputTransportCounter() => transportCounter;
        public void IncreaseTransortCounter()
        {
            try
            {
                transportCounter++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }
    }
}

