using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEnergy : Energy
    {
        public ElectricEnergy(float i_MaxBatteryTimeInHours) : base(i_MaxBatteryTimeInHours)
        {
        }

        public float CurrentTimeLeftInBatteryInHours
        {
            get
            {
                
                return m_CurrentEnergy;
            }
        }

        public float MaximumTimeOfBatteryInHours
        {
            get
            {
                
                return r_MaxEnergy;
            }
        }

        public override string ToString()
        {
            
            return string.Format("The vehicle is electric. {0}The battery is {1}% full. {0}", Environment.NewLine,
                m_PrecentageEnergyLeft);
        }
    }
}
