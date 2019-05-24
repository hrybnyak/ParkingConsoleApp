using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingClassLibrary
{
    internal class Truck : Transport
    {
        public Truck(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }

        internal override decimal parkingCost { get => DefaultConfigurations.trackParkingCost; set => base.parkingCost = DefaultConfigurations.trackParkingCost; }
    }
}
