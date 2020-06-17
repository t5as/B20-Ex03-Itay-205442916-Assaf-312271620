using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle
    {
        private readonly float r_MaximalHoursOfBattery; 
        private float m_NumberOfHoursLeft;
        
        public ElectricVehicle(float i_MaximalHoursOfBattery)
        {
            r_MaximalHoursOfBattery = i_MaximalHoursOfBattery;
        }

        public void ChargeBattery(float i_NumberOfMinutesToCharge)
        {
            try
            {
                m_NumberOfHoursLeft += i_NumberOfMinutesToCharge / 60;
            }
            catch (ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e, m_NumberOfHoursLeft, 0, r_MaximalHoursOfBattery);
            }
        }

        public float NumberOfHoursLeft
        {
            get
            {
                return m_NumberOfHoursLeft;
            }

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