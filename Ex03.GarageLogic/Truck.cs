using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_IsCarryingDangerousMaterials;
        private readonly float r_MaximumCarryingWeight;

        public Truck(bool i_IsCarryingDangerousMaterials, float i_MaximumCarryingWeight,
            string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, Energy i_EnergyType)
            : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyType)
        {
            r_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            r_MaximumCarryingWeight = i_MaximumCarryingWeight;
        }

        public override string ToString()
        {
            string dangerousMaterials = string.Empty;
           
            if(r_IsCarryingDangerousMaterials)
            {
                dangerousMaterials = "The truck is carrying dangerous materials.";
            }
            else
            {
                dangerousMaterials = "The truck is not carrying dangerous materials.";
            }
            
            return string.Format(
@"This vehicle is a truck.  
{0}{1}
The truck's maximum carrying weight is {2}."
, base.ToString(), dangerousMaterials, r_MaximumCarryingWeight);
        }
    }
}
