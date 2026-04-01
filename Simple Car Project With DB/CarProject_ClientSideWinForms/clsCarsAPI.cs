using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_ClientSideForm
{
    public class clsCarsAPI
    {
        static readonly HttpClient httpClient = new HttpClient();
        
        static clsCarsAPI()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7071/api/CarProject/");
        }

        public static async Task<DataTable> GetAllDataOfCars()
        {
            DataTable dataCars = new DataTable();
            try
            {
                var response = await httpClient.GetAsync("EndPointForGettingAllCars");

                if (response.IsSuccessStatusCode)
                {
                    var cars = await response.Content.ReadFromJsonAsync<List<clsCar>>();
                    if (cars != null && cars.Count > 0)
                    {
                        dataCars.Columns.Add("CarID", typeof(string));
                        dataCars.Columns.Add("CarName", typeof(string));
                        dataCars.Columns.Add("CarModel", typeof(string));
                        dataCars.Columns.Add("CarColor", typeof(string));

                        foreach (var car in cars)
                        {
                            dataCars.Rows.Add(car.CarID,car.CarName, car.CarModel, car.CarColor);
                        }
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("No Car Found", "Cars", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dataCars;
        }

        public static async Task<clsCar> GetCarById(int id)
        {
            clsCar car = new clsCar();
            try
            {
                var response = await httpClient.GetAsync($"EndPointForGettingACarBy{id}");

                if (response.IsSuccessStatusCode)
                {
                    car = await response.Content.ReadFromJsonAsync<clsCar>();
                    
                    return car;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show($"Not accepted ID {id}", "Bad Request", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show($"Car with ID {id} not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return null;
        }

        public static async Task<int> AddCar(clsCar newCar)
        {
            int addedCarID = 0;
            try
            {
                var response = await httpClient.PostAsJsonAsync("EndPointForAddingANewCar", newCar);

                if (response.IsSuccessStatusCode)
                {
                    var addedCar = await response.Content.ReadFromJsonAsync<clsCar>();
                    addedCarID = addedCar.CarID;
                    MessageBox.Show($"ID: {addedCar.CarID}, Name: {addedCar.CarName}, Model: {addedCar.CarModel}, Color: {addedCar.CarColor}", $"Added Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Failed to add car Invalid car data", "Bad Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return addedCarID;
        }

        public static async Task DeleteCar(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"EndPointForDeletingACarBy{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Car with ID {id} has been deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show($"Not accepted ID {id}", "Bad Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show($"Car with ID {id} not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static async Task UpdateCar(int id, clsCar updatedCar)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"EndPointForUpdatingACarBy{id}", updatedCar);

                if (response.IsSuccessStatusCode)
                {
                    var car = await response.Content.ReadFromJsonAsync<clsCar>();
                    MessageBox.Show($"ID: {car.CarID}, Name: {car.CarName}, Model: {car.CarModel}, Color: {car.CarColor}", $"Updated Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Failed to update car Invalid data", "Bad Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show($"Car with ID {id} not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    public class clsCar
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
    }
}
