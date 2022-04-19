using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInformation
    {
        public enum eVehicleStatus
        {
            Reparing = 1,
            Repaired = 2, 
            Payed = 3
        }

        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private readonly Vehicle r_Vehicle;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.Reparing;

        public VehicleInformation(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            r_Vehicle = i_Vehicle;
        }

        public eVehicleStatus VehicleStatus
        {
            set
            {
                m_VehicleStatus = value;
            }
            get
            {
                
                return m_VehicleStatus;
            }
        }

        public string OwnerName
        {
            get
            {
                
                return r_OwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                
                return r_OwnerPhoneNumber;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                
                return r_Vehicle;
            }
        }
        public override string ToString()
        {
            
            return string.Format(
@"The owner name is {0}.
The owner phone number is {1}.
The vehicle status is - {2}
The vehicle information is:
{3}", r_OwnerName, r_OwnerPhoneNumber, m_VehicleStatus, r_Vehicle.ToString());
        }
    }
}
