using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingClassLibrary
{
    internal class Car : Transport
    {
        public Car(uint number, decimal balance = 0.0M) : base(number, balance)
        {
        }
        internal override decimal parkingCost { get => DefaultConfigurations.carParkingCost; set => base.parkingCost = DefaultConfigurations.carParkingCost; }
    }
}
