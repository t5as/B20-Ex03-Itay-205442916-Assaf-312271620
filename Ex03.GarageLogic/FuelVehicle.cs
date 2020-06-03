using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelVehicle
    {
        private FuelType m_fuelType;
        private float m_currentFuelAmountLitres;
        private readonly float m_maxFuelAmountLitres; 

        public FuelVehicle(FuelType i_fuelType, float i_maxFuelAmountLitres)
        {
            m_fuelType = i_fuelType;            
            m_maxFuelAmountLitres = i_maxFuelAmountLitres;
        }
        

        public enum FuelType
        {
            Octan98, 
            Octan96, 
            Octan95, 
            Soler
        }

        public float CurrentFuelAmountLitres
        {
            set
            {
                m_currentFuelAmountLitres = value;
                if(m_currentFuelAmountLitres > m_maxFuelAmountLitres)
                {
                    m_currentFuelAmountLitres = m_maxFuelAmountLitres;
                }
            }
        }

        public void refuel(float i_litresToAdd, FuelType i_fuelType)
        {
            if(i_fuelType == m_fuelType)
            {
                m_currentFuelAmountLitres += i_litresToAdd;
            } 
            if(m_currentFuelAmountLitres > m_maxFuelAmountLitres)
            {
                m_currentFuelAmountLitres = m_maxFuelAmountLitres;
            }

        } 

        public float getEnergyStatus()
        {
            return m_currentFuelAmountLitres / m_maxFuelAmountLitres;
        }
    }
}
