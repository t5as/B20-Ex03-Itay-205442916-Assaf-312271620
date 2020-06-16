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
            Console.WriteLine("yo");
            Ex03.GarageLogic.GarageLogic garage = new GarageLogic.GarageLogic();
            Dictionary<string, Dictionary<string, string[]>> vehiclesQuestionsDictionary = garage.getVehicleRequiredData(vehicle);
            string[] carTypes = new string[vehiclesQuestionsDictionary.Keys.Count];
            vehiclesQuestionsDictionary.Keys.CopyTo(carTypes, 0);
            Dictionary<string, string[]> questionsForUser = vehiclesQuestionsDictionary[UI.getCarType(carTypes)];
            foreach (KeyValuePair<string, string[]> vehiclePair in questionsForUser)
            {
                Console.WriteLine("The field name: " + vehiclePair.Key);
                Console.WriteLine("The question to ask: " + vehiclePair.Value[0]);
                Console.WriteLine("The type of answer: " + vehiclePair.Value[1]);
            }
        }

    }
}
