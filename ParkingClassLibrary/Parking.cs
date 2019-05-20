using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
            balance = DefaultConfigurations.initialBalance;
        }
        public static Parking getInstance()
        {
            if (instance == null)
                instance = new Parking();
            return instance;
        }
        public void replenishBalance(decimal replenishment)
        {
            balance += replenishment;
        }

        public decimal outBalance() => balance;
        public uint outputTransportCounter() => transportCounter;
        public void increaseTransortCounter()
        {
            transportCounter++;
        }

    }
}

