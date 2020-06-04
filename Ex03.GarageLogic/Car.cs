using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly eNumberOfDoors r_NumberOfDoors;
        private readonly eCarColor r_CarColor;
        private readonly byte r_NumberOfWheels = 4;
        private Wheel m_WheelData;

        public Car(string i_ownerName, string i_ownerPhoneNumber,
                          string i_carModel, string i_licenseNumber, eNumberOfDoors i_numberOfDoors,
                          eCarColor i_carColor, string i_manufacturerName,
                          float i_currentAirPressure) : base(i_ownerName,
            i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {
            r_NumberOfDoors = i_numberOfDoors;
            r_CarColor = i_carColor;
            m_WheelData = new Wheel(i_manufacturerName, i_currentAirPressure, 32);
        }

        public enum eCarColor
        {
            Red,
            White,
            Black,
            Silver
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
    }
}