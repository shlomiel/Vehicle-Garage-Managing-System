using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InShop = 1,
        Fixed,
        Paid
    }

    public class VehicleInGarageInfo
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InShop;
        private Vehicle m_VehicleGettingFixed;

        public VehicleInGarageInfo(Vehicle i_VehicleToBeFixed)
        {
            m_VehicleGettingFixed = i_VehicleToBeFixed;
        }

        private bool checkPhoneNumberIsValid(string i_PhoneNumber)
        {
            int phoneNumber;
            return int.TryParse(i_PhoneNumber, out phoneNumber);
        }

        public string PrintAllVehicleInfo()
        {
            string strToPrint = string.Format("Owner name:{1}{0}Vehicle status:{2}{0}", Environment.NewLine, m_OwnerName, m_VehicleStatus);
            strToPrint += m_VehicleGettingFixed.PrintVehicle();
            return strToPrint;
        }

        public void PrintVehicleLicenseNumber()
        {
            Console.WriteLine(m_VehicleGettingFixed.GetLicenseNumber);
        }

        public string GetOwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        public string GetOwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                if (checkPhoneNumberIsValid(value) == false)
                {
                    throw new ArgumentException("Phone number should be consisted only from digits");
                }

                m_OwnerPhoneNumber = value;
            }
        }

        public Vehicle GetVehicle
        {
            get
            {
                return m_VehicleGettingFixed;
            }

            set
            {
                m_VehicleGettingFixed = value;
            }
        }

        public eVehicleStatus GetVehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }
    }
}
