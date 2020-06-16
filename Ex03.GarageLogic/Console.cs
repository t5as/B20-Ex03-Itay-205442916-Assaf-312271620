using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Console
    {
        public static Vehicle Creater()
        {
            System.Console.WriteLine("please enter name: ");
            string ownername = "avi";
            System.Console.WriteLine("please enter phone number: ");
            string phone = "0522222001";
            System.Console.WriteLine("please enter car model: ");
            string model = "mazda";
            System.Console.WriteLine("please enter license number: ");
            string license = "1122294";
            return new Vehicle(ownername, phone, model, license);

        } 

        public static string getCarType(string[] i_typesArray)
        {
            foreach(string vehicleType in i_typesArray)
            {
                System.Console.WriteLine("For " + vehicleType +
                    " press: " + Array.IndexOf(i_typesArray, vehicleType));
            }
            return i_typesArray[4];
        }
    }
}
