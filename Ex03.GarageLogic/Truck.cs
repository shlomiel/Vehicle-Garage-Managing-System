using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static readonly float sr_FuelTankCapacity = 120f;
        private static readonly eFuleType sr_FuelMotorType = eFuleType.Soler;
        private static readonly int sr_NumberOfWheels = 16;
        private static readonly float sr_MaxPSI = 28;
        private bool m_HasHazardousMatirials;
        private float m_CargoCapacity;

        public Truck(string i_LicenseNumber) : base(i_LicenseNumber)
        {
            m_VehicleRequiredFields.Add("What is the cargo capacity");
            m_VehicleRequiredFields.Add("Does the truck carry dangerous matirials? (true/false)");
            m_VehicleRequiredFields.Add(string.Format("Current fuel amount in liters (maximum {0}L)", sr_FuelTankCapacity));
        }

        public override string PrintVehicle()
        {
            base.PrintVehicle();
            return m_VehicleInfoToPrint += string.Format("Truck carries hazard matirials:{1}{0}Truck cargo capacity:{2}{0}", Environment.NewLine, m_HasHazardousMatirials, m_CargoCapacity);
        }

        public bool GetHasHazardousMatirials
        {
            get
            {
                return m_HasHazardousMatirials;
            }

            set
            {
                m_HasHazardousMatirials = value;
            }
        }

        public float GetCargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }

            set
            {
                m_CargoCapacity = value;
            }
        }

        public override void FullVehicleSetter(List<string> io_DataStrings)
        {
            base.FullVehicleSetter(io_DataStrings);
            bool hasHazardousMaterial;
            float cargoCapacity;
            if (bool.TryParse(io_DataStrings[AllocationManagement.GetIndexInDataList(eDataIndex.TruckHasDangerousMatirialsIndex)], out hasHazardousMaterial) == false)
            {
                throw new FormatException("Invalid input for dangerous materials field, please enter either true or false");
            }

            GetHasHazardousMatirials = hasHazardousMaterial;

            if (float.TryParse(io_DataStrings[AllocationManagement.GetIndexInDataList(eDataIndex.TrunkCapacityIndex)], out cargoCapacity) == false)
            {
                throw new FormatException("Invalid input for cargo capacity field, please enter a number");
            }

            m_CargoCapacity = cargoCapacity;
            m_Engine = new FueledEngine(sr_FuelMotorType, float.Parse(io_DataStrings[(int)eDataIndex.CurrentPowerIndex]), sr_FuelTankCapacity);

            while (m_WheelCollection.Count < sr_NumberOfWheels)
            {
                m_WheelCollection.Add(new Wheel(io_DataStrings[(int)eDataIndex.ManufacIndex], float.Parse(io_DataStrings[(int)eDataIndex.CurrentPSIIndex]), sr_MaxPSI));
            }
        }
    }
}
