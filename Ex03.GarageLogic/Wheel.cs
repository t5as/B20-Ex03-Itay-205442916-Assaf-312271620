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