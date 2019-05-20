using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingClassLibrary
{
    internal abstract class Transport
    {
        private decimal balance { get; set; }
        private string transportID {get; set;}
        virtual internal decimal parkingCost { get; set; }
        public Transport()
        {
        
        }
        public Transport(uint number, decimal balance = 0.0M)
        {
            this.balance = balance;
            transportID = "T" + number;
        }
        public bool checkBalance()
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
        public void replenishBalance(decimal replenishment)
        {
            balance += replenishment;
        }
        public decimal getBalance()
        {
            return balance;
        }
        public string transportId()
        {
            return transportID;
        }
    }

    internal class Car : Transport
    {
        public Car(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }
        internal override decimal parkingCost { get => DefaultConfigurations.carParkingCost; set => base.parkingCost = DefaultConfigurations.carParkingCost; }
    }

    internal class Bus : Transport
    {
        public Bus(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }

        internal override decimal parkingCost { get => DefaultConfigurations.busParkingCost; set => base.parkingCost = DefaultConfigurations.busParkingCost; }
    }

    internal class Truck : Transport
    {
        public Truck(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }

        internal override decimal parkingCost { get => DefaultConfigurations.trackParkingCost; set => base.parkingCost = DefaultConfigurations.trackParkingCost; }
    }

    internal class Motorcycle : Transport
    {
        public Motorcycle(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }
        internal override decimal parkingCost { get => DefaultConfigurations.motorcycleParkingCost; set => base.parkingCost = DefaultConfigurations.motorcycleParkingCost; }
    }
}
