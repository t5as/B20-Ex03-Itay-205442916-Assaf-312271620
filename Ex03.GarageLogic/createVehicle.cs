using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateVehicle
    {
        public static ElectricMotorcycle CreateElectricMotorcycle(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            Motorcycle.eTypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure, float i_numberOfHoursLeft)
        {
            return new ElectricMotorcycle(i_ownerName, i_ownerPhoneNumber, i_carModel,
                i_licenseNumber, i_engineSize, i_typeOfLicense, i_manufacturerName,
            i_currentAirPressure, i_numberOfHoursLeft);
        } 

        public static NormalMotorcycle CreateNormalMotorcycle(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            Motorcycle.eTypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure, float i_currentFuelAmountLitres)
        {
            return new NormalMotorcycle(i_ownerName, i_ownerPhoneNumber, i_carModel,
                i_licenseNumber, i_engineSize, i_typeOfLicense, i_manufacturerName,
            i_currentAirPressure, i_currentFuelAmountLitres);
        } 

        public static ElectricCar CreateElectricCar(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, Car.eNumberOfDoors i_numberOfDoors,
            Car.eCarColor i_carColor, string i_manufacturerName,
            float i_currentAirPressure, float i_numberOfHoursLeft)
        {
            return new ElectricCar(i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
            i_numberOfDoors, i_carColor, i_manufacturerName, i_currentAirPressure, i_numberOfHoursLeft);
        } 

        public static NormalCar CreateNormalCar(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, Car.eNumberOfDoors i_numberOfDoors,
            Car.eCarColor i_carColor, string i_manufacturerName,
            float i_currentAirPressure, float i_currentFuelAmountLitres)
        {
            return new NormalCar(i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
            i_numberOfDoors, i_carColor, i_manufacturerName, i_currentAirPressure,
            i_currentFuelAmountLitres);
        }

        public static Truck CreateTruck(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, bool i_isDrivingHazardousMaterial,
            float i_baggageVolume, string i_manufacturerName, float i_currentAirPressure,
            float i_currentAmountFuelLitres)
        {
            return new Truck(i_ownerName, i_ownerPhoneNumber, i_carModel, 
                i_licenseNumber, i_isDrivingHazardousMaterial,
                i_baggageVolume, i_manufacturerName, i_currentAirPressure,
                i_currentAmountFuelLitres);
        }
    }
}
