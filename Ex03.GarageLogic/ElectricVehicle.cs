using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle
    {
        private readonly float r_MaximalHoursOfBattery; 
        private float m_NumberOfHoursLeft;
        
        public ElectricVehicle(float i_maximalHoursOfBattery)
        {
            r_MaximalHoursOfBattery = i_maximalHoursOfBattery;
        } 

        public void ChargeBattery(float i_numberOfHoursToCharge)
        {
            m_NumberOfHoursLeft += i_numberOfHoursToCharge; 

            if(r_MaximalHoursOfBattery < m_NumberOfHoursLeft)
            {
                m_NumberOfHoursLeft = r_MaximalHoursOfBattery;
            }
        }

        public float NumberOfHoursLeft
        {
            set
            {
                m_NumberOfHoursLeft = value;
            }            
        }

        public float GetEnergyStatus()
        {
            return m_NumberOfHoursLeft / r_MaximalHoursOfBattery;
        }

        public override string ToString()
        {
            return GetEnergyStatus().ToString();
        }
    }
}