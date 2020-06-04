using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private string m_CarModel;
        private string m_LicenseNumber; 
        eVehicleState m_VehicleState = eVehicleState.InRepair;

        public Vehicle(string i_ownerName, string i_ownerPhoneNumber, string i_carModel, string i_licenseNumber)
        {
            m_OwnerName = i_ownerName;
            m_OwnerPhoneNumber = i_ownerPhoneNumber;
            m_CarModel = i_carModel;
            m_LicenseNumber = i_licenseNumber;
        }

        enum eVehicleState
        {
            InRepair,
            Fixed,
            Payed
        }
    }
}
