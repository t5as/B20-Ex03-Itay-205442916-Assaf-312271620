using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_manufacturerName;
        private float m_currentAirPressure; 
        private readonly float m_maxAirPressure;

        public Wheel(string i_manufacturerName, float i_currentAirPressure,
            float i_maxAirPressure)
        {
            m_manufacturerName = i_manufacturerName;
            m_currentAirPressure = i_currentAirPressure;
            m_maxAirPressure = i_maxAirPressure;
        }


        public void inflateWheel(float i_amountOfAirToAdd)
        {
            m_currentAirPressure += i_amountOfAirToAdd; 
            if(m_currentAirPressure > m_maxAirPressure)
            {
                m_currentAirPressure = m_maxAirPressure;
            }
        }
    } 

    
}
