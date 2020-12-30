using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufactorName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufactorName, float i_currentAirPressure, float i_maxAirPressure)
        {
            m_MaxAirPressure = i_maxAirPressure;
            if (m_MaxAirPressure < i_currentAirPressure || i_currentAirPressure < 0)
            {
                throw new ValueOutOfRangeException("Air pressure", 0f, m_MaxAirPressure);
            }

            m_CurrentAirPressure = i_currentAirPressure;
            m_ManufactorName = i_ManufactorName;
        }

        public void checkAndFillAirPressure(float i_AirPressureToAdd)
        {
            if (i_AirPressureToAdd + m_CurrentAirPressure <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0f, m_MaxAirPressure - m_CurrentAirPressure);
            }
        }

        public float GetMaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        public float GetCurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public string GetManufactor
        {
            get
            {
                return m_ManufactorName;
            }

            set
            {
                m_ManufactorName = value;
            }
        }

        public string PrintWheelDetailes()
        {
            return string.Format("Wheel Manufactor:{1}{0}Current PSI:{2}{0}", Environment.NewLine, m_ManufactorName, m_CurrentAirPressure);
        }
    }
}
