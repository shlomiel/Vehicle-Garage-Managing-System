using System;

namespace Ex03.GarageLogic
{
    public enum eFuleType
    {
        Soler = 1,
        Octan95,
        Octan96,
        Octan98
    }

    public class FueledEngine : Engine
    {
        private eFuleType m_FuelType;

        public FueledEngine(eFuleType i_FuelType, float o_CurrentPowerAmount, float o_MaxTankCapacity)
            : base(o_CurrentPowerAmount, o_MaxTankCapacity)
        {
            if (m_CurrentPowerAmount > m_MaxPowerCapacity || m_CurrentPowerAmount < 0)
            {
                throw new ValueOutOfRangeException("Current fuel amount", 0f, m_MaxPowerCapacity);
            }

            m_FuelType = i_FuelType;
        }

        public void FillFuel(float i_FuelAmount, eFuleType i_FuelType)
        {
            if (i_FuelAmount + m_CurrentPowerAmount <= m_MaxPowerCapacity)
            {
                if (i_FuelType == m_FuelType)
                {
                    m_CurrentPowerAmount += i_FuelAmount;
                    m_EnergyPrecentLeft = (m_CurrentPowerAmount / m_MaxPowerCapacity) * 100;
                }
                else
                {
                    throw new ArgumentException(string.Format(
                        "Fill failed. the correct fuel type for the vehicle is {0}. you chose {1}", m_FuelType, i_FuelType));
                }
            }
            else
            {
                throw new ValueOutOfRangeException(0f, m_MaxPowerCapacity - m_CurrentPowerAmount);
            }
        }

        public override string PrintEngine()
        {
            return string.Format("Fuel Percent:{1}%{0}Fuel Type:{2}", Environment.NewLine, m_EnergyPrecentLeft, m_FuelType);
        }
    }
}
