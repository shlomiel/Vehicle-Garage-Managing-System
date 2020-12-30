using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : MotorCycle
    {
        private static readonly float sr_FuelTankCapacity = 7;
        private static readonly eFuleType sr_FuelMotorType = eFuleType.Octan95;

        public FuelMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber)
        {
            m_VehicleRequiredFields.Add(string.Format("Current fuel amount in liters (max {0}L)", sr_FuelTankCapacity));
        }

        public override void FullVehicleSetter(List<string> io_DataStrings)
        {
            base.FullVehicleSetter(io_DataStrings);

            m_Engine = new FueledEngine(sr_FuelMotorType, float.Parse(io_DataStrings[(int)eDataIndex.CurrentPowerIndex]), sr_FuelTankCapacity);
        }
    }
}
