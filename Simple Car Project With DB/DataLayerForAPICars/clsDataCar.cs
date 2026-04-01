using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using System.Numerics;

namespace DataLayerForAPICars
{
    public class clsDataCar
    {
        static string _connectionToDB = "Server=.;Database=CarsDB;User Id=sa;Password=123456;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
        static SqlConnection connection = new SqlConnection(_connectionToDB);

        public static List<clsCarDTO> GetAllCars()
        {
            var CarsList = new List<clsCarDTO>();

            string SP_GetAllCars = "SP_GetAllCars";

            SqlCommand command = new SqlCommand(SP_GetAllCars, connection);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int CarID = (int)reader["CarID"];
                    string CarName = (string)reader["CarName"];
                    string CarModel = (string)reader["CarModel"];
                    string CarColor = (string)reader["CarColor"];

                    CarsList.Add(new clsCarDTO(CarID, CarName, CarModel, CarColor));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :( " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return CarsList;
        }

        public static clsCarDTO GetCarByID(int CarForID)
        {
            clsCarDTO carDTO = new clsCarDTO();

            string SP_GetCarByID = "SP_GetCarByID";

            SqlCommand command = new SqlCommand(SP_GetCarByID, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CarID", CarForID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int CarID = (int)reader["CarID"];
                    string CarName = (string)reader["CarName"];
                    string CarModel = (string)reader["CarModel"];
                    string CarColor = (string)reader["CarColor"];
                    carDTO = new clsCarDTO(CarID, CarName, CarModel, CarColor);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :( " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return carDTO;
        }

        public static int AddNewCar(clsCarDTO carDTO)
        {
            int InsertedID = 0;

            string SP_AddNewCar = "SP_AddNewCar";

            SqlCommand command = new SqlCommand(SP_AddNewCar, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CarName", carDTO.CarName);
            command.Parameters.AddWithValue("@CarModel", carDTO.CarModel);
            command.Parameters.AddWithValue("@CarColor", carDTO.CarColor);

            var outputIdParam = new SqlParameter("@NewCarID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputIdParam);

            try
            {
                connection.Open();

                int rows = command.ExecuteNonQuery();


                if (rows > 0)
                {
                    InsertedID = (int)outputIdParam.Value;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error :( " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return InsertedID;
        }

        public static bool UpdateCar(clsCarDTO carDTO)
        {
            bool isUpdated = false;

            string SP_UpdateCar = "SP_UpdateCar";

            SqlCommand command = new SqlCommand(SP_UpdateCar, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CarID", carDTO.CarID);
            command.Parameters.AddWithValue("@CarName", carDTO.CarName);
            command.Parameters.AddWithValue("@CarModel", carDTO.CarModel);
            command.Parameters.AddWithValue("@CarColor", carDTO.CarColor);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :( " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isUpdated;
        }

        public static bool DeleteCar(int CarForID)
        {
            bool isDeleted = false;

            string SP_DeleteCar = "SP_DeleteCar";

            SqlCommand command = new SqlCommand(SP_DeleteCar, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CarID", CarForID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error :( " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isDeleted;
        }
    }
}
