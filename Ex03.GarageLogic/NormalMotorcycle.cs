using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NormalMotorcycle : Motorcycle
    {
        private FuelVehicle m_fuelData = new FuelVehicle(FuelVehicle.FuelType.Octan95, 7);
        

        public NormalMotorcycle(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            TypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure, float i_currentFuelAmountLitres) : base(
                i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber, 
                i_engineSize, i_typeOfLicense, i_manufacturerName, i_currentAirPressure)
        {
            m_fuelData.CurrentFuelAmountLitres = i_currentFuelAmountLitres; 
        }   
    }
}
