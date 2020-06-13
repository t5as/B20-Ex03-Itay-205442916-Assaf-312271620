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
        public ElectricMotorcycle(string i_ownerName, string i_ownerPhoneNumber,
                   string i_carModel, string i_licenseNumber) : base(i_ownerName,
            i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {

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

        public static Dictionary<string, string> dataFromUser()
        {
            Dictionary<string, string> dataToGet = Motorcycle.dataFromUser();
            dataToGet.Add("Please enter battery hours left (smaller than max: "
                + r_MaxHoursOfBattery + ") : ", "float");
            return dataToGet;
        }
    }
}
