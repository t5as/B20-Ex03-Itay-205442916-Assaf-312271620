using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        private Dictionary<string, Object[]> vehicles = new Dictionary<string, Object[]>();
        private Vehicle vehicle = null; 

        public CreateVehicle(Vehicle i_vehicle)
        {
            vehicle = i_vehicle;
            CreateVehicles();
        } 

        public Vehicle CreatedVehicle
        {
            get
            {
                return vehicle;
            }
        }  

        public Dictionary<string, object[]> VehiclesData
        {
            get
            {
                return vehicles;
            }
        }

        
        public void CreateVehicles()
        {
            vehicles.Add("NormalCar",
                new object[] { NormalCar.dataFromUser(), new NormalCar(vehicle)});
            vehicles.Add("ElectricCar",  
                new object[] { ElectricCar.dataFromUser(), new ElectricCar(vehicle)});
            vehicles.Add("NormalMotorcycle",
                new object[] { NormalMotorcycle.dataFromUser(), new NormalMotorcycle(vehicle)});
            vehicles.Add("ElectricMotorcycle", 
                new object[] { ElectricMotorcycle.dataFromUser(), new ElectricMotorcycle(vehicle)});
            vehicles.Add("Truck", 
                new object[] { Truck.dataFromUser(), new Truck(vehicle)});
        }
    }
}
