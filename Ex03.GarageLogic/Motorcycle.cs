using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            B1 = 2,
            AA = 3,
            BB = 4
        }

        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineVolume,
            string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, Energy i_EnergyType)
            : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyType)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVolume = i_EngineVolume;
        }

        public override string ToString()
        {
            
            return String.Format(
@"This vehicle is a motorcycle.
{0}The motorcycle license type is {1}.
The motorcycle engine volume is {2}.", base.ToString(), r_LicenseType, r_EngineVolume);
        }
    }
}
