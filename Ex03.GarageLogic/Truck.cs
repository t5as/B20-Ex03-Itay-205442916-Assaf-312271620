using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDrivingHazardousMaterial;
        private float m_TrunkVolume;
        private readonly byte r_NumberOfWheels = 16;
        private static readonly byte r_MaxAirPressure = 28;
        private Wheel m_WheelData;
        private FuelVehicle m_FuelData = new FuelVehicle(FuelVehicle.eFuelType.Soler, 120);

        /*public Truck(string i_ownerName, string i_ownerPhoneNumber,
                   string i_carModel, string i_licenseNumber, bool i_isDrivingHazardousMaterial,
                   float i_TrunkVolume, string i_manufacturerName,
                   float i_currentAirPressure, float i_currentFuelAmountLitres) : base(i_ownerName,
            i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {
            r_IsDrivingHazardousMaterial = i_isDrivingHazardousMaterial;
            r_TrunkVolume = i_TrunkVolume;
            m_WheelData = new Wheel(i_manufacturerName, i_currentAirPressure, r_MaxAirPressure);
            m_FuelData.CurrentFuelAmountLitres = i_currentFuelAmountLitres;
        }*/

        public Truck(Vehicle i_vehicle) : base(i_vehicle.OwnerName,
            i_vehicle.OwnerPhoneNumber, i_vehicle.CarModel, i_vehicle.LicenseNumber)
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

        public Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Vehicle.dataFromUser();
            dataToGet.Add("ManufacturerName", new string[] { "Please enter wheels manufacturer name: ", "string" });
            dataToGet.Add("CurrentAirPressure", new string[] {"Please enter current air pressure in wheels (smaller than max: "
                 + r_MaxAirPressure + "): ", "float" });
            dataToGet.Add("IsDrivingHazardousMaterial", new string[] {"Please state if driving hazardous material (true, false): ",
                "bool" });
            dataToGet.Add("TrunkVolume", new string[] { "Please enter truck trunk volume: ", "float" });
            return dataToGet;
        }

        public string setData(Dictionary<string, object> i_VehicleData)
        {
            try
            {
                m_WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
                m_WheelData.CurrentAirPressure = float.Parse(i_VehicleData["CurrentAirPressure"].ToString());
                m_IsDrivingHazardousMaterial = (bool)i_VehicleData["IsDrivingHazardousMaterial"];
                m_TrunkVolume = float.Parse(i_VehicleData["TrunkVolume"].ToString());
                m_FuelData.CurrentFuelAmountLitres = float.Parse(i_VehicleData["CurrentFuelAmountLitres"].ToString());
                return "Truck was updated with details";
            }catch(KeyNotFoundException e)
            {
                return "Truck was not updated with details";
            }
            
        }
    }
}