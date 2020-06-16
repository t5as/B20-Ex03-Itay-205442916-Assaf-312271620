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
            Dictionary<string, string[]> dic = entranceData[Console.getCarType(keys)];
            foreach(KeyValuePair<string, string[]> vehiclePair in dic)
            {
                System.Console.WriteLine("The question to ask: " + vehiclePair.Value[0]);
                System.Console.WriteLine("The type of answer: " + vehiclePair.Value[1]);
            }
            System.Console.WriteLine("----------------------Answers Check---------");
            Dictionary<string, object> setDataDictionary = new Dictionary<string, object>();
            //Normal Motorcycle test
            /*setDataDictionary.Add("EngineSize", 27);
            setDataDictionary.Add("TypeOfLicense", "A");
            setDataDictionary.Add("ManufacturerName", "Moti Luchim");
            setDataDictionary.Add("CurrentAirPressure", 1.5);
            setDataDictionary.Add("FuelType", "Soler");
            setDataDictionary.Add("CurrentFuelAmountLitres", 10.5);*/
            //Truck test 
            setDataDictionary.Add("ManufacturerName", "Avi Ron");
            setDataDictionary.Add("CurrentAirPressure", 13.7);
            setDataDictionary.Add("IsDrivingHazardousMaterial", false);
            setDataDictionary.Add("TrunkVolume", 11.2);
            setDataDictionary.Add("CurrentFuelAmountLitres", 12.64);
             System.Console.WriteLine(Console.getCarType(keys));
            newVehicleCreator.SetDataDictionary(setDataDictionary);
            newVehicleCreator.updateVehicleData(Console.getCarType(keys));
    }
    }
}
