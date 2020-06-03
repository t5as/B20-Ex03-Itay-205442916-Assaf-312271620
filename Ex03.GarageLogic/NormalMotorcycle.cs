using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class NormalMotorcycle : Vehicle
    {
        private readonly byte m_numberOfWheels = 2;
        private Wheel m_wheelData;
        private FuelVehicle m_fuelData = new FuelVehicle(FuelVehicle.FuelType.Octan95, 7);
        private readonly int m_engineSize;
        private readonly TypeOfLicense m_typeOfLicense;

        public NormalMotorcycle(string i_ownerName, string i_ownerPhoneNumber, 
            string i_carModel, string i_licenseNumber, float i_currentFuelAmountLitres,
            string i_manufacturerName, float i_currentAirPressure, int i_engineSize, 
            TypeOfLicense i_typeOfLicense) : base(i_ownerName, 
                i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {
            m_fuelData.CurrentFuelAmountLitres = i_currentFuelAmountLitres; 
            m_wheelData = new Wheel(i_manufacturerName, i_currentAirPressure, 30);
            m_engineSize = i_engineSize;
            m_typeOfLicense = i_typeOfLicense;
        } 

        public enum TypeOfLicense
        {
            A, 
            A1, 
            AA, 
            B
        }
    }
}
