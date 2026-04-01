using System;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;

namespace CarProject_ClientSide
{
    internal class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7071/api/CarProject/");

            await GetAllCars();

            await GetCarById(2);

            await AddCar(new clsCar { CarID = 0, CarName = "Ferrari", CarModel = "Aventador", CarColor = "Black" });

            await GetAllCars();

            await UpdateCar(2, new clsCar { CarID = 2, CarName = "Toyota", CarModel = "Supra", CarColor = "Blue" });

            await GetAllCars();

            await DeleteCar(6);

            await GetAllCars();

        }

        static async Task GetAllCars()
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nFetching all Cars...\n");
                var response = await httpClient.GetAsync("EndPointForGettingAllCars");

                if (response.IsSuccessStatusCode)
                {
                    var cars = await response.Content.ReadFromJsonAsync<List<clsCar>>();
                    if (cars != null && cars.Count > 0)
                    {
                        foreach (var car in cars)
                        {
                            Console.WriteLine($"ID: {car.CarID}, Name: {car.CarName}, Model: {car.CarModel}, Color: {car.CarColor}");
                        }
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("No Cars found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task GetCarById(int id)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nFetching Car With ID {id}...\n");

                var response = await httpClient.GetAsync($"EndPointForGettingACarBy{id}");

                if (response.IsSuccessStatusCode)
                {
                    var car = await response.Content.ReadFromJsonAsync<clsCar>();
                    if (car != null)
                    {
                        Console.WriteLine($"ID: {car.CarID}, Name: {car.CarName}, Model: {car.CarModel}, Color: {car.CarColor}");
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine($"Bad Request: Not accepted ID {id}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Not Found: Car with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task AddCar(clsCar newCar)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine("\nAdding a new car...\n");

                var response = await httpClient.PostAsJsonAsync("EndPointForAddingANewCar", newCar);

                if (response.IsSuccessStatusCode)
                {
                    var addedCar = await response.Content.ReadFromJsonAsync<clsCar>();
                    Console.WriteLine($"Added Car - ID: {addedCar.CarID}, Name: {addedCar.CarName}, Model: {addedCar.CarModel}, Color: {addedCar.CarColor}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Bad Request: Invalid car data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task DeleteCar(int id)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nDeleting car with ID {id}...\n");
                var response = await httpClient.DeleteAsync($"EndPointForDeletingACarBy{id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Car with ID {id} has been deleted.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine($"Bad Request: Not accepted ID {id}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Not Found: Car with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task UpdateCar(int id, clsCar updatedCar)
        {
            try
            {
                Console.WriteLine("\n_____________________________");
                Console.WriteLine($"\nUpdating car with ID {id}...\n");
                var response = await httpClient.PutAsJsonAsync($"EndPointForUpdatingACarBy{id}", updatedCar);

                if (response.IsSuccessStatusCode)
                {
                    var car = await response.Content.ReadFromJsonAsync<clsCar>();
                    Console.WriteLine($"Updated Car: ID: {car.CarID}, Name: {car.CarName}, Model: {car.CarModel}, Color: {car.CarColor}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Failed to update student: Invalid data.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Student with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
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