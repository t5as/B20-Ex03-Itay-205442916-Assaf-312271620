using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Program
    { 
        static void Main()
        {
            CreateVehicle newVehicleCreator = new CreateVehicle("aabbb", "1111", "mazda", "12343");
            GarageLogic gl = new GarageLogic();
            gl.initializeNewVehicle(newVehicleCreator);
            Dictionary<string, object[]> entranceData = newVehicleCreator.VehiclesData;
            foreach(KeyValuePair<string, object[]> data in entranceData)
            {
                Console.WriteLine(data.Key);
            }
        }
    }
}
