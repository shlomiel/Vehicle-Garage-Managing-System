using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eDataIndex
    {
        ModelIndex,
        ManufacIndex,
        CurrentPSIIndex,
        NumOfDoorsIndex,
        ColorIndex,
        CurrentPowerIndex,
        BikeLicenseTypeIndex,
        BikeMotorCapacityIndex,
        TruckHasDangerousMatirialsIndex,
        TrunkCapacityIndex,
        CurrentFuelAmountIndex
    }

    public enum eVehicleType
    {
        FuelCar = 1,
        ElectricCar,
        FuelMotorcycle,
        ElectricMotorcycle,
        Truck
    }

    public class AllocationManagement
    {
        private static List<string> m_VehicleOptions = new List<string>();
        private static Dictionary<eDataIndex, int> m_IndexDictionary = new Dictionary<eDataIndex, int>();

        public AllocationManagement()
        {
            SetDictionary();
            m_VehicleOptions.Add("1)Fueled Car");
            m_VehicleOptions.Add("2)Electric Car");
            m_VehicleOptions.Add("3)Fueled Motorcycle");
            m_VehicleOptions.Add("4)Electric Motorcycle");
            m_VehicleOptions.Add("5)Fueled Truck");
        }

        public static int GetIndexInDataList(eDataIndex io_IndexToGet)
        {
            int indexToReturn;
            m_IndexDictionary.TryGetValue(io_IndexToGet, out indexToReturn);
            return indexToReturn;
        }

        public static List<string> GetVehicleOptions
        {
            get
            {
                return m_VehicleOptions;
            }

            set
            {
                m_VehicleOptions = value;
            }
        }

        public static Vehicle GetNewVehicle(eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    {
                        vehicleToReturn = new FuelCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricCar:
                    {
                        vehicleToReturn = new ElectricCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.FuelMotorcycle:
                    {
                        vehicleToReturn = new FuelMotorcycle(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricMotorcycle:
                    {
                        vehicleToReturn = new ElectricMotorcycle(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        vehicleToReturn = new Truck(i_LicenseNumber);
                        break;
                    }

                default:
                    {
                        vehicleToReturn = null;
                        break;
                    }
            }

            return vehicleToReturn;
        }

        private void SetDictionary()
        {
            m_IndexDictionary.Add(eDataIndex.BikeLicenseTypeIndex, 3);
            m_IndexDictionary.Add(eDataIndex.BikeMotorCapacityIndex, 4);
            m_IndexDictionary.Add(eDataIndex.ColorIndex, 4);
            m_IndexDictionary.Add(eDataIndex.CurrentPowerIndex, 5);
            m_IndexDictionary.Add(eDataIndex.CurrentPSIIndex, 2);
            m_IndexDictionary.Add(eDataIndex.ManufacIndex, 1);
            m_IndexDictionary.Add(eDataIndex.ModelIndex, 0);
            m_IndexDictionary.Add(eDataIndex.NumOfDoorsIndex, 3);
            m_IndexDictionary.Add(eDataIndex.TruckHasDangerousMatirialsIndex, 4);
            m_IndexDictionary.Add(eDataIndex.TrunkCapacityIndex, 3);
        }

        public static void SetVehicleData(List<string> o_dataList, Vehicle i_VihecleToSet)
        {
            i_VihecleToSet.FullVehicleSetter(o_dataList);
        }
    }
}
