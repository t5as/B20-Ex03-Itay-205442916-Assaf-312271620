using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private string m_CarModel;
        private string m_LicenseNumber; 
        private eVehicleState m_VehicleState = eVehicleState.InRepair;

        public Vehicle(string i_ownerName, string i_ownerPhoneNumber, string i_carModel, string i_licenseNumber)
        {
            m_OwnerName = i_ownerName;
            m_OwnerPhoneNumber = i_ownerPhoneNumber;
            m_CarModel = i_carModel;
            m_LicenseNumber = i_licenseNumber;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        } 

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
        } 

        public string CarModel
        {
            get
            {
                return m_CarModel;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        } 

        public eVehicleState VehicleStatus
        {
            get
            {
                return m_VehicleState;
            }

            set
            {
                m_VehicleState = value;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append("License Number: " + m_LicenseNumber + "\n");
            vehicleStringData.Append("Vehicle Model: " + m_CarModel + "\n");
            vehicleStringData.Append("Vehicle Owner Name: " + m_OwnerName + "\n");
            vehicleStringData.Append("Vehicle State: " + m_VehicleState);
            return vehicleStringData.ToString();
        }

        public enum eVehicleState
        {
            InRepair,
            Fixed,
            Payed
        }

        /*public static Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = new Dictionary<string, string[]>();
            dataToGet.Add("OwnerName", new string[] { "Please enter vehicle owner name: ", "string" });
            dataToGet.Add("OwnerPhone", new string[] {"Please enter vehicle owner phone number: ", "string"});
            dataToGet.Add("VehicleModel", new string[] { "Please enter vehicle model: ", "string" });
            dataToGet.Add("LicenseNumber", new string[] { "Please enter vehicle license number: ", "string" });
            return dataToGet;
        } */

    }
}
