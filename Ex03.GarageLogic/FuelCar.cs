using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private static readonly float sr_FuelTankCapacity = 60f;
        private static readonly eFuleType sr_FuelMotorType = eFuleType.Octan96;

        public FuelCar(string o_LicenseNumber) : base(o_LicenseNumber)
        {
            m_VehicleRequiredFields.Add(string.Format("Current fuel amount in liters (maximum {0}L)", sr_FuelTankCapacity));
        }

        public override void FullVehicleSetter(List<string> io_DataStrings)
        {
            base.FullVehicleSetter(io_DataStrings);

            m_Engine = new FueledEngine(sr_FuelMotorType, float.Parse(io_DataStrings[(int)eDataIndex.CurrentPowerIndex]), sr_FuelTankCapacity);
        }
    }
}
