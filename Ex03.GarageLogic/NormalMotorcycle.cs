using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NormalMotorcycle : Motorcycle
    {
        private static readonly float k_MaxFuelAmountLitres = 7;        
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Octan95, k_MaxFuelAmountLitres);

        public NormalMotorcycle(Vehicle i_Vehicle) : base(i_Vehicle)
        {
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_FuelData.ToString());

            return string.Format(vehicleStringData.ToString());
        }

        public override void FillUp(string i_FuelType, float i_LitresToAdd)
        {
            if (m_FuelData.GetFuelType(i_FuelType) == m_FuelData.FuelType)
            {
                try
                {
                    m_FuelData.Refuel(i_LitresToAdd);
                }
                catch (ValueOutOfRangeException e)
                {
                    throw new ValueOutOfRangeException(e, m_FuelData.CurrentFuelAmountLitres, 0, k_MaxFuelAmountLitres);
                }
            }
        }

        public Dictionary<string, string[]> DataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Motorcycle.DataFromUser();            
            dataToGet.Add("CurrentFuelAmountLitres", new string[] { "Please enter current amount of fuel (smaller than max: " + k_MaxFuelAmountLitres + ") : ", "float" });
            
            return dataToGet;
        }

        public string SetData(Dictionary<string, object> i_VehicleData)
        {
            try
            {
                this.EngineSize = (int)i_VehicleData["EngineSize"];
                this.TypeOfLicense = this.GetTypeOfLicense((string)i_VehicleData["TypeOfLicense"]);
                this.WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
                this.WheelData.CurrentAirPressure = float.Parse(i_VehicleData["CurrentAirPressure"].ToString());                
                m_FuelData.CurrentFuelAmountLitres = float.Parse(i_VehicleData["CurrentFuelAmountLitres"].ToString());
                
                return "Normal Motorcycle was updated with details";
            }
            catch(KeyNotFoundException e)
            {
                return "Normal motorcycle was not updated";
            }
        }
    }
}
