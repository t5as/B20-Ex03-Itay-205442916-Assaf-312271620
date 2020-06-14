using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NormalMotorcycle : Motorcycle
    {
        private static readonly float k_maxFuelAmountLitres = 7;
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Octan95, 7);

        /*public NormalMotorcycle(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            eTypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure, float i_currentFuelAmountLitres) : base(
                i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber, 
                i_engineSize, i_typeOfLicense, i_manufacturerName, i_currentAirPressure)
        {
            m_FuelData.CurrentFuelAmountLitres = i_currentFuelAmountLitres; 
        }*/

        public NormalMotorcycle(Vehicle i_vehicle) : base(i_vehicle.OwnerName,
            i_vehicle.OwnerPhoneNumber, i_vehicle.CarModel, i_vehicle.LicenseNumber)
        {

        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_FuelData.ToString());
            return String.Format(vehicleStringData.ToString());
        }

        public static Dictionary<string, string> dataFromUser()
        {
            Dictionary<string, string> dataToGet = Motorcycle.dataFromUser();
            Dictionary<string, string> fuelData = FuelVehicle.fuelDataFromUser();
            foreach (var fuelProperty in fuelData)
            {
                dataToGet.Add(fuelProperty.Key, fuelProperty.Value);
            }
            dataToGet.Add("Please enter current amount of fuel (smaller than max: "
                + k_maxFuelAmountLitres + ") : ", "float");
            return dataToGet;
        }
    }
}
