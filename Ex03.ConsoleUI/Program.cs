using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            Ex03.GarageLogic.Vehicle vehicle = UI.InitializeVehicle();
            Ex03.GarageLogic.GarageLogic garage = new GarageLogic.GarageLogic();
            Dictionary<string, Dictionary<string, string[]>> vehiclesQuestionsDictionary = garage.getVehicleRequiredData(vehicle);
            string[] carTypes = new string[vehiclesQuestionsDictionary.Keys.Count];
            vehiclesQuestionsDictionary.Keys.CopyTo(carTypes, 0);
            Dictionary<string, string[]> questionsForUser = vehiclesQuestionsDictionary[UI.GetCarType(carTypes)];
            Dictionary<string, object> setDataDictionary = new Dictionary<string, object>();
            foreach (KeyValuePair<string, string[]> vehiclePair in questionsForUser)
            {
                //Console.WriteLine("The field name: " + vehiclePair.Key);
                Console.WriteLine(vehiclePair.Value[0]);
                Console.WriteLine("The type of answer: " + vehiclePair.Value[1]);
                string answer = Console.ReadLine();
                setDataDictionary.Add(vehiclePair.Key, UI.ParseAnswer(vehiclePair.Value[1], answer));
            }
            
            foreach (KeyValuePair<string, object> vehiclePair in setDataDictionary)
            {
                //Console.WriteLine("The field name: " + vehiclePair.Key);
                Console.WriteLine("q:" + vehiclePair.Key);
                Console.WriteLine("a:" + vehiclePair.Value);
                Console.WriteLine("type:" + vehiclePair.Value.GetType());
                Console.WriteLine("");
            }

            //Ex03.GarageLogic.CreateVehicle.SetDataDictionary(setDataDictionary);
            //Ex03.GarageLogic.CreateVehicle.updateVehicleData(UI.GetCarType(keys));
        }

    }
}
