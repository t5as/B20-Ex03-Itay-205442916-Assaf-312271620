using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {        
        private readonly int m_engineSize;
        private readonly TypeOfLicense m_typeOfLicense;
        private readonly byte m_numberOfWheels = 2;
        private Wheel m_wheelData;

        public Motorcycle(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            TypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure) : base(i_ownerName,
                i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {
            m_engineSize = i_engineSize;
            m_typeOfLicense = i_typeOfLicense;
            m_wheelData = new Wheel(i_manufacturerName, i_currentAirPressure, 30);
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
