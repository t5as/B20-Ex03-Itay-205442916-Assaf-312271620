using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Program
    { 
        static void Main()
        {
            CreateVehicle newVehicleCreator = new CreateVehicle(Console.Creater());
            Dictionary<string, object[]> entranceData = newVehicleCreator.VehiclesData;
            string[] keys = new string[entranceData.Keys.Count];
            entranceData.Keys.CopyTo(keys, 0);
            var newVehicle = entranceData[Console.getCarType(keys)][1];
            System.Console.WriteLine(newVehicle.GetType());
        }
    }
}
