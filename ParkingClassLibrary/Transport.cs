using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingClassLibrary
{
    internal abstract class Transport
    {
        private decimal balance { get; set; }
        private string TransportID {get; set;}
        virtual internal decimal parkingCost { get; set; }
        public Transport()
        {
        
        }
        public Transport(uint number, decimal balance = 0.0M)
        {
            this.balance = balance;
            TransportID = "T" + number;
        }
        public bool CheckBalance()
        {
            try
            {
                if (balance > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
                return true;
            }
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
        public decimal GetBalance()
        {
            return balance;
        }
        public string TransportId()
        {
            return TransportID;
        }
    }
}
