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


        public override void fillUp(float i_numberOfMinutesToAdd)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_numberOfMinutesToAdd);
            }
            catch(ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e, m_ElectricData.NumberOfHoursLeft, 0, r_MaxHoursOfBattery);
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

        public object setData(Dictionary<string, object> i_VehicleData)
        {
            try
            {
                this.EngineSize = (int)i_VehicleData["EngineSize"];
                this.TypeOfLicense = this.getTypeOfLicense((string)i_VehicleData["TypeOfLicense"]);
                this.WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
                this.WheelData.CurrentAirPressure = float.Parse(i_VehicleData["CurrentAirPressure"].ToString());
                m_ElectricData.NumberOfHoursLeft = float.Parse(i_VehicleData["NumberOfHoursLeft"].ToString());
                return "";
            }catch(KeyNotFoundException e)
            {
                return "";
            }
            
        }
    }
}
