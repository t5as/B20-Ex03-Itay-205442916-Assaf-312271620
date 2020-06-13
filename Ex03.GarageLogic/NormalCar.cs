using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NormalCar : Car
    {
        private static readonly float k_maxFuelAmountLitres = 60;
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Octan96, k_maxFuelAmountLitres);

        /*public NormalCar(string i_ownerName, string i_ownerPhoneNumber,
                                string i_carModel, string i_licenseNumber, eNumberOfDoors i_numberOfDoors,
                                eCarColor i_carColor, string i_manufacturerName,
                                float i_currentAirPressure, float i_currentFuelAmountLitres) : base(
            i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
            i_numberOfDoors, i_carColor, i_manufacturerName, i_currentAirPressure)
        {
            m_FuelData.CurrentFuelAmountLitres = i_currentFuelAmountLitres;
        }*/

        public NormalCar(string i_ownerName, string i_ownerPhoneNumber,
                          string i_carModel, string i_licenseNumber) : base(i_ownerName,
            i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {

        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_FuelData.ToString());
            return string.Format(vehicleStringData.ToString());
        }

        public static Dictionary<string, string> dataFromUser()
        {
            Dictionary<string, string> dataToGet = Car.dataFromUser();
            Dictionary<string, string> fuelData = FuelVehicle.fuelDataFromUser(); 
            foreach(var fuelProperty in fuelData)
            {
                dataToGet.Add(fuelProperty.Key, fuelProperty.Value);
            }
            dataToGet.Add("Please enter current amount of fuel (smaller than max: "
                + k_maxFuelAmountLitres + ") : ", "float");
            return dataToGet;
        }
    }
}