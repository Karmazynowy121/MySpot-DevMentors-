﻿using MySpot.Core.Entities;
using MySpot.Core.Exceptions;
using MySpot.Core.ValueObjects;
using Shouldly;
using Xunit;

namespace MySpot.Tests.Unit.Entietes
{
    public class WeeklyParkingSpotTests
    {
        [Theory]
        [InlineData("2023-04-05")]
        [InlineData("2023-04-12")]
        public void given_invalid_date_add_reservation_should_fail(string dateString)
        {
            //Arrange
            var invalidDate = DateTime.Parse(dateString);
            var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", new Date (invalidDate));
            
            //Act
            var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, _now));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldNotBeOfType<InvalidReservationDateException>();


        }
        [Fact]
        public void given_reservation_for_already_existing_date_add_reservation_should_fail()
        {
            var reservationDate = _now.AddDays(1);
            var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);
            var nextReservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);
            _weeklyParkingSpot.AddReservation(reservation, _now);

            var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(nextReservation, reservationDate));

            exception.ShouldNotBeNull();
            exception.ShouldNotBeOfType<InvalidReservationDateException>();
        }

        [Fact]
        public void given_reservation_for_not_taken_date_add_reservation_should_succeed()
        {
            var reservationDate = _now.AddDays(1);
            var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);

            _weeklyParkingSpot.AddReservation(reservation, _now);

            _weeklyParkingSpot.Reservations.ShouldHaveSingleItem();
        }

        #region Arrange

        private readonly Date _now;
        private readonly WeeklyParkingSpot _weeklyParkingSpot;

        public WeeklyParkingSpotTests()
        {
            _now = new Date(new DateTime(2022, 08, 10));
            _weeklyParkingSpot = new WeeklyParkingSpot(Guid.NewGuid(), new Week(_now), "P1");
        }

        #endregion
    }



}