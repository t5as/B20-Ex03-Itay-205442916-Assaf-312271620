﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {        
        private readonly int r_EngineSize;
        private readonly eTypeOfLicense r_TypeOfLicense;
        private readonly byte r_NumberOfWheels = 2;
        private static readonly byte r_MaxAirPressure = 30;
        private Wheel m_WheelData;

        public Motorcycle(string i_ownerName, string i_ownerPhoneNumber,
            string i_carModel, string i_licenseNumber, int i_engineSize,
            eTypeOfLicense i_typeOfLicense, string i_manufacturerName,
            float i_currentAirPressure) : base(i_ownerName,
                i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {
            r_EngineSize = i_engineSize;
            r_TypeOfLicense = i_typeOfLicense;
            m_WheelData = new Wheel(i_manufacturerName, i_currentAirPressure, r_MaxAirPressure);
        }

        public enum eTypeOfLicense
        {
            A,
            A1,
            AA,
            B
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_WheelData.ToString() + "\n");
            vehicleStringData.Append("License Type: " + r_TypeOfLicense + "\n");
            vehicleStringData.Append("Engine Size: " + r_EngineSize);
            return string.Format(vehicleStringData.ToString());
        }

        public static Dictionary<string, string> dataFromUser()
        {
            Dictionary<string, string> dataToGet = Vehicle.dataFromUser();
            dataToGet.Add("Please enter integer representing engine size: ",
                "int");
            dataToGet.Add("Please enter license type (A, A1, AA or B): ",
                "enum: A, A1, AA, B");
            dataToGet.Add("Please enter wheels manufacturer name: ", "string");
            dataToGet.Add("Please enter current air pressure in wheels (smaller than max: "
                 + r_MaxAirPressure + " : ", "float");
            return dataToGet;
        }
    }
}
