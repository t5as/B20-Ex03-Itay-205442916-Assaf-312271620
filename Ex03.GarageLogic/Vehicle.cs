using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        private string m_ownerName;
        private string m_ownerPhoneNumber;
        private string m_carModel;
        private string m_licenseNumber; 
        VehicleState m_vehicleState = VehicleState.InRepair;

        public Vehicle(string i_ownerName, string i_ownerPhoneNumber, string i_carModel,
            string i_licenseNumber)
        {
            m_ownerName = i_ownerName;
            m_ownerPhoneNumber = i_ownerPhoneNumber;
            m_carModel = i_carModel;
            m_licenseNumber = i_licenseNumber;
        }

        enum VehicleState
        {
            InRepair,
            Fixed,
            Payed
        }
    }
}
