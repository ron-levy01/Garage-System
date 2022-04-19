using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleInformation> r_VehiclesInGarage;

        public Garage()
        {
            r_VehiclesInGarage = new Dictionary<string, VehicleInformation>();
        }

        public void AddVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwenerPhoneNumber)
        {
            r_VehiclesInGarage.Add(i_Vehicle.LicenseNumber, new VehicleInformation(i_OwnerName, i_OwenerPhoneNumber, i_Vehicle));
        }

        public bool CheckIfVehicleIsInGarage(string i_VehicleLicenseNumber)
        {
            
            return r_VehiclesInGarage.ContainsKey(i_VehicleLicenseNumber);
        }

        public List<string> GetLicenseNumbersList()
        {

            return r_VehiclesInGarage.Keys.ToList();
        }

        public List<string> GetLicenseNumbersList(VehicleInformation.eVehicleStatus i_VehicleStatusToSort)
        {
            List<string> licenseNumbersList = new List<string>();

            foreach(VehicleInformation vehicleInfo in r_VehiclesInGarage.Values)
            {
                if(vehicleInfo.VehicleStatus.Equals(i_VehicleStatusToSort))
                {
                    licenseNumbersList.Add(vehicleInfo.Vehicle.LicenseNumber);
                }
            }

            return licenseNumbersList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleInformation.eVehicleStatus i_VehicleStatus)
        {
            r_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_VehicleStatus;
        }

        public void FillAirPressureOnTiersToMax(string i_LicenseNumber)
        {
            r_VehiclesInGarage[i_LicenseNumber].Vehicle.FillAirPressureOnTiersToMax();
        }

        public void FillTankWithFuel(string i_LicenseNumber, FuelEnergy.eFuelType i_FuelType, float i_AmountToFill)
        {
            FuelEnergy vehicleFuelEnergy = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EnergyType as FuelEnergy;
            
            if(vehicleFuelEnergy != null)
            {
                vehicleFuelEnergy.AddFuel(i_FuelType, i_AmountToFill);
            }
            else
            {
                throw new FormatException("The vehicle does not support fuel");
            }
        }

        public void ChargeBattery(string i_LicenseNumber, float i_ChargingMinutes)
        {
            ElectricEnergy vehicleElectricEnergy = r_VehiclesInGarage[i_LicenseNumber].Vehicle.EnergyType as ElectricEnergy;
            
            if(vehicleElectricEnergy != null)
            {
                vehicleElectricEnergy.FillEnergy(i_ChargingMinutes / 60);
            }
            else
            {
                throw new FormatException("The vehicle is not electric");
            }
        }

        public string PresentVehicleInformation(string i_LicenseNumber)
        {
            
            return r_VehiclesInGarage[i_LicenseNumber].ToString();
        }

        public bool IsGarageEmpty()
        {
            
            return r_VehiclesInGarage.Count == 0;
        } 
    }
}
