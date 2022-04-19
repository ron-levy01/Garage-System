using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red = 1, 
            Silver = 2, 
            White = 3,
            Black = 4
        }

        public enum eDoorsNumber
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        private readonly eColor r_Color;
        private readonly eDoorsNumber r_DoorsNumber;

        public Car(eColor i_Color, eDoorsNumber i_DoorsNumber,
            string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, Energy i_EnergyType)
            : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergyType)
        {
            r_Color = i_Color;
            r_DoorsNumber = i_DoorsNumber;
        }

        public override string ToString()
        {
            
            return String.Format(
@"This vehicle is a car. 
{0} The car color is {1}.
The number of doors in the car is {2}." ,base.ToString(), r_Color, r_DoorsNumber.ToString().ToLower());
        }
    }
}
