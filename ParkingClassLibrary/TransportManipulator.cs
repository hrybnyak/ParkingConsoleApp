using System;
using System.Collections.Generic;

namespace ParkingClassLibrary
{
    public static class TransportManipulator
    {
        public static void AddTransport(Parking parking, string transportType, decimal balance)
            {
            try
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
                            transport = new Car(parking.OutputTransportCounter(), balance);
                            break;
                        case "truck":
                            transport = new Truck(parking.OutputTransportCounter(), balance);
                            break;
                        case "bus":
                            transport = new Bus(parking.OutputTransportCounter(), balance);
                            break;
                        case "motorcycle":
                            transport = new Motorcycle(parking.OutputTransportCounter(), balance);
                            break;
                        default:
                            throw new System.ArgumentException($"{transportType} is not available transport type");
                    }
                    parking.transports.Add(transport);
                    parking.IncreaseTransortCounter();
                    Console.WriteLine($"Your transport was succesfully added to the parking. Your ID number is {transport.TransportId()}, please don't forget it. Thank you for using our service.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
            }
        public static void RemoveTransport(Parking parking, string id)
        {
            try
            {
                bool check = false;
                foreach (Transport t in parking.transports.ToArray())
                {
                    if (t.TransportId() == id)
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
            catch(Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }
        public static void ShowTransportBalance(Parking parking, string id)
        {
            try
            {
                bool check = false;
                foreach (Transport t in parking.transports)
                {
                    if (t.TransportId() == id)
                    {
                        Console.WriteLine($"{t.TransportId()} has {t.GetBalance():C} on its balance");
                        check = true;
                    }
                }
                if (check == false)
                {
                    Console.WriteLine($"Sorry, but there is not thransort with this ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }
        public static void ReplanishBalance(Parking parking, string id, decimal replanishment)
        {
            try
            {
                bool check = false;
                foreach (Transport t in parking.transports)
                {
                    if (t.TransportId() == id)
                    {
                        t.ReplenishBalance(replanishment);
                        Console.WriteLine($"{t.TransportId()} was succesfully replanished and has {t.GetBalance():C} on its balance");
                        check = true;
                    }
                }
                if (check == false)
                {
                    Console.WriteLine($"Sorry, but there is not transort with this ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }
        public static int CountFreeLots(Parking parking) => 10 - parking.transports.Count;
        public static int CountBusyLots(Parking parking) => parking.transports.Count;
        public static void ShowList(Parking parking)
        {
            try
            {
                foreach (Transport t in parking.transports)
                {
                    Console.WriteLine($"{t.TransportId()} has {t.GetBalance():C}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ ex.GetType()} says { ex.Message}");
                Console.ReadLine();
            }
        }
    }
}
