using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class NormalMotorcycle
    {
        private readonly byte m_numberOfWheels = 2;
        private Wheel m_wheelData = new Wheel(30);
        private FuelVehicle m_fuelData = new FuelVehicle(FuelVehicle.FuelType.Octan95, 7);
    }
}
