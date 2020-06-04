using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelVehicle
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmountLitres;
        private readonly float r_MaxFuelAmountLitres; 

        public FuelVehicle(eFuelType i_fuelType, float i_maxFuelAmountLitres)
        {
            m_FuelType = i_fuelType;            
            r_MaxFuelAmountLitres = i_maxFuelAmountLitres;
        }
        
        public enum eFuelType
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
                m_CurrentFuelAmountLitres = value;

                if(m_CurrentFuelAmountLitres > r_MaxFuelAmountLitres)
                {
                    m_CurrentFuelAmountLitres = r_MaxFuelAmountLitres;
                }
            }
        }

        public void Refuel(float i_litresToAdd, eFuelType i_fuelType)
        {
            if(i_fuelType == m_FuelType)
            {
                m_CurrentFuelAmountLitres += i_litresToAdd;
            } 

            if(m_CurrentFuelAmountLitres > r_MaxFuelAmountLitres)
            {
                m_CurrentFuelAmountLitres = r_MaxFuelAmountLitres;
            }
        } 

        public float GetEnergyStatus()
        {
            return m_CurrentFuelAmountLitres / r_MaxFuelAmountLitres;
        }
    }
}
