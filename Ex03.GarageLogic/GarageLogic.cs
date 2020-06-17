using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        private List<Vehicle> m_GarageVehicles = new List<Vehicle>();
        //CreateVehicle newVehicleCreator = new CreateVehicle("aabbb", "1111", "mazda", "12343");

        public void initializeNewVehicle(CreateVehicle i_createVehicle)
        {           
        } 

        public Dictionary<string, Dictionary<string, string[]>> getVehicleRequiredData(Vehicle i_vehicle)
        {
            CreateVehicle newVehicleCreator = new CreateVehicle(i_vehicle);
            Dictionary<string, Dictionary<string, string[]>> entranceData = newVehicleCreator.VehiclesData;
            /*string[] keys = new string[entranceData.Keys.Count];
            entranceData.Keys.CopyTo(keys, 0);
            Dictionary<string, string[]> dic = entranceData[Console.getCarType(keys)];
            foreach (KeyValuePair<string, string[]> vehiclePair in dic)
            {
                System.Console.WriteLine("The question to ask: " + vehiclePair.Value[0]);
                System.Console.WriteLine("The type of answer: " + vehiclePair.Value[1]);
            }*/
            return entranceData;
        } 

        public string setVehicleData(Vehicle i_vehicle, Dictionary<string, object> i_setDataDictionary, string i_carType)
        {
            CreateVehicle newVehicleCreator = new CreateVehicle(i_vehicle);
            newVehicleCreator.SetDataDictionary(i_setDataDictionary);
            newVehicleCreator.updateVehicleData(i_carType);
            m_GarageVehicles.Add(i_vehicle);
            return "Vehicle was added successfully";
        }
        
        

        public Vehicle SearchVehicle(string i_licenseNumber)
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                if(vehicle.LicenseNumber == i_licenseNumber)
                {
                    return vehicle;
                }
            }

            return null;
        } 
        
        public string DisplayVehiclesLicenses()
        {
            StringBuilder vehicleLicenses = new StringBuilder();
            foreach (Vehicle vehicle in m_GarageVehicles)
            {
                vehicleLicenses.Append(vehicle.LicenseNumber + "\n");
            }
            return vehicleLicenses.ToString();
        } 

        public string DisplayVehiclesLicenses(string i_vehicleState)
        {
            StringBuilder vehicleLicenses = new StringBuilder();
            Vehicle.eVehicleState vehicleState = Vehicle.getVehicleState(i_vehicleState);
            foreach (Vehicle vehicle in m_GarageVehicles)
            {
                if(vehicle.VehicleStatus == vehicleState)
                {
                    vehicleLicenses.Append(vehicle.LicenseNumber + "\n");
                }
            }
            return vehicleLicenses.ToString();
        }


        public string[] getVehicleStates()
        {
            return new string[] {"Please enter vehicle state (inrepair, fixed or payed): ",
                "enum: inrepair, fixed, payed" };
            
        }

        public string UpdateVehicleState(string i_licenseNumber, 
            string i_stringnewVehicleState)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber); 
            if(vehicle != null)
            {
                vehicle.VehicleStatus = Vehicle.getVehicleState(i_stringnewVehicleState);
                return "Vehicle state was updated successfully";
            }
            else
            {
                return "Vehicle was not found";
            }
            
        }  

        public string inflateVehicleWheels(string i_licenseNumber)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber);
            if (vehicle != null)
            {
                vehicle.inflateWheels();
                return "Wheels are at maximum air pressure";
            }
            else
            {
                return "Vehicle was not found";
            }
        }

        public string DisplayVehicleData(string i_licenseNumber)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber);
            if(vehicle != null)
            {
                return vehicle.ToString();
            }
            else
            {
                return "Vehicle was not found";
            }
            
            
        } 

        public void ChargeVehicle(string i_licenseNumber, uint i_numberOfMinutesCharge)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber);
            float hoursToCharge = i_numberOfMinutesCharge / 60;
            if (vehicle is ElectricCar)
            {
                ElectricCar electricCar = vehicle as ElectricCar;                
                electricCar.ChargeCar(hoursToCharge);
            }
            else if(vehicle is ElectricMotorcycle)
            {
                ElectricMotorcycle electricMotor = vehicle as ElectricMotorcycle;
                electricMotor.ChargeMotorcycle(hoursToCharge);
            }
        }

        /*public Vehicle createVehicle(string i_carType)
        {
            Vehicle vehicle = null;
            if (i_carType == "electric car")
            {
                vehicle = CreateVehicle.CreateElectricCar()
            }
        }*/
    }
}