using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private Garage m_AllVehiclesInGarageInfo = new Garage();

        private void addVehicle()
        {
            try
            {
                int vehicleTypeSelection;
                string licenseNumberEntered;
                List<string> dataList = new List<string>();
                Console.WriteLine("Please enter license number :");
                licenseNumberEntered = Console.ReadLine();
                if (m_AllVehiclesInGarageInfo.IsVehicleInGarage(licenseNumberEntered) == true)
                {
                    Console.WriteLine("The vehicle is already registerded in the garage, currently starting work on it");
                }
                else
                {
                    List<string> vehicleOptions = AllocationManagement.GetVehicleOptions;
                    Console.WriteLine("Please enter vehicle type selection :");
                    foreach (string vehicleType in vehicleOptions)
                    {
                        Console.WriteLine(vehicleType);
                    }

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out vehicleTypeSelection) == false)
                    {
                        throw new FormatException(string.Format("{0} is not a number, please select valid vehicle type", input));
                    }

                    if (vehicleTypeSelection < 1 || vehicleTypeSelection > vehicleOptions.Count)
                    {
                        throw new ValueOutOfRangeException("Vehicle type", 1, vehicleOptions.Count);
                    }

                    VehicleInGarageInfo theNewVehicleInGarageInfo = new VehicleInGarageInfo(AllocationManagement.GetNewVehicle((eVehicleType)vehicleTypeSelection, licenseNumberEntered));

                    Console.WriteLine("Please supply us with :");
                    foreach (string requiredField in theNewVehicleInGarageInfo.GetVehicle.GetRequiredFields)
                    {
                        Console.WriteLine(requiredField);
                        dataList.Add(Console.ReadLine());
                    }

                    Console.WriteLine("Please enter vehicle owner name :");
                    theNewVehicleInGarageInfo.GetOwnerName = Console.ReadLine();
                    Console.WriteLine("Please enter vehicle owner phone :");
                    theNewVehicleInGarageInfo.GetOwnerPhoneNumber = Console.ReadLine();
                    AllocationManagement.SetVehicleData(dataList, theNewVehicleInGarageInfo.GetVehicle);    // set all new data in vehicle
                    m_AllVehiclesInGarageInfo.GetVehiclesCollection.Add(theNewVehicleInGarageInfo);  // add new vehicleInfo in List
                    Console.WriteLine("Vehicle was added successfully");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void presentAllLicenseNumberByStatus()
        {
            try
            {
                int userSelection;
                Console.WriteLine("please select {0}1)View all vehicles currently getting fixed{0}2)View all fixed vehicles{0}3)View all paid vehicles{0}4)View all vehicles:", Environment.NewLine);
                string input = Console.ReadLine();
                if (int.TryParse(input, out userSelection) == false)
                {
                    throw new FormatException(string.Format("{0} is not a number, please select valid vehicle type", input));
                }

                if (userSelection < 1 || userSelection > 4)
                {
                    throw new ValueOutOfRangeException("Vehicle type", 1, 4); // 3 options for specific vehicle status 1 for all vehicles
                }

                if (userSelection == 4)
                {
                    m_AllVehiclesInGarageInfo.PrintAllLicenseNumber();
                }
                else
                {
                    m_AllVehiclesInGarageInfo.PrintLicenseNumberByStatus((eVehicleStatus)userSelection);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void changeVehicleStatus()
        {
            try
            {
                Console.WriteLine("Please enter license number to change status for:");
                string licenseNumberEntered = Console.ReadLine();
                Console.WriteLine("Please enter status to change to:{0}1)Getting fix{0}2)Fixed{0}3)Paid{0}", Environment.NewLine);
                eVehicleStatus newStatus = (eVehicleStatus)int.Parse(Console.ReadLine());
                if (m_AllVehiclesInGarageInfo.IsVehicleInGarage(licenseNumberEntered, newStatus) == true)
                {
                    Console.WriteLine("Status changed successfuly");
                }
                else
                {
                    Console.WriteLine("License number does not exists in the garage");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Status selection should be an integer. {0}", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fillAirPressureToMax()
        {
            try
            {
                Console.WriteLine("Please enter license number to fill air pressure for:");
                string licenseNumberEntered = Console.ReadLine();
                Vehicle vehicleToFillAirPressure = m_AllVehiclesInGarageInfo.GetVehicleFromCollection(licenseNumberEntered);
                if (vehicleToFillAirPressure != null)
                {
                    vehicleToFillAirPressure.FillUpWheelsToMax();
                }
                else
                {
                    Console.WriteLine("Vehicle {0} not found", licenseNumberEntered);
                }
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fillUpFuel()
        {
            try
            {
                Console.WriteLine("Please enter license number to fill fuel for:");
                string licenseNumberEntered = Console.ReadLine();
                Vehicle vehicleToFillGas = m_AllVehiclesInGarageInfo.GetVehicleFromCollection(licenseNumberEntered);
                if (vehicleToFillGas != null)
                {
                    Console.WriteLine("Please enter fuel amount to fill:");
                    float amountToFill = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter fuel type:{0}1)Soler{0}2)Octan 95{0}3)Octan 96{0}4)Octan 98", Environment.NewLine);
                    eFuleType fuelType = (eFuleType)int.Parse(Console.ReadLine());
                    FueledEngine theRelevantEngine = vehicleToFillGas.GetEngine as FueledEngine;
                    if (theRelevantEngine == null)
                    {
                        throw new ArgumentException(string.Format("The vehicle {0} is electric vehicle, enter fuel one", licenseNumberEntered));
                    }
                    else
                    {
                        theRelevantEngine.FillFuel(amountToFill, fuelType);
                    }
                }
            }
            catch
            (FormatException ex)
            {
                Console.WriteLine("fuel amount to fill should be a number. {0}", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fillUpBattery()
        {
            try
            {
                Console.WriteLine("Please enter license number to fill battery for:");
                string licenseNumberEntered = Console.ReadLine();
                Vehicle vehicleToFillBattery = m_AllVehiclesInGarageInfo.GetVehicleFromCollection(licenseNumberEntered);
                if (vehicleToFillBattery != null)
                {
                    Console.WriteLine("Please enter battery amount to fill:");
                    float amountToFill = float.Parse(Console.ReadLine());
                    ElectricEngine theRelevantEngine = vehicleToFillBattery.GetEngine as ElectricEngine;
                    if (theRelevantEngine == null)
                    {
                        throw new ArgumentException(string.Format("The vehicle {0} is fuled vehicle, enter electric one", licenseNumberEntered));
                    }
                    else
                    {
                        theRelevantEngine.FillBattery(amountToFill);
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("battery amount to fill should be a number. {0}", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine("The amount is not in range, enter amount between {0} to {1}", ex.GetMinValue, ex.GetMaxValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void printAllDetails()
        {
            try
            {
                bool carIsFound = false;
                Console.WriteLine("Please enter license number to view detailes for:");
                string licenseNumberEntered = Console.ReadLine();

                foreach (VehicleInGarageInfo vehicleInfo in m_AllVehiclesInGarageInfo.GetVehiclesCollection)
                {
                    if (vehicleInfo.GetVehicle.GetLicenseNumber == licenseNumberEntered)
                    {
                        carIsFound = true;
                        Console.WriteLine(vehicleInfo.PrintAllVehicleInfo());
                    }
                }

                if (carIsFound == false)
                {
                    Console.WriteLine("License number {0} not found in garage", licenseNumberEntered);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartMenu()
        {
            int userSelection;
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine("Please select an option from the menu:");
                Console.WriteLine("1)Add vehicle{0}2)Present all license numbers by vehicle status{0}3)Change vehicle status{0}4)Fill vehicle air pressure{0}5)Fill vehicle fuel{0}6)Fill vehicle battery{0}7)Present a vehicle`s detailes{0}8)exit program", Environment.NewLine);
                int.TryParse(Console.ReadLine(), out userSelection);
                switch (userSelection)
                {
                    case 1:
                        addVehicle();
                        break;
                    case 2:
                        presentAllLicenseNumberByStatus();
                        break;
                    case 3:
                        changeVehicleStatus();
                        break;
                    case 4:
                        fillAirPressureToMax();
                        break;
                    case 5:
                        fillUpFuel();
                        break;
                    case 6:
                        fillUpBattery();
                        break;
                    case 7:
                        printAllDetails();
                        break;
                    case 8:
                        Console.WriteLine("Bye bye");
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("Please select an option 1-7 only!");
                        StartMenu();
                        break;
                }
            }
        }
    }
}
