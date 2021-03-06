﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelVehicle
    {
        private readonly float r_MaxFuelAmountLitres;
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmountLitres;
        
        public FuelVehicle(eFuelType i_FuelType, float i_MaxFuelAmountLitres)
        {
            m_FuelType = i_FuelType;            
            r_MaxFuelAmountLitres = i_MaxFuelAmountLitres;
        }
        
        public enum eFuelType
        {
            Octan98, 
            Octan96, 
            Octan95, 
            Soler
        } 

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            
            set
            {
                m_FuelType = value;
            }
        }

        public eFuelType GetFuelType(string i_FuelType)
        {
            switch (i_FuelType.ToLower())
            {
                case "octan98":
                    return eFuelType.Octan98;
                    break;
                case "octan96":
                    return eFuelType.Octan96;
                    break;
                case "octan95":
                    return eFuelType.Octan95;
                    break;
                default:
                    return eFuelType.Soler;
                    break;
            }
        }

        public float CurrentFuelAmountLitres
        {
            get
            {
                return m_CurrentFuelAmountLitres;
            }
            
            set
            {
                m_CurrentFuelAmountLitres = value;

                if(m_CurrentFuelAmountLitres > r_MaxFuelAmountLitres)
                {
                    m_CurrentFuelAmountLitres = r_MaxFuelAmountLitres;
                }
            }
        }

        private string FuelStatus
        {
            get
            {
                StringBuilder fuelStatus = new StringBuilder();
                fuelStatus.Append(m_CurrentFuelAmountLitres);
                fuelStatus.Append(" / ");
                fuelStatus.Append(r_MaxFuelAmountLitres);

                return string.Format(fuelStatus.ToString());
            }
        }

        public override string ToString()
        {
            StringBuilder fuelData = new StringBuilder();
            fuelData.Append("Fuel Type: " + m_FuelType + "\n");
            fuelData.Append("Fuel tank status: " + FuelStatus);

            return string.Format(fuelData.ToString());
        }

        public void Refuel(float i_LitresToAdd)
        {
            try
            {
                m_CurrentFuelAmountLitres += i_LitresToAdd;
            }
            catch (ArgumentException e)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("{0} is not the correct fuel type", m_FuelType));
            }
            catch (ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e, m_CurrentFuelAmountLitres, 0, r_MaxFuelAmountLitres);
            }
        } 

        public float GetEnergyStatus()
        {
            return m_CurrentFuelAmountLitres / r_MaxFuelAmountLitres;
        }
    }
}
