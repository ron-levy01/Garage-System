using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : Energy
    {
        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        private readonly eFuelType r_FuelType;
        
        public FuelEnergy(eFuelType i_FuelType, float i_MaximumFuelCapacity) 
            : base(i_MaximumFuelCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public float CurrentFuelInLiters
        {
            get
            {
                
                return m_CurrentEnergy;
            }
        }

        public float MaximumCapacityOfFuelInLiters
        {
            get
            {
                
                return r_MaxEnergy;
            }
        }

        public void AddFuel(eFuelType i_FuelType, float i_FuelToAdd)
        {
            if(i_FuelType.Equals(r_FuelType))
            {
                FillEnergy(i_FuelToAdd);
            }
            else
            {
                throw new ArgumentException("Cannot refuel from different fuel type");
            }
        }

        public override string ToString()
        {
            
            return string.Format("The fuel type is {0}. {1}The tank is {2}% full. {1}", r_FuelType, Environment.NewLine,
                m_PrecentageEnergyLeft);
        }
    }
}
