
using DataLayerForAPICars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarProject_ServerSide.Controllers
{
    [Route("api/CarProject")]
    [ApiController]
    public class CarProjectController : ControllerBase
    {

        [HttpGet("EndPointForGettingAllCars")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsCarDTO>> GetAllCars()
        {
            var ListOfAllCars = BusinessLayerForAPICars.clsCar.GetAllCars();

            if (ListOfAllCars.Count == 0)
            {
                return NotFound("No Cars Found!");
            }
            return Ok(ListOfAllCars);
        }


        [HttpGet("EndPointForGettingACarBy{id}", Name = "GetCarById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsCarDTO> GetCarByID(int id)
        {
            if(id < 1)
            {
                return BadRequest($"Invalid Car ID : {id}");
            }
            var car = BusinessLayerForAPICars.clsCar.GetCarByID(id);
            
            if (car == null || car.CarID == 0)
            {
                return NotFound("Car Not Found!");
            }
            return Ok(car.CarDTO);
        }



        [HttpPost("EndPointForAddingANewCar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsCarDTO> AddNewCar(clsCarDTO newCarDTO)
        {
            if(newCarDTO == null || string.IsNullOrEmpty(newCarDTO.CarName) || string.IsNullOrEmpty(newCarDTO.CarModel) || string.IsNullOrEmpty(newCarDTO.CarColor))
            {
                return BadRequest("Invalid car data.");
            }

            var car = new BusinessLayerForAPICars.clsCar(newCarDTO);

            if (car.Save())
            {
                newCarDTO.CarID = car.CarID;
            }

            return CreatedAtAction("GetCarById", new { id = newCarDTO.CarID }, newCarDTO);
        }


        [HttpPut("EndPointForUpdatingACarBy{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsCarDTO> UpdateCar(int id, clsCarDTO newDataCarDTO)
        {
            if (id < 1 || newDataCarDTO == null || string.IsNullOrEmpty(newDataCarDTO.CarName) || string.IsNullOrEmpty(newDataCarDTO.CarModel) || string.IsNullOrEmpty(newDataCarDTO.CarColor))
            {
                return BadRequest("Invalid Data Car");
            }

            var car = BusinessLayerForAPICars.clsCar.GetCarByID(id);

            if (car == null || car.CarID == 0)
            {
                return NotFound("Car Not Found!");
            }

            car.CarName = newDataCarDTO.CarName;
            car.CarModel = newDataCarDTO.CarModel;
            car.CarColor = newDataCarDTO.CarColor;

            car.Save();

            return Ok(car.CarDTO);
        }

        [HttpDelete("EndPointForDeletingACarBy{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCar(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid Car ID : {id}");
            }

            if (BusinessLayerForAPICars.clsCar.DeleteCar(id))

                return Ok($"Student with ID {id} has been deleted.");
            else
                return NotFound($"Student with ID {id} not found. no rows deleted!");

        }

    }
}
