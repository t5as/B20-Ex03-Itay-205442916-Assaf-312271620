using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eNumberOfDoors m_NumberOfDoors;
        private eCarColor m_CarColor;
        private readonly byte r_NumberOfWheels = 4;
        private static readonly byte r_MaxAirPressure = 32;
        private Wheel m_WheelData;

        /*public Car(
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
        }*/

        public Car(Vehicle i_vehicle) : base(i_vehicle.OwnerName,
            i_vehicle.OwnerPhoneNumber, i_vehicle.CarModel, i_vehicle.LicenseNumber)
        {
            m_WheelData = new Wheel(r_MaxAirPressure);
        }

        public Wheel WheelData
        {
            get
            {
                return m_WheelData;
            }
        }

        public enum eCarColor
        {
            Red,
            White,
            Black,
            Silver
        } 

        public eCarColor CarColor
        {
            set
            {
                m_CarColor = value;
            }
        } 

        public eCarColor getCarColor(string i_carColor)
        {
            switch (i_carColor.ToLower())
            {
                case "red":
                    return eCarColor.Red;
                    break;
                case "white":
                    return eCarColor.White;
                    break;
                case "black":
                    return eCarColor.Black;
                    break;
                default:
                    return eCarColor.Silver;
                    break;
            }
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public eNumberOfDoors NumberOfDoors
        {
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public eNumberOfDoors getNumberOfDoors(string i_numberOfDoors)
        {
            switch (i_numberOfDoors.ToLower())
            {
                case "two":
                    return eNumberOfDoors.Two;
                    break;
                case "three":
                    return eNumberOfDoors.Three;
                    break;
                case "four":
                    return eNumberOfDoors.Four;
                    break;
                default:
                    return eNumberOfDoors.Five;
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleStringData = new StringBuilder();
            vehicleStringData.Append(base.ToString() + "\n");
            vehicleStringData.Append(m_WheelData.ToString() + "\n");
            vehicleStringData.Append("Number Of Doors: " + m_NumberOfDoors + "\n");
            vehicleStringData.Append("Car Color: " + m_CarColor);
            return string.Format(vehicleStringData.ToString());
        }

        public static Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = new Dictionary<string, string[]>();
            dataToGet.Add("NumberOfDoors", new string[] {"Please enter number of doors (two, three, four, five): ",
                "enum: two, three, four, five" });
            dataToGet.Add("CarColor", new string[] {"Please enter car color (red, white, black or silver): ",
                "enum: red, white, black, silver" });
            dataToGet.Add("ManufacturerName", new string[] { "Please enter wheels manufacturer name: ", "string" });
            dataToGet.Add("CurrentAirPressure", new string[] {"Please enter current air pressure in wheels (smaller than max: "
                 + r_MaxAirPressure + "): ", "float" });
            return dataToGet;
        }
    }
}