using System;
using System.IO;

namespace ParkingClassLibrary
{
    internal class Transaction
    {
        internal DateTime transactionTime;
        internal decimal transferredMoney;
        internal string transportID;

        public Transaction()
        {
            transactionTime = DateTime.Now;
        }
        public Transaction(decimal transferredMoney, string transportId)
        {
            transactionTime = DateTime.Now;
            this.transferredMoney = transferredMoney;
            transportID = transportId;
        }
        public void Log(TextWriter w)
        {
            try
            {
                w.WriteLine($"  :{transactionTime:dddd, d MMM yy}----------{transactionTime:HH:mm:ss}----------{transportID}----------{transferredMoney:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }

    }
}
