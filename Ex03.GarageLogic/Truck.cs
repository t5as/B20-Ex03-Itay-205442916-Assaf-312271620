using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_IsDrivingHazardousMaterial;
        private readonly float r_BaggageVolume;
        private readonly byte r_NumberOfWheels = 16;
        private Wheel m_WheelData;
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Soler, 120);

        public Truck(string i_ownerName, string i_ownerPhoneNumber,
                   string i_carModel, string i_licenseNumber, bool i_isDrivingHazardousMaterial,
                   float i_baggageVolume, string i_manufacturerName,
                   float i_currentAirPressure, float i_currentFuelAmountLitres) : base(i_ownerName,
            i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {
            r_IsDrivingHazardousMaterial = i_isDrivingHazardousMaterial;
            r_BaggageVolume = i_baggageVolume;
            m_WheelData = new Wheel(i_manufacturerName, i_currentAirPressure, 28);
            m_FuelData.CurrentFuelAmountLitres = i_currentFuelAmountLitres;
        }
    }
}