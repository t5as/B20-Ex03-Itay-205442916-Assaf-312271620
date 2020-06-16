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

        public NormalMotorcycle(Vehicle i_vehicle) : base(i_vehicle)
        {

        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_FuelData.ToString());
            return String.Format(vehicleStringData.ToString());
        }

        public Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Motorcycle.dataFromUser();            
            dataToGet.Add("CurrentFuelAmountLitres", new string[] {"Please enter current amount of fuel (smaller than max: "
                + k_maxFuelAmountLitres + ") : ", "float" });
            return dataToGet;
        }

        public string setData(Dictionary<string, object> i_VehicleData)
        {
            try
            {
                this.EngineSize = (int)i_VehicleData["EngineSize"];
                this.TypeOfLicense = this.getTypeOfLicense((string)i_VehicleData["TypeOfLicense"]);
                this.WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
                this.WheelData.CurrentAirPressure = float.Parse(i_VehicleData["CurrentAirPressure"].ToString());                
                m_FuelData.CurrentFuelAmountLitres = float.Parse(i_VehicleData["CurrentFuelAmountLitres"].ToString());
                return "Normal Motorcycle was updated with details";
            }catch(KeyNotFoundException e)
            {
                return "Normal motorcycle was not updated";
            }
            
        }
    }
    
}
