using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static readonly byte r_MaxAirPressure = 28;
        private static float r_MaxFuelAmountLitres = 120;
        private readonly byte r_NumberOfWheels = 16;
        private bool m_IsDrivingHazardousMaterial;
        private float m_TrunkVolume;
        private Wheel m_WheelData;
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Soler, r_MaxFuelAmountLitres);

        public Truck(Vehicle i_Vehicle) : base(i_Vehicle.OwnerName, i_Vehicle.OwnerPhoneNumber, i_Vehicle.VehicleModel, i_Vehicle.LicenseNumber)
        {
            m_WheelData = new Wheel(r_MaxAirPressure);
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_WheelData.ToString() + "\n");
            vehicleStringData.Append(m_FuelData.ToString() + "\n");
            vehicleStringData.Append("Trunk Volume: " + m_TrunkVolume + "\n");
            vehicleStringData.Append("Driving hazardous materials? : " + m_IsDrivingHazardousMaterial);

            return string.Format(vehicleStringData.ToString());
        }

        public override void InflateWheels()
        {
            m_WheelData.SetAirPressureToMax();
        }

        public override void FillUp(string i_FuelType, float i_LitresToAdd)
        {
            if(m_FuelData.GetFuelType(i_FuelType) == m_FuelData.FuelType)
            {
                try
                {
                    m_FuelData.Refuel(i_LitresToAdd);
                } 
                catch(ValueOutOfRangeException e)
                {
                    throw new ValueOutOfRangeException(e, m_FuelData.CurrentFuelAmountLitres, 0, r_MaxFuelAmountLitres);
                }
            }
        }

        public Dictionary<string, string[]> DataFromUser()
        {
            Dictionary<string, string[]> dataToGet = new Dictionary<string, string[]>();
            dataToGet.Add("ManufacturerName", new string[] { "Please enter wheels manufacturer name: ", "string" });
            dataToGet.Add("CurrentAirPressure", new string[] { "Please enter current air pressure in wheels (smaller than max: " + r_MaxAirPressure + "): ", "float" });
            dataToGet.Add("IsDrivingHazardousMaterial", new string[] { "Please state if driving hazardous material (true, false): ", "bool" });
            dataToGet.Add("TrunkVolume", new string[] { "Please enter truck trunk volume: ", "float" });

            return dataToGet;
        }

        public object SetData(Dictionary<string, object> i_VehicleData)
        {
            try
            {
                m_WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
                m_WheelData.CurrentAirPressure = float.Parse(i_VehicleData["CurrentAirPressure"].ToString());
                m_IsDrivingHazardousMaterial = (bool)i_VehicleData["IsDrivingHazardousMaterial"];
                m_TrunkVolume = float.Parse(i_VehicleData["TrunkVolume"].ToString());
                m_FuelData.CurrentFuelAmountLitres = float.Parse(i_VehicleData["CurrentFuelAmountLitres"].ToString());
                
                return string.Empty;
            }
            catch(KeyNotFoundException e)
            {
                return string.Empty;
            }
        }
    }
}