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

        public Wheel(float i_maxAirPressure)
        {
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
