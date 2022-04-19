using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string r_ManufacturerName;
        private float m_CurrentTierPressure;
        private float r_MaximumTierPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentTierPressure, float i_MaximumTierPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_CurrentTierPressure = i_CurrentTierPressure;
            r_MaximumTierPressure = i_MaximumTierPressure;
        }

        public float CurrentTierPressure
        {
            get
            { 
                
                return m_CurrentTierPressure;
            }
        }

        public void FillTierPressure(float i_PressureToAdd)
        {
            if (m_CurrentTierPressure + i_PressureToAdd <= r_MaximumTierPressure)
            {
                m_CurrentTierPressure += i_PressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaximumTierPressure - m_CurrentTierPressure);
            }
        }

        public void FillTierToMax()
        {
            m_CurrentTierPressure = r_MaximumTierPressure;
        }

        public override string ToString()
        {
            
            return string.Format("The manufacturer name is {0}. {1}The current tier pressure is {2}.", r_ManufacturerName , Environment.NewLine, m_CurrentTierPressure);
        }
    }
}
