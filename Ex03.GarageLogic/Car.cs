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
        private static readonly byte r_MaxAirPressure = 32;
        private Wheel m_WheelData;

        public Car(
            string i_ownerName, 
            string i_ownerPhoneNumber,
            string i_carModel, 
            string i_licenseNumber, 
            eNumberOfDoors i_numberOfDoors,
            eCarColor i_carColor, 
            string i_manufacturerName,
            float i_currentAirPressure) : 
            base(i_ownerName, i_ownerPhoneNumber, i_carModel, i_licenseNumber)
        {
            r_NumberOfDoors = i_numberOfDoors;
            r_CarColor = i_carColor;
            m_WheelData = new Wheel(i_manufacturerName, i_currentAirPressure, r_MaxAirPressure);
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

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_WheelData.ToString() + "\n");
            vehicleStringData.Append("Number Of Doors: " + r_NumberOfDoors + "\n");
            vehicleStringData.Append("Car Color: " + r_CarColor);
            return string.Format(vehicleStringData.ToString());
        }

        public static Dictionary<string, string> dataFromUser()
        {
            Dictionary<string, string> dataToGet = Vehicle.dataFromUser();            
            dataToGet.Add("Please enter number of doors (two, three, four, five): ",
                "enum: two, three, four, five");
            dataToGet.Add("Please enter car color (red, white, black or silver): ",
                "enum: red, white, black, silver");
            dataToGet.Add("Please enter wheels manufacturer name: ", "string");
            dataToGet.Add("Please enter current air pressure in wheels (smaller than max: "
                 + r_MaxAirPressure + " : ", "float");
            return dataToGet;
        }
    }
}