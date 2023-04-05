﻿using Microsoft.AspNetCore.Mvc;
using MySpot.Application.Commands;
using MySpot.Application.Services;
using MySpot.Core.Entities;

namespace MySpot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ControllerBase
    {


        private readonly IReservationsService _reservationsService;
        public ReservationsController(IReservationsService reservationsService)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get() 
            => Ok(_reservationsService.GetAllWeeklyAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Reservation>> Get(Guid id)
        {
            var reservation = await _reservationsService.GetAsync(id);
            if (reservation is null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost]
        public async Task <ActionResult> Post(CreateReservation command)
        {
            var id = await _reservationsService.CreateAsync(command with { ReservationId = Guid.NewGuid() });
            if (id is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, ChangeReservationLicensePlate command)
        {

            if (await _reservationsService.UpdateAsync(command with { ReservationId = id }))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _reservationsService.DeleteAsync(new DeleteReservation(id)))
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}