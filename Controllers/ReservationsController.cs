using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        [HttpGet]
        [Route("reservation/{id}")]
        public async Task<ActionResult> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            return Ok(reservation);
        }

        [HttpPost]
        [Route("createReservation")]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservation)
        {
            await _reservationService.AddReservationAsync(createReservation);

            return Ok(createReservation);
        }

        [HttpPut]
        [Route("updateReservation/{id}")]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDTO updateReservation)
        {
            await _reservationService.UpdateReservationAsync(updateReservation);
            return Ok(updateReservation);
        }

        [HttpDelete]
        [Route("deleteReservation/{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return Ok("Reservation deleted!");
        }
    }
}
