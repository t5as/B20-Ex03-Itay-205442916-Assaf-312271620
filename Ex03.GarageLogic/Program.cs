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
            Dictionary<string, Dictionary<string, string[]>> entranceData = newVehicleCreator.VehiclesData;
            string[] keys = new string[entranceData.Keys.Count];
            entranceData.Keys.CopyTo(keys, 0);
            /*var newVehicle = entranceData[Console.getCarType(keys)][1];
            System.Console.WriteLine(newVehicle.GetType());*/
            Dictionary<string, string[]> dic = entranceData[Console.getCarType(keys)];
            foreach(KeyValuePair<string, string[]> vehiclePair in dic)
            {
                System.Console.WriteLine("The question to ask: " + vehiclePair.Value[0]);
                System.Console.WriteLine("The type of answer: " + vehiclePair.Value[1]);
            }
            
        }
    }
}
