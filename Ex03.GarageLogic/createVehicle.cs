using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        private Dictionary<string, Dictionary<string, string[]>> vehicles = new Dictionary<string, Dictionary<string, string[]>>();
        private Dictionary<string, object> recievedDataFromUser = new Dictionary<string, object>();
        private Dictionary<string, object> updateNewVehicleData = new Dictionary<string, object>();
        private static string vehicleToDisplay;
        private Vehicle vehicle = null;
        private static NormalCar normalCar = null;
        private static ElectricCar electricCar = null;
        private static NormalMotorcycle normalMotorcycle = null;
        private static ElectricMotorcycle electricMotorcycle = null;
        private static Truck truck = null;

        public CreateVehicle(Vehicle i_vehicle)
        {
            vehicle = i_vehicle;
            normalCar = new NormalCar(vehicle);
            electricCar = new ElectricCar(vehicle);
            normalMotorcycle = new NormalMotorcycle(vehicle);
            electricMotorcycle = new ElectricMotorcycle(vehicle);
            truck = new Truck(vehicle);
            getDataFromUser();
        }  
        
        public static object getVehicle()
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

        public void SetDataDictionary(Dictionary<string, object> i_inputData)
        {
            foreach(var inputData in i_inputData)
            {
                recievedDataFromUser.Add(inputData.Key, inputData.Value);
            }
        }

        
        public void getDataFromUser()
        {
            vehicles.Add("NormalCar", normalCar.dataFromUser());
            vehicles.Add("ElectricCar", electricCar.dataFromUser());
            vehicles.Add("NormalMotorcycle", normalMotorcycle.dataFromUser());
            vehicles.Add("ElectricMotorcycle", electricMotorcycle.dataFromUser());
            vehicles.Add("Truck", truck.dataFromUser());
        } 

        public void updateVehicleData(string i_vehicleToUpdate)
        {
            vehicleToDisplay = i_vehicleToUpdate;
            updateNewVehicleData.Add("NormalCar", normalCar.setData(recievedDataFromUser));
            updateNewVehicleData.Add("ElectricCar", electricCar.setData(recievedDataFromUser));
            updateNewVehicleData.Add("NormalMotorcycle", normalMotorcycle.setData(recievedDataFromUser));
            updateNewVehicleData.Add("ElectricMotorcycle", electricMotorcycle.setData(recievedDataFromUser));
            updateNewVehicleData.Add("Truck", truck.setData(recievedDataFromUser));
            System.Console.WriteLine(updateNewVehicleData[i_vehicleToUpdate]);
        }
    }
}
