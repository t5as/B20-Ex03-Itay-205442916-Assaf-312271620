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
            Dictionary<string, Dictionary<string, string[]>> vehicleQuestions = garage.getVehicleRequiredData(vehicle);
        }

    }
}
