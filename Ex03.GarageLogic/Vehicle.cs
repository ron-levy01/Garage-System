using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_Wheels;
        private readonly Energy r_EnergyType;

        public Vehicle(string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, Energy i_EnergyType)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            r_Wheels = i_Wheels;
            r_EnergyType = i_EnergyType;
        }

        public Energy EnergyType
        {
            get
            {
                
                return r_EnergyType;
            }
        }

        public void FillAirPressureOnTiersToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.FillTierToMax();
            }
        }

        public string LicenseNumber
        {
            get
            {
                
                return r_LicenseNumber;
            }
        }

        public override string ToString()
        {
            StringBuilder wheelsDetails = new StringBuilder();

            for (int i = 0; i < r_Wheels.Count; i++)
            {
                wheelsDetails.Append(String.Format("Wheel {0} information is:{1}{2}{1}", i + 1, Environment.NewLine,
                    r_Wheels[i].ToString()));
            }

            return string.Format(
@"The model name is {0}. 
The vehicle license number is {1}.
{2}
Wheels information: 
{3}", r_ModelName, r_LicenseNumber, r_EnergyType.ToString(), wheelsDetails);
        }
    }
}
