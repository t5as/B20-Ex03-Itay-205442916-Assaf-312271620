using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private readonly float m_MaxHoursOfBattery = 1.2f;
        private ElectricVehicle m_ElectricData; 

        public ElectricMotorcycle(
            string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            eTypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure, float i_numberOfHoursLeft) : 
            base(i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
                i_engineSize, i_typeOfLicense, i_manufacturerName, i_currentAirPressure)
        {
            m_ElectricData = new ElectricVehicle(i_numberOfHoursLeft, m_MaxHoursOfBattery);
        }
    }
}
