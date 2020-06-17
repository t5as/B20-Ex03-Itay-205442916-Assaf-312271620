using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly byte r_NumberOfWheels = 2;
        private static readonly byte r_MaxAirPressure = 30;
        private int m_EngineSize;
        private eTypeOfLicense m_TypeOfLicense;
        private Wheel m_WheelData;


        public Motorcycle(Vehicle i_vehicle) : base(i_vehicle.OwnerName, i_vehicle.OwnerPhoneNumber, i_vehicle.CarModel, i_vehicle.LicenseNumber)
        {
            m_WheelData = new Wheel(r_MaxAirPressure);
        }

        public enum eTypeOfLicense
        {
            A,
            A1,
            AA,
            B
        } 

        public eTypeOfLicense TypeOfLicense
        {
            set
            {
                m_TypeOfLicense = value;
            }
        }

        public eTypeOfLicense getTypeOfLicense(string i_typeOfLicense)
        {
            switch (i_typeOfLicense.ToLower())
            {
                case "a":
                    return eTypeOfLicense.A;
                    break;
                case "a1":
                    return eTypeOfLicense.A1;
                    break;
                case "aa":
                    return eTypeOfLicense.AA;
                    break;
                default:
                    return eTypeOfLicense.B;
                    break;
            }
        }

        public Wheel WheelData
        {
            get
            {
                return m_WheelData;
            }
        }

        public int EngineSize
        {
            set
            {
                m_EngineSize = value;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_WheelData.ToString() + "\n");
            vehicleStringData.Append("License Type: " + m_TypeOfLicense + "\n");
            vehicleStringData.Append("Engine Size: " + m_EngineSize);
            return string.Format(vehicleStringData.ToString());
        }

        public override void inflateWheels()
        {
            m_WheelData.setAirPressureTomax();
        }

        public static Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = new Dictionary<string, string[]>();
            dataToGet.Add("EngineSize", new string[] { "Please enter integer representing engine size: ", "int" });
            dataToGet.Add("TypeOfLicense", new string[] { "Please enter license type (A, A1, AA or B): ", "enum: A, A1, AA, B" });
            dataToGet.Add("ManufacturerName", new string[] { "Please enter wheels manufacturer name: ", "string" });
            dataToGet.Add("CurrentAirPressure", new string[] { "Please enter current air pressure in wheels (smaller than max: " + r_MaxAirPressure + "): ", "float" });
            return dataToGet;
        }
    }
}
