using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerForAPICars
{
    public class clsCarDTO
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }

        public clsCarDTO(int carID, string carName, string carModel, string carColor)
        {
            CarID = carID;
            CarName = carName;
            CarModel = carModel;
            CarColor = carColor;
        }
        public clsCarDTO(){}
    }
}
