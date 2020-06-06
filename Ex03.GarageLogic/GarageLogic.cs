using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        private List<Vehicle> m_GarageVehicles = new List<Vehicle>();
        private Vehicle stam = new Vehicle("aabbb", "1111", "mazda", "12343");
        
        public Vehicle searchVehicle(string i_licenseNumber)
        {
            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                if(vehicle.licenseNumber == i_licenseNumber)
                {
                    return vehicle;
                }
            }
            return null;
        } 
        


        
        
        
    }
}
