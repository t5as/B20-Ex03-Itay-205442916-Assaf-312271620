﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class NormalMotorcycle : Motorcycle
    {
        private static readonly float k_maxFuelAmountLitres = 7;        
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Octan95, k_maxFuelAmountLitres);

        public NormalMotorcycle(Vehicle i_vehicle) : base(i_vehicle)
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
            Dictionary<string, string[]> dataToGet = Motorcycle.dataFromUser();            
            dataToGet.Add("CurrentFuelAmountLitres", new string[] { "Please enter current amount of fuel (smaller than max: " + k_maxFuelAmountLitres + ") : ", "float" });
            
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
            }
            catch(KeyNotFoundException e)
            {
                return "Normal motorcycle was not updated";
            }
        }
    }
}
