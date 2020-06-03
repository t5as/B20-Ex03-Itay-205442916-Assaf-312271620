using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricVehicle
    {
        private float m_numberOfHoursLeft;
        private readonly float m_maximalHoursOfBattery;

        public ElectricVehicle(float i_numberOfHoursLeft, float i_maximalHoursOfBattery)
        {
            m_numberOfHoursLeft = i_numberOfHoursLeft;
            m_maximalHoursOfBattery = i_maximalHoursOfBattery;
        } 

        public void chargeBattery(float i_numberOfHoursToCharge)
        {
            m_numberOfHoursLeft += i_numberOfHoursToCharge; 
            if(m_maximalHoursOfBattery < m_numberOfHoursLeft)
            {
                m_numberOfHoursLeft = m_maximalHoursOfBattery;
            }
        }

        public float getEnergyStatus()
        {
            return m_numberOfHoursLeft / m_maximalHoursOfBattery;
        }
    } 

    
}
