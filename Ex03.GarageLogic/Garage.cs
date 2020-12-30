using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<VehicleInGarageInfo> m_VehiclesInGarageCollection = new List<VehicleInGarageInfo>();
        public AllocationManagement m_ManageVehicales = new AllocationManagement();

        public Vehicle GetVehicleFromCollection(string i_LicenseNumberToFind)
        {
            Vehicle vehicleToReturn = null;
            foreach (VehicleInGarageInfo vehicleInfo in m_VehiclesInGarageCollection)
            {
                if (vehicleInfo.GetVehicle.GetLicenseNumber.Equals(i_LicenseNumberToFind))
                {
                    vehicleToReturn = vehicleInfo.GetVehicle;
                }
            }

            return vehicleToReturn;
        }

        public List<VehicleInGarageInfo> GetVehiclesCollection
        {
            get
            {
                return m_VehiclesInGarageCollection;
            }

            set
            {
                m_VehiclesInGarageCollection = value;
            }
        }

        public bool IsVehicleInGarage(string i_LicenseNumberToFind, eVehicleStatus i_NewStatus = eVehicleStatus.InShop)
        {
            if ((int)i_NewStatus < (int)eVehicleStatus.InShop || (int)i_NewStatus > (int)eVehicleStatus.Paid)
            {
                throw new ValueOutOfRangeException("Vehicel status", (int)eVehicleStatus.InShop, (int)eVehicleStatus.Paid);
            }

            bool VehicleFound = false;
            if (m_VehiclesInGarageCollection == null)
            {
                VehicleFound = false;
            }
            else
            {
                for (int i = 0; i < m_VehiclesInGarageCollection.Count && VehicleFound == false; i++)
                {
                    VehicleFound = m_VehiclesInGarageCollection[i].GetVehicle.GetLicenseNumber.Equals(i_LicenseNumberToFind);
                    if (VehicleFound)
                    {
                        m_VehiclesInGarageCollection[i].GetVehicleStatus = i_NewStatus;
                    }
                }
            }

            return VehicleFound;
        }

        public void PrintAllLicenseNumber()
        {
            foreach (VehicleInGarageInfo vehicle in m_VehiclesInGarageCollection)
            {
                vehicle.PrintVehicleLicenseNumber();
            }
        }

        public void PrintLicenseNumberByStatus(eVehicleStatus i_StatusToPrint)
        {
            foreach (VehicleInGarageInfo vehicle in m_VehiclesInGarageCollection)
            {
                if (i_StatusToPrint == vehicle.GetVehicleStatus)
                {
                    vehicle.PrintVehicleLicenseNumber();
                }
            }
        }
    }
}
