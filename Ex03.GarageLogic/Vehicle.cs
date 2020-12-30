using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_WheelCollection = new List<Wheel>();
        protected Engine m_Engine;
        protected List<string> m_VehicleRequiredFields = new List<string>();
        protected string m_VehicleInfoToPrint;

        public Vehicle(string i_LicenseNumber)
        {
            m_LicenseNumber = i_LicenseNumber;
            createVehicleList();
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels, Wheel o_VehicleWheel)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_WheelCollection = new List<Wheel>();
            m_WheelCollection.Capacity = i_NumOfWheels;
            CreateWheelList(o_VehicleWheel);
        }

        public virtual void FullVehicleSetter(List<string> i_DataStrings)
        {
            GetModelName = i_DataStrings[(int)eDataIndex.ModelIndex];
        }

        private string printWheels()
        {
            string wheelsDetailes = null;
            foreach (Wheel wheel in m_WheelCollection)
            {
                if (wheelsDetailes == null)
                {
                    wheelsDetailes = wheel.PrintWheelDetailes();
                }
                else
                {
                    wheelsDetailes += wheel.PrintWheelDetailes();
                }
            }

            return wheelsDetailes;
        }

        public virtual string PrintVehicle()
        {
            return m_VehicleInfoToPrint = string.Format("License number:{1}{0}Model:{2}{0}{3}{4}{0}", Environment.NewLine, m_LicenseNumber, m_ModelName, printWheels(), m_Engine.PrintEngine());
        }

        public List<string> GetRequiredFields
        {
            get
            {
                return m_VehicleRequiredFields;
            }
        }

        public string GetModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string GetLicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public List<Wheel> GetWheels
        {
            get
            {
                return m_WheelCollection;
            }

            set
            {
                m_WheelCollection = value;
            }
        }

        public Engine GetEngine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                m_Engine = value;
            }
        }

        private void createVehicleList()
        {
            m_VehicleRequiredFields.Add("Model Name");
            m_VehicleRequiredFields.Add("Wheel Manufacturer");
            m_VehicleRequiredFields.Add("Wheel current PSI");
        }

        private void CreateWheelList(Wheel i_VehicleWheel)
        {
            for (int i = 0; i < m_WheelCollection.Capacity; i++)
            {
                m_WheelCollection.Add(i_VehicleWheel);
            }
        }

        public void FillUpWheelsToMax()
        {
            foreach (Wheel wheel in m_WheelCollection)
            {
                wheel.checkAndFillAirPressure(wheel.GetMaxAirPressure - wheel.GetCurrentAirPressure);
            }
        }
    }
}
