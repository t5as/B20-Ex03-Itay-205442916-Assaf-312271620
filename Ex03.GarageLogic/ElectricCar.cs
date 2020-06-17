using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private static readonly float r_MaxHoursOfBattery = 2.1f;
        private ElectricVehicle m_ElectricData;

        /*public ElectricCar(
            string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, eNumberOfDoors i_numberOfDoors,
            eCarColor i_carColor, string i_manufacturerName,
            float i_currentAirPressure, float i_numberOfHoursLeft) :
            base(i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber,
                i_numberOfDoors, i_carColor, i_manufacturerName, i_currentAirPressure)
        {
            m_ElectricData = new ElectricVehicle(i_numberOfHoursLeft, r_MaxHoursOfBattery);
        }*/

        public ElectricCar(Vehicle i_vehicle) : base(i_vehicle)
        {
            m_ElectricData = new ElectricVehicle(r_MaxHoursOfBattery);
        }

        public void ChargeCar(float i_hoursToCharge)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_hoursToCharge);
            }
            catch(Exception e)
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
            return string.Format(vehicleStringData.ToString());
        }

        public override void fillUp(float i_numberOfMinutesToAdd)
        {
            try
            {
                m_ElectricData.ChargeBattery(i_numberOfMinutesToAdd);
            }
            catch (ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e, m_ElectricData.NumberOfHoursLeft, 0, r_MaxHoursOfBattery);
            }
        }

        public Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = Car.dataFromUser();           
            dataToGet.Add(
                "NumberOfHoursLeft", 
                new string[] {"Please enter battery hours left (smaller than max: " + r_MaxHoursOfBattery + ") : ", 
                                     "float"
                                 });
            return dataToGet;
        }

        public string setData(Dictionary<string, object> i_VehicleData)
        {
            try
            {
                this.NumberOfDoors = this.getNumberOfDoors((string)i_VehicleData["NumberOfDoors"]);
                this.CarColor = this.getCarColor((string)i_VehicleData["CarColor"]);
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