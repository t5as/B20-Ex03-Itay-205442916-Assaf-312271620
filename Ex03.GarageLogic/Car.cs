using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private static readonly byte r_MaxAirPressure = 32;
        private readonly byte r_NumberOfWheels = 4;
        private eNumberOfDoors m_NumberOfDoors;
        private eCarColor m_CarColor;
        private Wheel m_WheelData;

        public static Dictionary<string, string[]> dataFromUser()
        {
            Dictionary<string, string[]> dataToGet = new Dictionary<string, string[]>();
            dataToGet.Add(
                "NumberOfDoors",
                new string[] 
                    {
                                     "Please enter number of doors (two, three, four, five): ",
                                     "enum: two, three, four, five"
                                 });
            dataToGet.Add(
                "CarColor",
                new string[]
                    {
                        "Please enter car color (red, white, black or silver): ",
                        "enum: red, white, black, silver"
                    });
            dataToGet.Add(
                "ManufacturerName",
                new string[] { "Please enter wheels manufacturer name: ", "string" });
            dataToGet.Add(
                "CurrentAirPressure",
                new string[] { "Please enter current air pressure in wheels (smaller than max: " + r_MaxAirPressure + "): ", "float" });
            return dataToGet;
        }

        public Car(Vehicle i_vehicle) : base(
            i_vehicle.OwnerName,
            i_vehicle.OwnerPhoneNumber, 
            i_vehicle.VehicleModel, 
            i_vehicle.LicenseNumber)
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

        public eCarColor GetCarColor(string i_CarColor)
        {
            switch (i_CarColor.ToLower())
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

        public eNumberOfDoors GetNumberOfDoors(string i_NumberOfDoors)
        {
            switch (i_NumberOfDoors.ToLower())
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

        public override void inflateWheels()
        {
            m_WheelData.SetAirPressureToMax();
        }
    }
}