 using DataLayerForAPICars;

namespace BusinessLayerForAPICars
{
    public class clsCar
    {
        public enum enMode { AddNewCar = 1, UpdateCar = 2 }

        public int CarID { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        enMode Mode = enMode.AddNewCar;

        public clsCarDTO CarDTO
        {
            get { return (new clsCarDTO(this.CarID, this.CarName, this.CarModel, this.CarColor)); }
        }

        public clsCar(clsCarDTO carDTO, enMode mode = enMode.AddNewCar)
        {
            CarID = carDTO.CarID;
            CarName = carDTO.CarName;
            CarModel = carDTO.CarModel;
            CarColor = carDTO.CarColor;
            Mode = mode;
        }

        public static List<clsCarDTO> GetAllCars()
        {
            return clsDataCar.GetAllCars();
        }

        public static clsCar GetCarByID(int carID)
        {
            clsCarDTO carDTO = clsDataCar.GetCarByID(carID);

            if (carDTO != null)
            {

                return new clsCar(carDTO, enMode.UpdateCar);
            }
            else
                return null;
        }

        bool _AddNewCar()
        {
            this.CarID = clsDataCar.AddNewCar(CarDTO);
            return (this.CarID != -1);
        }

        bool _UpdateCar()
        {
            return clsDataCar.UpdateCar(CarDTO);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNewCar:
                    if (_AddNewCar())
                    {
                        Mode = enMode.UpdateCar;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.UpdateCar:

                    return _UpdateCar();

            }

            return false;
        }

        public static bool DeleteCar(int carID)
        {
            return clsDataCar.DeleteCar(carID);
        }
    }
}
