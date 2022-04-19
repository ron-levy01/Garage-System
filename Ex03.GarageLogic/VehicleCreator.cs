using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        private const int k_TruckNumberOfWheels = 16;
        private const float k_TruckWheelMaxTierPressure = 26f;
        private const float k_TruckMaxFuelTankInLiters = 120f;
        private const int k_MotorcycleNumberOfWheels = 2;
        private const float k_MotorcycleWheelMaxTierPressure = 30f;
        private const float k_MotorcycleBatteryMaxTimeInHour = 1.8f;
        private const float k_FuelMotorcycleMaxTankInLiters = 6f;
        private const FuelEnergy.eFuelType k_MotorcycleFuelType = FuelEnergy.eFuelType.Octan98;
        private const float k_CarMaxTierPressure = 32f;
        private const int k_CarNumberOfWheels = 4;
        private const FuelEnergy.eFuelType k_CarFuelType = FuelEnergy.eFuelType.Octan95;
        private const float k_CarBatteryMaxTimeInHours = 3.2f;
        private const float k_CarMaxFuelTankInLiters = 45f;

        public static Truck CreateTruck(bool i_IsCarryingDangerousMaterials, float i_MaximumCarryingWeight,
            string i_ModelName, string i_LicenseNumber, string i_ManufacturerName)
        {
            List<Wheel> truckWheels = createWheelList(i_ManufacturerName, k_TruckWheelMaxTierPressure,
                k_TruckNumberOfWheels);
            FuelEnergy truckFuelEnergy = new FuelEnergy(FuelEnergy.eFuelType.Soler, k_TruckMaxFuelTankInLiters);
            Truck truck = new Truck(i_IsCarryingDangerousMaterials, i_MaximumCarryingWeight, i_ModelName,
                i_LicenseNumber
                , truckWheels, truckFuelEnergy);

            return truck;
        }

        private static List<Wheel> createWheelList(string i_ManufacturerName, float i_WheelMaxTierPressure, int i_NumberOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>(i_NumberOfWheels);

            for(int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel currentWheel = new Wheel(i_ManufacturerName, 0, 
                    i_WheelMaxTierPressure);
                wheels.Add(currentWheel);
            }

            return wheels;
        }

        public static Motorcycle CreateElectricMotorcycle(Motorcycle.eLicenseType i_motorcycleLicenseType, int i_EngineVolume,
            string i_ModelName, string i_LicenseNumber, string i_ManufacturerName)
        {
            List<Wheel> motorcycleWheels = createWheelList(i_ManufacturerName, k_MotorcycleWheelMaxTierPressure,
                k_MotorcycleNumberOfWheels);
            ElectricEnergy motorcycleElectricEnergy = new ElectricEnergy(k_MotorcycleBatteryMaxTimeInHour);
            Motorcycle motorcycle = new Motorcycle(i_motorcycleLicenseType, i_EngineVolume, i_ModelName,
                i_LicenseNumber
                , motorcycleWheels, motorcycleElectricEnergy);

            return motorcycle;
        }

        public static Motorcycle CreateFuelMotorcycle(Motorcycle.eLicenseType i_motorcycleLicenseType, int i_EngineVolume,
            string i_ModelName, string i_LicenseNumber, string i_ManufacturerName)
        {
            List<Wheel> motorcycleWheels = createWheelList(i_ManufacturerName, k_MotorcycleWheelMaxTierPressure,
                k_MotorcycleNumberOfWheels);
            FuelEnergy motorcycleFuelEnergy = new FuelEnergy(k_MotorcycleFuelType, k_FuelMotorcycleMaxTankInLiters);
            Motorcycle motorcycle = new Motorcycle(i_motorcycleLicenseType, i_EngineVolume, i_ModelName,
                i_LicenseNumber
               , motorcycleWheels, motorcycleFuelEnergy);

            return motorcycle;
        }

        public static Car CreateElectricCar(Car.eColor i_Color, Car.eDoorsNumber i_DoorsNumber,
            string i_ModelName, string i_LicenseNumber, string i_ManufacturerName)
        {
            List<Wheel> carWheels = createWheelList(i_ManufacturerName, k_CarMaxTierPressure,
                k_CarNumberOfWheels);
            ElectricEnergy carElectricEnergy = new ElectricEnergy(k_CarBatteryMaxTimeInHours);
            Car car = new Car(i_Color, i_DoorsNumber, i_ModelName, i_LicenseNumber, carWheels, carElectricEnergy);

            return car;
        }

        public static Car CreateFuelCar(Car.eColor i_Color, Car.eDoorsNumber i_DoorsNumber,
            string i_ModelName, string i_LicenseNumber, string i_ManufacturerName)
        {
            List<Wheel> carWheels = createWheelList(i_ManufacturerName, k_CarMaxTierPressure,
                k_CarNumberOfWheels);
            FuelEnergy carFuelEnergy = new FuelEnergy(k_CarFuelType, k_CarMaxFuelTankInLiters);
            Car car = new Car(i_Color, i_DoorsNumber, i_ModelName, i_LicenseNumber, carWheels, carFuelEnergy);

            return car;
        }
    }
}
