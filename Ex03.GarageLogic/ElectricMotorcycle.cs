using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private static readonly float r_MaxHoursOfBattery = 1.2f;
        private ElectricVehicle m_ElectricData;

        /*public ElectricMotorcycle(
            string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            eTypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure, float i_numberOfHoursLeft) : 
            base(i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
                i_engineSize, i_typeOfLicense, i_manufacturerName, i_currentAirPressure)
        {
            m_ElectricData = new ElectricVehicle(i_numberOfHoursLeft, r_MaxHoursOfBattery);
        }*/
        public ElectricMotorcycle(Vehicle i_vehicle) : base(i_vehicle)
        {
            m_ElectricData = new ElectricVehicle(r_MaxHoursOfBattery);
        }


        public void ChargeMotorcycle(float i_hoursToCharge)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_hoursToCharge);
            }
            catch (Exception e)
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(e, i_hoursToCharge, 0f, r_MaxHoursOfBattery);
                throw valueOutOfRangeException;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_ElectricData.ToString());             
            return String.Format(vehicleStringData.ToString());
        }

        public Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Motorcycle.dataFromUser();
            dataToGet.Add("NumberOfHoursLeft", new string[] {"Please enter battery hours left (smaller than max: "
                + r_MaxHoursOfBattery + ") : ", "float" });
            return dataToGet;
        }

        public string setData(Dictionary<string, object> i_VehicleData)
        {
            this.EngineSize = (int)i_VehicleData["EngineSize"];
            this.TypeOfLicense = (Motorcycle.eTypeOfLicense)i_VehicleData["TypeOfLicense"];
            this.WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
            this.WheelData.CurrentAirPressure = (float)i_VehicleData["CurrentAirPressure"];
            m_ElectricData.NumberOfHoursLeft = (float)i_VehicleData["NumberOfHoursLeft"];
            return "Electric Motorcycle was updated with details";
        }
    }
}
