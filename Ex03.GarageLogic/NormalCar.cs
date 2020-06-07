using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NormalCar : Car
    {
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Octan96, 60);

        public NormalCar(string i_ownerName, string i_ownerPhoneNumber,
                                string i_carModel, string i_licenseNumber, eNumberOfDoors i_numberOfDoors,
                                eCarColor i_carColor, string i_manufacturerName,
                                float i_currentAirPressure, float i_currentFuelAmountLitres) : base(
            i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
            i_numberOfDoors, i_carColor, i_manufacturerName, i_currentAirPressure)
        {
            m_FuelData.CurrentFuelAmountLitres = i_currentFuelAmountLitres;
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_FuelData.ToString());
            return string.Format(vehicleStringData.ToString());
        }
    }
}