using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models.DTOs.Reservation;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservationsAsync();
                return Ok(reservations);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected eror occurred.");
            }

        }
        [Authorize]
        [HttpGet]
        [Route("reservation/{id}")]
        public async Task<ActionResult> GetReservationById(int id)
        {
            try
            {
                var reservation = await _reservationService.GetReservationByIdAsync(id);
                return Ok(reservation);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected eror occurred.");
            }

        }

        [HttpPost]
        [Route("createReservation")]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservation)
        {
            try
            {
                await _reservationService.AddReservationAsync(createReservation);

                return Ok(createReservation);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the reservation.");
            }

        }
        [Authorize]
        [HttpPut]
        [Route("updateReservation/{id}")]
        public async Task<IActionResult> UpdateReservation(int id, UpdateReservationDTO updateReservation)
        {
            try
            {
                await _reservationService.UpdateReservationAsync(updateReservation);
                return Ok(updateReservation);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the reservation.");
            }

        }
        [Authorize]
        [HttpDelete]
        [Route("deleteReservation/{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(id);
                return Ok("Reservation deleted!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"No reservation with ID {id} found!");
            }

        }
    }
}
