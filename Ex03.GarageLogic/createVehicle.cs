using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        public static Dictionary<string, Object[]> vehicles = new Dictionary<string, Object[]>();
        Vehicle vehicle = null; 

        public CreateVehicle(string i_ownerName, string i_ownerPhoneNumber, string i_carModel, string i_licenseNumber)
        {
            vehicle = new Vehicle(i_ownerName, i_ownerPhoneNumber,
                i_carModel, i_licenseNumber);
        }

        public void CreateVehicles()
        {
            vehicles.Add("NormalCar",
                new object[] { NormalCar.dataFromUser(), new NormalCar()});
            vehicles.Add("ElectricCar",  
                new object[] { ElectricCar.dataFromUser(), new ElectricCar() });
            vehicles.Add("NormalMotorcycle",
                new object[] { NormalMotorcycle.dataFromUser(), new NormalMotorcycle()});
            vehicles.Add("ElectricMotorcycle", 
                new object[] { ElectricMotorcycle.dataFromUser(), new ElectricMotorcycle() });
            vehicles.Add("Truck", 
                new object[] { Truck.dataFromUser(), (Truck)vehicle });
        }
    }
}
