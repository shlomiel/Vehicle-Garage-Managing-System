using System;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentPowerAmount;
        protected float m_MaxPowerCapacity;
        protected float m_EnergyPrecentLeft;

        public Engine(float i_CurrentPowerAmount, float i_MaxCapacity)
        {
            m_MaxPowerCapacity = i_MaxCapacity;
            m_CurrentPowerAmount = i_CurrentPowerAmount;
            m_EnergyPrecentLeft = (i_CurrentPowerAmount / i_MaxCapacity) * 100;
        }
 
        public float GetCurrentPowerAmount
        {
            get
            {
                return m_CurrentPowerAmount;
            }

            set
            {
                m_CurrentPowerAmount = value;
            }
        }

        public float GetMaxCapacity
        {
            get
            {
                return m_MaxPowerCapacity;
            }

            set
            {
                m_MaxPowerCapacity = value;
            }
        }

        public abstract string PrintEngine();
    }
}
