using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        private List<Vehicle> m_GarageVehicles = new List<Vehicle>();
        private  Vehicle newVehicle = null;
        //CreateVehicle newVehicleCreator = new CreateVehicle("aabbb", "1111", "mazda", "12343");

        public void initializeNewVehicle(CreateVehicle i_createVehicle)
        {
            newVehicle = i_createVehicle.CreatedVehicle;            
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
        
        public void DisplayVehiclesLicenses()
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                System.Console.WriteLine(vehicle.LicenseNumber);
            }
        } 

        public void DisplayVehiclesLicenses(Vehicle.eVehicleState i_vehicleState)
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                if(vehicle.VehicleStatus == i_vehicleState)
                {
                    System.Console.WriteLine(vehicle.LicenseNumber);
                }
            }
        } 

        public void UpdateVehicleState(string i_licenseNumber, 
            Vehicle.eVehicleState i_newVehicleState)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber);
            vehicle.VehicleStatus = i_newVehicleState;
        } 

        public void DisplayVehicleData(string i_licenseNumber)
        {
            Vehicle vehicle = SearchVehicle(i_licenseNumber);
            System.Console.WriteLine(vehicle.ToString());
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