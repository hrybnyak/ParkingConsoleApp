using System;
using System.Collections.Generic;

namespace ParkingClassLibrary
{
    public static class TransportManipulator
    {
        public static void addTransport(Parking parking, string transportType, decimal balance)
            {
                if (parking.transports.Count == 10)
                {
                    Console.WriteLine($"Sorry, our parking has no more parking lots");
                }
                else
                {
                    Transport transport;
                    switch (transportType.ToLower())
                    {
                        case "car":
                            transport = new Car(parking.outputTransportCounter(), balance);
                            break;
                        case "truck":
                            transport = new Truck(parking.outputTransportCounter(), balance);
                            break;
                        case "bus":
                            transport = new Bus(parking.outputTransportCounter(), balance);
                            break;
                        case "motorcycle":
                            transport = new Motorcycle(parking.outputTransportCounter(), balance);
                            break;
                        default:
                            throw new System.ArgumentException($"{transportType} is not available transport type");
                    }
                    parking.transports.Add(transport);
                    parking.increaseTransortCounter();
                    Console.WriteLine($"Your transport was succesfully added to the parking. Your ID number is {transport.transportId()}, please don't forget it. Thank you for using our service.");
                }
            }
        
        public static void removeTransport(Parking parking, string id)
        {
                bool check = false;
                foreach (Transport t in parking.transports.ToArray())
                {
                    if (t.transportId() == id)
                    {
                        parking.transports.Remove(t);
                        check = true;
                    }
                }
                if (check == true)
                {
                    Console.WriteLine($"Your transport was succesfully removed from the parking. Have a nice day!");
                }
                else
                {
                    Console.WriteLine($"Sorry, but there is not thransort with this ID.");
                }
        }
        public static void showTransportBalance(Parking parking, string id)
        {
                bool check = false;
                foreach (Transport t in parking.transports)
                {
                    if (t.transportId() == id)
                    {
                        Console.WriteLine($"{t.transportId()} has {t.getBalance():C} on its balance");
                        check = true;
                    }
                }
                if (check == false)
                {
                    Console.WriteLine($"Sorry, but there is not thransort with this ID.");
                }
        }
        public static void replanishBalance(Parking parking, string id, decimal replanishment)
        {
                bool check = false;
                foreach (Transport t in parking.transports)
                {
                    if (t.transportId() == id)
                    {
                        t.replenishBalance(replanishment);
                        Console.WriteLine($"{t.transportId()} was succesfully replanished and has {t.getBalance():C} on its balance");
                        check = true;
                    }
                }
                if (check == false)
                {
                    Console.WriteLine($"Sorry, but there is not transort with this ID.");
                }
        }
        
        public static int countFreeLots(Parking parking) => 10 - parking.transports.Count;
        public static int countBusyLots(Parking parking) => parking.transports.Count;
        public static void showList(Parking parking)
        {
                foreach (Transport t in parking.transports)
                {
                    Console.WriteLine($"{t.transportId()} has {t.getBalance():C}");
                }
        }
    }
}
