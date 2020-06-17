using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private static readonly float r_MaxHoursOfBattery = 1.2f;
        private ElectricVehicle m_ElectricData;

        public ElectricMotorcycle(Vehicle i_Vehicle) : base(i_Vehicle)
        {
            m_ElectricData = new ElectricVehicle(r_MaxHoursOfBattery);
        }

        public override void FillUp(float i_NumberOfMinutesToAdd)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_NumberOfMinutesToAdd);
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
            
            return string.Format(vehicleStringData.ToString());
        }

        public Dictionary<string, string[]> DataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Motorcycle.DataFromUser();
            dataToGet.Add(
                "NumberOfHoursLeft", 
                new string[] 
                    { 
                        "Please enter battery hours left (smaller than max: " + r_MaxHoursOfBattery + ") : ", 
                                 "float"
                    });
            
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
                m_ElectricData.NumberOfHoursLeft = float.Parse(i_VehicleData["NumberOfHoursLeft"].ToString());
                
                return "Electric Motorcycle was updated with details";
            }
            catch(KeyNotFoundException e)
            {
                return "Electric Motorcycle was not updated";
            }
        }
    }
}
