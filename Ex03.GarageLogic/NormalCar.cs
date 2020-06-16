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

        public NormalCar(Vehicle i_vehicle) : base(i_vehicle)
        {

        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_FuelData.ToString());
            return string.Format(vehicleStringData.ToString());
        }

        public Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Car.dataFromUser();
            Dictionary<string, string[]> fuelData = FuelVehicle.fuelDataFromUser(); 
            foreach(var fuelProperty in fuelData)
            {
                dataToGet.Add(fuelProperty.Key, fuelProperty.Value);
            }
            dataToGet.Add("CurrentFuelAmountLitres", new string[] {"Please enter current amount of fuel (smaller than max: "
                + k_maxFuelAmountLitres + ") : ", "float" });
            return dataToGet;
        }

        public void setData(Dictionary<string, object> i_VehicleData)
        {
            this.NumberOfDoors = (eNumberOfDoors)i_VehicleData["NumberOfDoors"];
            this.CarColor = (eCarColor)i_VehicleData["CarColor"];
            this.WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
            this.WheelData.CurrentAirPressure = (float)i_VehicleData["CurrentAirPressure"];
            m_FuelData.FuelType = (FuelVehicle.eFuelType)i_VehicleData["FuelType"];
            m_FuelData.CurrentFuelAmountLitres = (float)i_VehicleData["CurrentFuelAmountLitres"];

        }
    }
}