using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ownerName;
        private string m_ownerPhoneNumber;
        private string m_carModel;
        private string m_licenseNumber;
        VehicleState m_vehicleState = VehicleState.InRepair;

        enum VehicleState
        {
            InRepair,
            Fixed,
            Payed
        }
    }
}
