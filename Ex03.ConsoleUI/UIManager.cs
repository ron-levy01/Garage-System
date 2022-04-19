using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    class UIManager
    {
        private enum eSortOptions
        {
            All = 1,
            Reparing = 2,
            Repaired = 3,
            Payed = 4
        }

        private enum eVehicleType
        {
            Truck = 1,
            ElectricCar = 2,
            RegularCar = 3,
            ElectricMotorcycle = 4,
            RegularMotorcycle = 5
        }

        public static Program.eGarageFunctions PresentMenuOptions()
        {
            int requestedFunction;
            Console.WriteLine(String.Format(
                @"Choose your request action:
1 - Enter a new vehicle to the garage.
2 - Present list of license number in the garage (with option to sort by status).
3 - Change a vehicle status.
4 - Fill tiers air pressure to maximum.
5 - Refuel vehicle tank with gas.
6 - Charge an electric vehicle.
7 - Present full information about a vehicle.
8 - Exit the garage.
Enter the number representing your choice."));
            requestedFunction = getInputBetweenRange(1, 8);

            return (Program.eGarageFunctions)requestedFunction;
        }

        private static int getInputBetweenRange(int i_Min, int i_Max)
        {
            int inputInInt = i_Min - 1;
            string inputInString = string.Empty;
            bool isNumber = false;
            bool isInRange = false;

            while (!isNumber || !isInRange)
            {
                inputInString = Console.ReadLine();
                isNumber = int.TryParse(inputInString, out inputInInt);
                isInRange = inputInInt >= i_Min && inputInInt <= i_Max;
                if (isNumber && isInRange)
                {
                    break;
                }
                else if (!isNumber)
                {
                    Console.Write("Not a number, ");
                }
                else
                {
                    Console.Write("The number is not in range, ");
                }

                Console.WriteLine(string.Format("please enter a number between {0} - {1}", i_Min, i_Max));
            }

            return inputInInt;
        }

        public static void EnterVehicle(Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle's license number.");
            string licenseNumber = Console.ReadLine();

            if (i_Garage.CheckIfVehicleIsInGarage(licenseNumber))
            {
                Console.WriteLine("Your vehicle is already stored in our garage");
                i_Garage.ChangeVehicleStatus(licenseNumber, VehicleInformation.eVehicleStatus.Reparing);
            }
            else
            {
                Console.WriteLine("Please enter the vehicle owner's name");
                string ownersName = Console.ReadLine();
                Console.WriteLine("Please enter the vehicle owner's phone number");
                string ownerPhoneNumber = Console.ReadLine();
                i_Garage.AddVehicle(createVehicle(licenseNumber), ownersName, ownerPhoneNumber);
                Console.WriteLine(string.Format("The vehicle with license number {0} was successfully added to the garage.", licenseNumber));
            }
        }

        private static Vehicle createVehicle(string i_licenseNumber)
        {
            Vehicle createdVehicle = null;
            string modelName = string.Empty;
            string wheelsManufacturer = string.Empty;
            bool isElectric;

            Console.WriteLine(String.Format(
                @"Please choose your vehicle type: 
1 - Truck. 
2 - Electric car. 
3 - Regular car.
4 - Electric motorcycle.
5 - Regular motorcycle. 
Enter the number representing your choice."));
            eVehicleType requestedVehicleToCreate =
                (eVehicleType)getInputBetweenRange(1, 5);
            Console.WriteLine("Please enter the model name.");
            modelName = Console.ReadLine();
            Console.WriteLine("Please enter the wheels manufacturer name.");
            wheelsManufacturer = Console.ReadLine();

            switch (requestedVehicleToCreate)
            {
                case eVehicleType.Truck:
                    createdVehicle = createTruck(i_licenseNumber, modelName, wheelsManufacturer);
                    break;

                case eVehicleType.ElectricCar:
                    isElectric = true;
                    createdVehicle = createCar(i_licenseNumber, modelName, wheelsManufacturer, isElectric);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    isElectric = true;
                    createdVehicle = createMotorcycle(i_licenseNumber, modelName, wheelsManufacturer, isElectric);
                    break;

                case eVehicleType.RegularCar:
                    isElectric = false;
                    createdVehicle = createCar(i_licenseNumber, modelName, wheelsManufacturer, isElectric);
                    break;

                case eVehicleType.RegularMotorcycle:
                    isElectric = false;
                    createdVehicle = createMotorcycle(i_licenseNumber, modelName, wheelsManufacturer, isElectric);
                    break;
            }

            return createdVehicle;
        }

        private static Truck createTruck(string i_licenseNumber, string i_modelName, string i_wheelsManufacturer)
        {
            Console.WriteLine("Is the truck carrying dangerous materials? [Y/N] ");
            bool isCarryingDangerousMaterials = getValidYesOrNoAndReturnRespectively();
            Console.WriteLine("Please enter the truck's maximum carrying weight");
            float maximumCarryingWeight = getFloat();
            Truck truck = VehicleCreator.CreateTruck(isCarryingDangerousMaterials, maximumCarryingWeight
                , i_modelName, i_licenseNumber, i_wheelsManufacturer);

            return truck;
        }

        private static bool getValidYesOrNoAndReturnRespectively()
        {
            string input = string.Empty;
            bool isValidInput = false;
            bool isYes = false;

            while (!isValidInput)
            {
                input = Console.ReadLine();
                if (input == "Y")
                {
                    isYes = true;
                }
                else if (input == "N")
                {
                    isYes = false;
                }

                isValidInput = input == "Y" || input == "N";
                if (!isValidInput)
                {
                    Console.WriteLine("Not valid input, please enter [Y/N]");
                }
            }

            return isYes;
        }

        private static float getFloat()
        {
            string input = string.Empty;
            bool isNumber = false;
            float numberInFloat = 0;

            while (!isNumber)
            {
                input = Console.ReadLine();
                isNumber = float.TryParse(input, out numberInFloat);
                if (!isNumber)
                {
                    Console.WriteLine("Not a number, please enter a valid number.");
                }
            }

            return numberInFloat;
        }

        private static Car createCar(string i_licenseNumber, string i_modelName, string i_wheelsManufacturer,
            bool isElectric)
        {
            Car.eColor carColor = getCarColor();
            Car.eDoorsNumber carDoorNumber = getCarNumberOfDoors();
            Car createdCar;

            if (isElectric)
            {
                createdCar = VehicleCreator.CreateElectricCar(carColor, carDoorNumber, i_modelName, i_licenseNumber,
                    i_wheelsManufacturer);
            }
            else
            {
                createdCar = VehicleCreator.CreateFuelCar(carColor, carDoorNumber, i_modelName, i_licenseNumber,
                    i_wheelsManufacturer);
            }

            return createdCar;
        }

        private static Car.eColor getCarColor()
        {
            Console.WriteLine(string.Format(
                @"Please choose the color of the car:
1 - Red 
2 - Silver 
3 - White 
4 - Black
Enter the number representing your choice."));

            return (Car.eColor)getInputBetweenRange(1, 4);
        }

        private static Car.eDoorsNumber getCarNumberOfDoors()
        {
            Console.WriteLine("please enter your requested number of doors 2, 3, 4 or 5.");

            return (Car.eDoorsNumber)getInputBetweenRange(2, 5);
        }

        private static Motorcycle createMotorcycle(string i_licenseNumber, string i_modelName,
            string i_wheelsManufacturer,
            bool isElectric)
        {

            Motorcycle createdMotorcycle;
            Motorcycle.eLicenseType licenseType = getLicenseType();
            Console.WriteLine("Please enter the motorcycle engine's volume.");
            int motorcycleEngineVolume = getInt();

            if (isElectric)
            {
                createdMotorcycle = VehicleCreator.CreateElectricMotorcycle(licenseType, motorcycleEngineVolume, i_modelName, i_licenseNumber,
                    i_wheelsManufacturer);
            }
            else
            {
                createdMotorcycle = VehicleCreator.CreateFuelMotorcycle(licenseType, motorcycleEngineVolume, i_modelName, i_licenseNumber,
                    i_wheelsManufacturer);
            }

            return createdMotorcycle;
        }

        private static Motorcycle.eLicenseType getLicenseType()
        {
            Console.WriteLine(string.Format(
                @"Please choose the license type:
1 - A 
2 - B1 
3 - AA 
4 - BB
Enter the number representing your choice."));

            return (Motorcycle.eLicenseType)getInputBetweenRange(1, 4);
        }

        private static int getInt()
        {
            string input = string.Empty;
            bool isNumber = false;
            int numberInInt = 0;

            while (!isNumber)
            {
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out numberInInt);
                if (!isNumber)
                {
                    Console.WriteLine("Not a number, please enter a valid integer number.");
                }
            }

            return numberInInt;
        }

        public static void PresentLicenseNumbers(Garage i_Garage)
        {
            Console.WriteLine(string.Format(
                @"How would you like the license numbers the be sorted: 
1 - Show all.
2 - Show only vehicles that are currently repairing 
3 - Show only repaired vehicles.
4 - Show only payed vehicles.
Enter the number representing your choice."));
            eSortOptions requestedSort = (eSortOptions)getInputBetweenRange(1, 4);
            List<string> licenseNumbersList = null;

            switch (requestedSort)
            {
                case eSortOptions.All:
                    licenseNumbersList = i_Garage.GetLicenseNumbersList();
                    break;

                case eSortOptions.Reparing:
                    licenseNumbersList = i_Garage.GetLicenseNumbersList(VehicleInformation.eVehicleStatus.Reparing);
                    break;

                case eSortOptions.Repaired:
                    licenseNumbersList = i_Garage.GetLicenseNumbersList(VehicleInformation.eVehicleStatus.Repaired);
                    break;

                case eSortOptions.Payed:
                    licenseNumbersList = i_Garage.GetLicenseNumbersList(VehicleInformation.eVehicleStatus.Payed);
                    break;
            }

            if (licenseNumbersList.Count > 0)
            {
                Console.WriteLine("Here the requested license numbers:");
                foreach (string licenseNumber in licenseNumbersList)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
            else
            {
                Console.WriteLine("There is no vehicles in our garage matching your sort.");
            }
        }

        public static void ChangeVehicleStatus(Garage i_Garage)
        {
            if (i_Garage.IsGarageEmpty())
            {
                Console.WriteLine("The garage is empty");

                return;
            }

            string licenseNumber = getLicenseNumber(i_Garage);
            Console.WriteLine(string.Format(
@"Please enter the new vehicle status: 
1 - In repair.
2 - Repaired. 
3 - Payed. 
Enter the number representing your choice."));
            VehicleInformation.eVehicleStatus requestedStatus = (VehicleInformation.eVehicleStatus)getInputBetweenRange(1, 3);
            i_Garage.ChangeVehicleStatus(licenseNumber, requestedStatus);
            Console.WriteLine(string.Format("The vehicle with license number {0} changed its status to {1}", licenseNumber, requestedStatus));
        }

        private static string getLicenseNumber(Garage i_Garage)
        {
            bool isLicenseNumberInGarage = false;
            string licenseNumber = string.Empty;

            while (!isLicenseNumberInGarage)
            {
                Console.WriteLine("Please enter the vehicle license number");
                licenseNumber = Console.ReadLine();
                isLicenseNumberInGarage = i_Garage.CheckIfVehicleIsInGarage(licenseNumber);
                if (!isLicenseNumberInGarage)
                {
                    Console.WriteLine("There is no vehicle corresponding to this license number in our garage");
                }
            }

            return licenseNumber;
        }

        public static void FillTiersToMax(Garage i_Garage)
        {
            if (i_Garage.IsGarageEmpty())
            {
                Console.WriteLine("The garage is empty");

                return;
            }

            string licenseNumber = getLicenseNumber(i_Garage);
            i_Garage.FillAirPressureOnTiersToMax(licenseNumber);
            Console.WriteLine("Tiers were filled successfully");
        }

        public static void Refuel(Garage i_Garage)
        {
            if (i_Garage.IsGarageEmpty())
            {
                Console.WriteLine("The garage is empty");

                return;
            }

            string licenseNumber = getLicenseNumber(i_Garage);
            Console.WriteLine(string.Format(
@"Please enter the type of fuel requested: 
1 - Soler.
2 - Octan95. 
3 - Octan96. 
4 - Octan98.
Enter the number representing your choice."));
            FuelEnergy.eFuelType requestedFuelType = (FuelEnergy.eFuelType)getInputBetweenRange(1, 4);
            Console.WriteLine("Please enter the amount of fuel to fill.");
            float amountOfFuel = getFloat();
            try
            {
                i_Garage.FillTankWithFuel(licenseNumber, requestedFuelType, amountOfFuel);
                Console.WriteLine("Refueled that tank successfully");
            }
            catch (ValueOutOfRangeException amountNotInRangeException)
            {
                Console.WriteLine(string.Format("The requested amount is over the maximum tank's size which is {0} liters.",
                    amountNotInRangeException.MaxValue));
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        public static void ChargeBattery(Garage i_Garage)
        {
            if (i_Garage.IsGarageEmpty())
            {
                Console.WriteLine("The garage is empty");

                return;
            }

            string licenseNumber = getLicenseNumber(i_Garage);
            Console.WriteLine("Please enter the amount of minutes to charge.");
            float minutesToCharge = getFloat();
            try
            {
                i_Garage.ChargeBattery(licenseNumber, minutesToCharge);
                Console.WriteLine("Charged battery successfully.");
            }
            catch (ValueOutOfRangeException amountNotInRangeException)
            {
                Console.WriteLine(string.Format("The requested amount is over the maximum battery's capacity (which is {0} hours).",
                    amountNotInRangeException.MaxValue));
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
            }
        }

        public static void PresentVehicleInfo(Garage i_Garage)
        {
            if (i_Garage.IsGarageEmpty())
            {
                Console.WriteLine("The garage is empty");

                return;
            }

            string licenseNumber = getLicenseNumber(i_Garage);
            Console.WriteLine(i_Garage.PresentVehicleInformation(licenseNumber));
        }
    }
}
