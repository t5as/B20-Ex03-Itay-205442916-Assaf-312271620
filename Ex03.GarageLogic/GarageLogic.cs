using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        private List<Vehicle> m_GarageVehicles = new List<Vehicle>();
        private Vehicle stam = new Vehicle("aabbb", "1111", "mazda", "12343");
        
        public Vehicle searchVehicle(string i_licenseNumber)
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                if(vehicle.licenseNumber == i_licenseNumber)
                {
                    return vehicle;
                }
            }
            return null;
        } 
        
        public void displayVehiclesLicenses()
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                Console.WriteLine(vehicle.licenseNumber);
            }
        } 

        public void displayVehiclesLicenses(Vehicle.eVehicleState i_vehicleState)
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                if(vehicle.VehicleStatus == i_vehicleState)
                {
                    Console.WriteLine(vehicle.licenseNumber);
                }
            }
        } 

        public void updateVehicleState(string i_licenseNumber, 
            Vehicle.eVehicleState i_newVehicleState)
        {
            Vehicle vehicle = searchVehicle(i_licenseNumber);
            vehicle.VehicleStatus = i_newVehicleState;
        } 

        public void displayVehicleData(string i_licenseNumber)
        {
            Vehicle vehicle = searchVehicle(i_licenseNumber);
        }

        /*public Vehicle createVehicle(string i_carType)
        {
            Vehicle vehicle = null;
            if (i_carType == "electric car")
            {
                vehicle = CreateVehicle.createElectricCar()
            }
        }*/
        


        
        
        
    }
}
