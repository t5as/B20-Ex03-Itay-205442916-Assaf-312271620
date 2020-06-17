using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        private List<Vehicle> m_GarageVehicles = new List<Vehicle>();
        // CreateVehicle newVehicleCreator = new CreateVehicle("aabbb", "1111", "mazda", "12343");

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
            System.Console.WriteLine("test");
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
            if(m_GarageVehicles.Count == 0)
            {
                return "There are no existing vehicles";
            }
            else
            {
                StringBuilder vehicleLicenses = new StringBuilder();
                foreach (Vehicle vehicle in m_GarageVehicles)
                {
                    vehicleLicenses.Append(vehicle.LicenseNumber + "\n");
                }

                return vehicleLicenses.ToString();
            }           
        } 

        public string DisplayVehiclesLicenses(string i_vehicleState)
        {
            if (m_GarageVehicles.Count == 0)
            {
                return "There are no existing vehicles";
            }
            else
            {
                StringBuilder vehicleLicenses = new StringBuilder();
                Vehicle.eVehicleState vehicleState = Vehicle.getVehicleState(i_vehicleState);
                foreach (Vehicle vehicle in m_GarageVehicles)
                {
                    if (vehicle.VehicleStatus == vehicleState)
                    {
                        vehicleLicenses.Append(vehicle.LicenseNumber + "\n");
                    }
                }

                return vehicleLicenses.ToString();
            }            
        }

        public string[] getVehicleStates()
        {
            return new string[] { "Please enter vehicle state (inrepair, fixed or payed): ", "enum: inrepair, fixed, payed" };
        }

        public string[] getFuelTypes()
        {
            return new string[] { "Please enter fuel type(Octan98, Octan96, " + "Octan95, Soler): ", "enum: Octan98, Octan96, Octan95, Soler" };
        }

        public string UpdateVehicleState(string i_licenseNumber, string i_stringNewVehicleState)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber); 
            if(vehicle != null)
            {
                vehicle.VehicleStatus = Vehicle.getVehicleState(i_stringNewVehicleState);
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

        public string chargeElectricVehicle(string i_licenseNumber, float i_numberOfMinutes)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber); 
            if(vehicle != null)
            {
                try
                {
                    vehicle.fillUp(i_numberOfMinutes);
                    return "Vehicle was successfully charged";
                }
                catch(ValueOutOfRangeException e)
                {
                    throw new ValueOutOfRangeException(e, 0, 0, 1);
                    return "Could not charge vehicle";
                }
            }
            else
            {
                return "Vehicle was not found";
            }
        }

        public string fuelNormalVehicle(string i_licenseNumber, string i_fuelType, float i_litresToAdd)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber);
            if (vehicle != null)
            {
                try
                {
                    vehicle.fillUp(i_fuelType, i_litresToAdd);
                    return "Vehicle was successfully fueled";
                }
                catch (ValueOutOfRangeException e)
                {
                    throw new ValueOutOfRangeException(e, 0, 0, 1);
                    return "Could not fuel vehicle";
                }
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
                
                return CreateVehicle.getVehicle().ToString();
            }
            else
            {
                return "Vehicle was not found";
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