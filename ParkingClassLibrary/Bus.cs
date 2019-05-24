using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingClassLibrary
{
    internal class Bus : Transport
    {
        public Bus(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }

        internal override decimal parkingCost { get => DefaultConfigurations.busParkingCost; set => base.parkingCost = DefaultConfigurations.busParkingCost; }
    }
}
