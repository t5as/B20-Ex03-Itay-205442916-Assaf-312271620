using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private string m_VehicleModel;
        private string m_LicenseNumber; 
        private eVehicleState m_VehicleState = eVehicleState.InRepair;

        public static eVehicleState GetVehicleState(string i_VehicleState)
        {
            switch (i_VehicleState.ToLower())
            {
                case "inrepair":
                    return eVehicleState.InRepair;
                    break;
                case "fixed":
                    return eVehicleState.Fixed;
                    break;
                default:
                    return eVehicleState.Payed;
                    break;
            }
        }

        public Vehicle(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleModel, string i_LicenseNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleModel = i_VehicleModel;
            m_LicenseNumber = i_LicenseNumber;
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

        public string VehicleModel
        {
            get
            {
                return m_VehicleModel;
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
            vehicleStringData.Append("Vehicle Model: " + m_VehicleModel + "\n");
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

        public virtual void InflateWheels()
        {
        } 

        public virtual void FillUp(string i_FuelType, float i_LitresToAdd)
        {
        } 

        public virtual void FillUp(float i_NumberOfMinutesToAdd)
        {
        }
    }
}
