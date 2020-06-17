using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NormalCar : Car
    {
        private static readonly float k_maxFuelAmountLitres = 60; 
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Octan96, k_maxFuelAmountLitres);

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

        public override void fillUp(string i_fuelType, float i_litresToAdd)
        {
            if (m_FuelData.getFuelType(i_fuelType) == m_FuelData.FuelType)
            {
                try
                {
                    m_FuelData.Refuel(i_litresToAdd);
                }
                catch (ValueOutOfRangeException e)
                {
                    throw new ValueOutOfRangeException(e, m_FuelData.CurrentFuelAmountLitres, 0, k_maxFuelAmountLitres);
                }
            }
        }

        public Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Car.dataFromUser();            
            dataToGet.Add("CurrentFuelAmountLitres", new string[] { "Please enter current amount of fuel (smaller than max: " + k_maxFuelAmountLitres + ") : ", "float" });
            
            return dataToGet;
        }

        public object setData(Dictionary<string, object> i_VehicleData)
        {
            try
            {
                this.NumberOfDoors = this.GetNumberOfDoors((string)i_VehicleData["NumberOfDoors"]);
                this.CarColor = this.GetCarColor((string)i_VehicleData["CarColor"]);
                this.WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
                this.WheelData.CurrentAirPressure = float.Parse(i_VehicleData["CurrentAirPressure"].ToString());
                m_FuelData.CurrentFuelAmountLitres = float.Parse(i_VehicleData["CurrentFuelAmountLitres"].ToString());
                
                return "Normal Car was updated with details";
            }
            catch(KeyNotFoundException e)
            {
                return "Normal Car wasnt updated";
            }
        }
    }
}