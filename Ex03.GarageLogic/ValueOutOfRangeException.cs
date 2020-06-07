using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;
        
        public float MinValue
        {
            get { return m_MinValue; }
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public ValueOutOfRangeException(
            Exception i_innerException,
            float i_currentValue,
            float i_minValue,
            float i_maxValue)
            : base(
                string.Format("Value {0} out of range {1}-{2}", i_currentValue, i_minValue, i_maxValue),
                i_innerException)
        {
        }
    }
}
