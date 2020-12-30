namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float o_CurrentPowerAmount, float o_MaxBatteryCapacity) : base(o_CurrentPowerAmount, o_MaxBatteryCapacity)
        {
            if(m_CurrentPowerAmount > m_MaxPowerCapacity || m_CurrentPowerAmount < 0)
            {
                throw new ValueOutOfRangeException("Current battery amount", 0f, m_MaxPowerCapacity);
            }
        }

        public void FillBattery(float i_BatteryAmountToFill)
        {
            if (i_BatteryAmountToFill + m_CurrentPowerAmount <= m_MaxPowerCapacity)
            {
                m_CurrentPowerAmount += i_BatteryAmountToFill;
                m_EnergyPrecentLeft = (m_CurrentPowerAmount / m_MaxPowerCapacity) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(0f, m_MaxPowerCapacity - m_CurrentPowerAmount);
            }
        }

        public override string PrintEngine()
        {
            return string.Format("Battery Percent:{0}%", m_EnergyPrecentLeft);
        }
    }
}
