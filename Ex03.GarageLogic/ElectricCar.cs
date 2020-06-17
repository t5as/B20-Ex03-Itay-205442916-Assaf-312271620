using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private static readonly float r_MaxHoursOfBattery = 2.1f;
        private ElectricVehicle m_ElectricData;

        public ElectricCar(Vehicle i_Vehicle) : base(i_Vehicle)
        {
            m_ElectricData = new ElectricVehicle(r_MaxHoursOfBattery);
        }

        public void ChargeCar(float i_HoursToCharge)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_HoursToCharge);
            }
            catch(Exception e)
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(e, i_HoursToCharge, 0f, r_MaxHoursOfBattery);
                throw valueOutOfRangeException;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_ElectricData.ToString());

            return string.Format(vehicleStringData.ToString());
        }

        public override void FillUp(float i_NumberOfMinutesToAdd)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_NumberOfMinutesToAdd);
            }
            catch (ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e, m_ElectricData.NumberOfHoursLeft, 0, r_MaxHoursOfBattery);
            }
        }

        public Dictionary<string, string[]> DataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Car.dataFromUser();           
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
                this.NumberOfDoors = this.GetNumberOfDoors((string)i_VehicleData["NumberOfDoors"]);
                this.CarColor = this.GetCarColor((string)i_VehicleData["CarColor"]);
                this.WheelData.ManufacturerName = (string)i_VehicleData["ManufacturerName"];
                this.WheelData.CurrentAirPressure = float.Parse(i_VehicleData["CurrentAirPressure"].ToString());
                m_ElectricData.NumberOfHoursLeft = float.Parse(i_VehicleData["NumberOfHoursLeft"].ToString());
                
                return "Electric Car was updated with details";
            }
            catch(KeyNotFoundException e)
            {
                return "Electric Car was not updated";
            }
        }
    }
}