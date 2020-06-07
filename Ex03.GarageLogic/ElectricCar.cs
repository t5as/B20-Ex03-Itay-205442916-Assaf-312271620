using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private readonly float r_MaxHoursOfBattery = 2.1f;
        private ElectricVehicle m_ElectricData;

        public ElectricCar(
            string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, eNumberOfDoors i_numberOfDoors,
            eCarColor i_carColor, string i_manufacturerName,
            float i_currentAirPressure, float i_numberOfHoursLeft) :
            base(i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
                i_numberOfDoors, i_carColor, i_manufacturerName, i_currentAirPressure)
        {
            m_ElectricData = new ElectricVehicle(i_numberOfHoursLeft, r_MaxHoursOfBattery);
        }

        public void ChargeCar(float i_hoursToCharge)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_hoursToCharge);
            }
            catch(Exception e)
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(e, i_hoursToCharge, 0f, r_MaxHoursOfBattery);
                throw valueOutOfRangeException;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_ElectricData.ToString());
            return string.Format(vehicleStringData.ToString());
        }
    }
}