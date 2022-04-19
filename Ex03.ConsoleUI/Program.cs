using Ex03.GarageLogic;
using System;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public enum eGarageFunctions
        {
            EnterAVehicle = 1,
            PresentLicenseNumbers = 2,
            ChangeVehicleStatus = 3,
            FillTiersToMax = 4,
            Refuel = 5,
            ChargeBattery = 6,
            PresentVehicleInfo = 7,
            ExitGarage = 8
        }

        public static void Main()
        {
            startGarage();
        }

        private static void startGarage()
        {
            bool userWantsToExit = false;
            GarageLogic.Garage garage = new Garage();
            Console.WriteLine("Welcome to the Garage!!!");

            while (!userWantsToExit)
            {
                eGarageFunctions functionToBeExecuted = UIManager.PresentMenuOptions();
                functionExecuter(functionToBeExecuted, garage, ref userWantsToExit);
            }
        }

        private static void functionExecuter(eGarageFunctions i_Function, Garage i_Garage, ref bool io_UserWantsToExit)
        {
            switch (i_Function)
            {
                case eGarageFunctions.EnterAVehicle:
                    UIManager.EnterVehicle(i_Garage);
                    break;

                case eGarageFunctions.PresentLicenseNumbers:
                    UIManager.PresentLicenseNumbers(i_Garage);
                    break;

                case eGarageFunctions.ChangeVehicleStatus:
                    UIManager.ChangeVehicleStatus(i_Garage);
                    break;

                case eGarageFunctions.FillTiersToMax:
                    UIManager.FillTiersToMax(i_Garage);
                    break;

                case eGarageFunctions.Refuel:
                    UIManager.Refuel(i_Garage);
                    break;

                case eGarageFunctions.ChargeBattery:
                    UIManager.ChargeBattery(i_Garage);
                    break;

                case eGarageFunctions.PresentVehicleInfo:
                    UIManager.PresentVehicleInfo(i_Garage);
                    break;

                case eGarageFunctions.ExitGarage:
                    io_UserWantsToExit = true;
                    break;
            }
        }
    }
}
