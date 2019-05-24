using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingClassLibrary
{
    internal class Motorcycle : Transport
    {
        public Motorcycle(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }
        internal override decimal parkingCost { get => DefaultConfigurations.motorcycleParkingCost; set => base.parkingCost = DefaultConfigurations.motorcycleParkingCost; }
    }
}
