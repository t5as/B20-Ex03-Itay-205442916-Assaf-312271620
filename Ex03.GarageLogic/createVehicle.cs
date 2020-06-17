using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        private static string vehicleToDisplay; 
        private static NormalCar normalCar = null;
        private static ElectricCar electricCar = null;
        private static NormalMotorcycle normalMotorcycle = null;
        private static ElectricMotorcycle electricMotorcycle = null;
        private static Truck truck = null;
        private Dictionary<string, Dictionary<string, string[]>> vehicles = new Dictionary<string, Dictionary<string, string[]>>();
        private Dictionary<string, object> recievedDataFromUser = new Dictionary<string, object>();
        private Dictionary<string, object> updateNewVehicleData = new Dictionary<string, object>();
        private Vehicle vehicle = null;
        
        public CreateVehicle(Vehicle i_Vehicle)
        {
            vehicle = i_Vehicle;
            normalCar = new NormalCar(vehicle);
            electricCar = new ElectricCar(vehicle);
            normalMotorcycle = new NormalMotorcycle(vehicle);
            electricMotorcycle = new ElectricMotorcycle(vehicle);
            truck = new Truck(vehicle);
            GetDataFromUser();
        }  
        
        public static object GetVehicle()
        {
            if(vehicleToDisplay.ToLower() == "normalcar")
            {
                return normalCar;
            } 
            else if(vehicleToDisplay.ToLower() == "electriccar")
            {
                return electricCar;
            }
            else if (vehicleToDisplay.ToLower() == "normalmotorcycle")
            {
                return normalMotorcycle;
            }
            else if (vehicleToDisplay.ToLower() == "electricmotorcycle")
            {
                return electricMotorcycle;
            }
            else
            {
                return truck;
            }
        }

        public NormalCar NormalCar
        {
            get
            {
                return normalCar;
            }
        }

        public Vehicle CreatedVehicle
        {
            get
            {
                return vehicle;
            }
        }  

        public Dictionary<string, Dictionary<string, string[]>> VehiclesData
        {
            get
            {
                return vehicles;
            }
        } 

        public void SetDataDictionary(Dictionary<string, object> i_InputData)
        {
            foreach(var inputData in i_InputData)
            {
                recievedDataFromUser.Add(inputData.Key, inputData.Value);
            }
        }

        public void GetDataFromUser()
        {
            vehicles.Add("NormalCar", normalCar.DataFromUser());
            vehicles.Add("ElectricCar", electricCar.DataFromUser());
            vehicles.Add("NormalMotorcycle", normalMotorcycle.DataFromUser());
            vehicles.Add("ElectricMotorcycle", electricMotorcycle.DataFromUser());
            vehicles.Add("Truck", truck.DataFromUser());
        } 

        public void UpdateVehicleData(string i_VehicleToUpdate)
        {
            vehicleToDisplay = i_VehicleToUpdate;
            updateNewVehicleData.Add("NormalCar", normalCar.SetData(recievedDataFromUser));
            updateNewVehicleData.Add("ElectricCar", electricCar.SetData(recievedDataFromUser));
            updateNewVehicleData.Add("NormalMotorcycle", normalMotorcycle.SetData(recievedDataFromUser));
            updateNewVehicleData.Add("ElectricMotorcycle", electricMotorcycle.SetData(recievedDataFromUser));
            updateNewVehicleData.Add("Truck", truck.SetData(recievedDataFromUser));
            System.Console.WriteLine(updateNewVehicleData[i_VehicleToUpdate]);
        }
    }
}
