using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A = 1,
        A1,
        AA,
        B
    }

    public abstract class MotorCycle : Vehicle
    {
        private static readonly int sr_NumberOfWheels = 2;
        private static readonly float sr_MaxAirPressure = 30f;
        protected int m_EngineCapacity;
        public eLicenseType m_LicenseType;

        public MotorCycle(string i_LicenseNumber) : base(i_LicenseNumber)
        {
            m_VehicleRequiredFields.Add(string.Format("License Type{0}1)A{0}2)A1{0}3)AA{0}4)B", Environment.NewLine));
            m_VehicleRequiredFields.Add("Engine capacity(Integers only!)");
        }

        public override void FullVehicleSetter(List<string> io_DataStrings)
        {
            base.FullVehicleSetter(io_DataStrings);
            if (int.Parse(io_DataStrings[AllocationManagement.GetIndexInDataList(eDataIndex.BikeLicenseTypeIndex)]) < (int)eLicenseType.A || int.Parse(io_DataStrings[AllocationManagement.GetIndexInDataList(eDataIndex.BikeLicenseTypeIndex)]) > (int)eLicenseType.B)
            {
                throw new ValueOutOfRangeException("License Type", (float)eLicenseType.A, (float)eLicenseType.B);
            }

            m_LicenseType = (eLicenseType)int.Parse(io_DataStrings[AllocationManagement.GetIndexInDataList(eDataIndex.BikeLicenseTypeIndex)]);
            if (int.TryParse(io_DataStrings[AllocationManagement.GetIndexInDataList(eDataIndex.BikeMotorCapacityIndex)], out m_EngineCapacity) == false)
            {
                throw new FormatException("Motorcycle engine capacity should be an integer");
            }

            while (m_WheelCollection.Count < sr_NumberOfWheels)
            {
                m_WheelCollection.Add(new Wheel(io_DataStrings[(int)eDataIndex.ManufacIndex], float.Parse(io_DataStrings[(int)eDataIndex.CurrentPSIIndex]), sr_MaxAirPressure));
            }
        }

        public override string PrintVehicle()
        {
            base.PrintVehicle();
            return m_VehicleInfoToPrint += string.Format("Motorcycle engine capacity:{1}{0}LiecenseType:{2}{0}", Environment.NewLine, m_EngineCapacity, m_LicenseType);
        }

        public eLicenseType GetLicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int GetEngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }
        }
    }
}
