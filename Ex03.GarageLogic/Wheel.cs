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
                return String.Format(airPressureData.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder wheelData = new StringBuilder();
            wheelData.Append("Wheel Manufacturer: " + m_ManufacturerName + "\n");
            wheelData.Append("Wheels air pressure: " + AirPressureStatus);
            return String.Format(wheelData.ToString());
        }

        public void InflateWheel(float i_amountOfAirToAdd)
        {
            m_CurrentAirPressure += i_amountOfAirToAdd; 

            if(m_CurrentAirPressure > r_MaxAirPressure)
            {
                m_CurrentAirPressure = r_MaxAirPressure;
            }
        }
    }
}