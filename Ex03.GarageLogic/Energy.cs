using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        protected float m_CurrentEnergy = 0;
        protected readonly float r_MaxEnergy;
        protected float m_PrecentageEnergyLeft = 0f;

        public Energy(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
        }

        public void FillEnergy(float i_EnergyToAdd)
        {
            if(m_CurrentEnergy + i_EnergyToAdd <= r_MaxEnergy)
            {
                m_CurrentEnergy += i_EnergyToAdd;
                m_PrecentageEnergyLeft = (m_CurrentEnergy / r_MaxEnergy) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxEnergy, 0);
            }
        }
    }
}
