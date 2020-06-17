using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        private List<Vehicle> m_GarageVehicles = new List<Vehicle>();

        public void InitializeNewVehicle(CreateVehicle i_CreateVehicle)
        {           
        } 

        public Dictionary<string, Dictionary<string, string[]>> GetVehicleRequiredData(Vehicle i_Vehicle)
        {
            CreateVehicle newVehicleCreator = new CreateVehicle(i_Vehicle);
            Dictionary<string, Dictionary<string, string[]>> entranceData = newVehicleCreator.VehiclesData;
            
            return entranceData;
        } 

        public string SetVehicleData(Vehicle i_Vehicle, Dictionary<string, object> i_SetDataDictionary, string i_CarType)
        {
            CreateVehicle newVehicleCreator = new CreateVehicle(i_Vehicle);
            newVehicleCreator.SetDataDictionary(i_SetDataDictionary);
            newVehicleCreator.UpdateVehicleData(i_CarType);
            System.Console.WriteLine("test");
            m_GarageVehicles.Add(i_Vehicle);
            
            return "Vehicle was added successfully";
        }
        
        public Vehicle SearchVehicle(string i_LicenseNumber)
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                if(vehicle.LicenseNumber == i_LicenseNumber)
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

        public string DisplayVehiclesLicenses(string i_VehicleState)
        {
            if (m_GarageVehicles.Count == 0)
            {
                return "There are no existing vehicles";
            }
            else
            {
                StringBuilder vehicleLicenses = new StringBuilder();
                Vehicle.eVehicleState vehicleState = Vehicle.GetVehicleState(i_VehicleState);

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

        public string[] GetVehicleStates()
        {
            return new string[] { "Please enter vehicle state (inrepair, fixed or payed): ", "enum: inrepair, fixed, payed" };
        }

        public string[] GetFuelTypes()
        {
            return new string[] { "Please enter fuel type(Octan98, Octan96, " + "Octan95, Soler): ", "enum: Octan98, Octan96, Octan95, Soler" };
        }

        public string UpdateVehicleState(string i_LicenseNumber, string i_StringNewVehicleState)
        {
            Vehicle vehicle = SearchVehicle(i_LicenseNumber); 

            if(vehicle != null)
            {
                vehicle.VehicleStatus = Vehicle.GetVehicleState(i_StringNewVehicleState);
                return "Vehicle state was updated successfully";
            }
            else
            {
                return "Vehicle was not found";
            }
        }  

        public string InflateVehicleWheels(string i_LicenseNumber)
        {
            Vehicle vehicle = SearchVehicle(i_LicenseNumber);

            if (vehicle != null)
            {
                vehicle.InflateWheels();
                return "Wheels are at maximum air pressure";
            }
            else
            {
                return "Vehicle was not found";
            }
        } 

        public string ChargeElectricVehicle(string i_LicenseNumber, float i_NumberOfMinutes)
        {
            Vehicle vehicle = SearchVehicle(i_LicenseNumber); 

            if(vehicle != null)
            {
                try
                {
                    vehicle.FillUp(i_NumberOfMinutes);
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

        public string FuelNormalVehicle(string i_LicenseNumber, string i_FuelType, float i_LitresToAdd)
        {
            Vehicle vehicle = SearchVehicle(i_LicenseNumber);

            if (vehicle != null)
            {
                try
                {
                    vehicle.FillUp(i_FuelType, i_LitresToAdd);
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

        public string DisplayVehicleData(string i_LicenseNumber)
        {
            Vehicle vehicle = SearchVehicle(i_LicenseNumber);

            if(vehicle != null)
            {
                return CreateVehicle.GetVehicle().ToString();
            }
            else
            {
                return "Vehicle was not found";
            }
        } 
    }
}