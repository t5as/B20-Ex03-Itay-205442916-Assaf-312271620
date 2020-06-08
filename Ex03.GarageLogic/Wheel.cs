using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure; 
        private readonly float r_MaxAirPressure;

        public Wheel(string i_manufacturerName, float i_currentAirPressure, float i_maxAirPressure)
        {
            m_ManufacturerName = i_manufacturerName;
            m_CurrentAirPressure = i_currentAirPressure;
            r_MaxAirPressure = i_maxAirPressure;
        } 

        private string AirPressureStatus
        {
            get
            {
                StringBuilder airPressureData = new StringBuilder();
                airPressureData.Append(m_CurrentAirPressure);
                airPressureData.Append(" / ");
                airPressureData.Append(r_MaxAirPressure);
                return string.Format(airPressureData.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder wheelData = new StringBuilder();
            wheelData.Append("Wheel Manufacturer: " + m_ManufacturerName + "\n");
            wheelData.Append("Wheels air pressure: " + AirPressureStatus);
            return string.Format(wheelData.ToString());
        }

        public static Dictionary<string, string> wheelDataFromUser()
        {
            Dictionary<string, string> dataToGet = Vehicle.dataFromUser();
            dataToGet.Add("Please enter wheels manufacturer name: ", "string");
            return dataToGet;
        }

        public void InflateWheel(float i_amountOfAirToAdd)
        {
            try
            {
                m_CurrentAirPressure += i_amountOfAirToAdd;

                if (m_CurrentAirPressure > r_MaxAirPressure)
                {
                    m_CurrentAirPressure = r_MaxAirPressure;
                }
            }
            catch (Exception e)
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(e, i_amountOfAirToAdd, 0f, r_MaxAirPressure);
                throw valueOutOfRangeException;
            }
        }
    }
}