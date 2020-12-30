using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eNumOfDoors
    {
        TwoDoors = 2,
        ThreeDoors,
        FourDoors,
        FiveDoors
    }

    public enum eColor
    {
        Red = 1,
        White,
        Black,
        Silver
    }

    public class Car : Vehicle
    {
        private static readonly int sr_NumberOfWheels = 4;
        private static readonly float sr_MaxPSI = 32f;
        private eNumOfDoors m_NumOfDoors;
        protected eColor m_CarColor;

        public Car(string o_LicenseNumber) : base(o_LicenseNumber)
        {
            m_VehicleRequiredFields.Add("Number of doors(From 2 to 5)");
            m_VehicleRequiredFields.Add(string.Format("Car Color{0}1)Red{0}2)White{0}3)Black{0}4)Silver", Environment.NewLine));
        }

        public override void FullVehicleSetter(List<string> io_DataStrings)
        {
            base.FullVehicleSetter(io_DataStrings);
            if (int.Parse(io_DataStrings[(int)eDataIndex.NumOfDoorsIndex]) < (int)eNumOfDoors.TwoDoors || int.Parse(io_DataStrings[(int)eDataIndex.NumOfDoorsIndex]) > (int)eNumOfDoors.FiveDoors)
            {
                throw new ValueOutOfRangeException(m_VehicleRequiredFields[(int)eDataIndex.NumOfDoorsIndex], (float)eNumOfDoors.TwoDoors, (float)eNumOfDoors.FiveDoors);
            }

            m_NumOfDoors = (eNumOfDoors)int.Parse(io_DataStrings[(int)eDataIndex.NumOfDoorsIndex]);
            if (int.Parse(io_DataStrings[(int)eDataIndex.ColorIndex]) < (int)eColor.Red || int.Parse(io_DataStrings[(int)eDataIndex.ColorIndex]) > (int)eColor.Silver)
            {
                throw new ValueOutOfRangeException(string.Format(m_VehicleRequiredFields[(int)eDataIndex.ColorIndex] + Environment.NewLine), (float)eColor.Red, (float)eColor.Silver);
            }
   
            m_CarColor = (eColor)int.Parse(io_DataStrings[(int)eDataIndex.ColorIndex]);
            while (m_WheelCollection.Count < sr_NumberOfWheels)
            {
                m_WheelCollection.Add(new Wheel(io_DataStrings[(int)eDataIndex.ManufacIndex], float.Parse(io_DataStrings[(int)eDataIndex.CurrentPSIIndex]), sr_MaxPSI));
            }
        }

        public override string PrintVehicle()
        {
            base.PrintVehicle();
            return m_VehicleInfoToPrint += string.Format("Number of doors:{0}\nCar color:{1}\n", m_NumOfDoors, m_CarColor);
        }

        public eNumOfDoors GetNumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }

        public eColor GetCarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public float GetMaxPSI
        {
            get
            {
                return sr_MaxPSI;
            }
        }
    }
}
