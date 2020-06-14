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

        public eFuelType FuelType
        {
            set
            {
                m_FuelType = value;
            }
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

        public static Dictionary<string, string> fuelDataFromUser()
        {
            Dictionary<string, string> dataToGet = new Dictionary<string, string>();
            dataToGet.Add("Please enter fuel type(Octan98, Octan96, " +
                "Octan95, Soler): ", "enum: Octan98, Octan96, Octan95, Soler");
            return dataToGet;
        }

        public void Refuel(float i_litresToAdd, eFuelType i_fuelType)
        {
            try
            {
                if (i_fuelType == m_FuelType)
                {
                    m_CurrentFuelAmountLitres += i_litresToAdd;
                }

                if (m_CurrentFuelAmountLitres > r_MaxFuelAmountLitres)
                {
                    m_CurrentFuelAmountLitres = r_MaxFuelAmountLitres;
                }
            }
            catch (ArgumentException e)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("{0} is not the correct fuel type", i_fuelType), e);
            }
            catch (Exception e)
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(e, i_litresToAdd, 0f, r_MaxFuelAmountLitres);
                throw valueOutOfRangeException;
            }
        } 

        public float GetEnergyStatus()
        {
            return m_CurrentFuelAmountLitres / r_MaxFuelAmountLitres;
        }
    }
}
