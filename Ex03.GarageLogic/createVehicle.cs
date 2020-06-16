using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        private Dictionary<string, Dictionary<string, string[]>> vehicles = new Dictionary<string, Dictionary<string, string[]>>();
        private Vehicle vehicle = null;
        private NormalCar normalCar = null;
        private ElectricCar electricCar = null;
        private NormalMotorcycle normalMotorcycle = null;
        private ElectricMotorcycle electricMotorcycle = null;
        private Truck truck = null;

        public CreateVehicle(Vehicle i_vehicle)
        {
            vehicle = i_vehicle;
            normalCar = new NormalCar(vehicle);
            electricCar = new ElectricCar(vehicle);
            normalMotorcycle = new NormalMotorcycle(vehicle);
            electricMotorcycle = new ElectricMotorcycle(vehicle);
            truck = new Truck(vehicle);
            CreateVehicles();
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

        
        public void CreateVehicles()
        {
            vehicles.Add("NormalCar", normalCar.dataFromUser());
            vehicles.Add("ElectricCar", electricCar.dataFromUser());
            vehicles.Add("NormalMotorcycle", normalMotorcycle.dataFromUser());
            vehicles.Add("ElectricMotorcycle", electricMotorcycle.dataFromUser());
            vehicles.Add("Truck", truck.dataFromUser());
        }
    }
}
