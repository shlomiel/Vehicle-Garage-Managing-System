using System.Collections.Generic;

namespace Ex03.GarageLogic
{ 
    public class ElectricCar : Car
    {
        private static readonly float sr_BatteryHoursCapacity = 2.1f;

        public ElectricCar(string o_LicenseNumber) : base(o_LicenseNumber)
        {
            m_VehicleRequiredFields.Add(string.Format("Current battery amount in hours (maximum {0} hours)", sr_BatteryHoursCapacity));
        }

          public override void FullVehicleSetter(List<string> io_DataStrings) 
        {
            base.FullVehicleSetter(io_DataStrings);
            m_Engine = new ElectricEngine(float.Parse(io_DataStrings[(int)eDataIndex.CurrentPowerIndex]), sr_BatteryHoursCapacity);
        }
    }
}
