import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingService } from '../../shared/services/booking.service';
import { Rooms } from '../../shared/models/rooms';
import { BookingReservation } from '../../shared/models/bookingReservation';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-booking-form',
  templateUrl: './booking-form.component.html',
  styleUrls: ['./booking-form.component.scss']
})
export class BookingFormComponent implements OnInit {
  today: Date = new Date();
  bookingForm: FormGroup;

  constructor(private router: Router, private bookingService: BookingService) {
  }

  roomType: Rooms[];

  ngOnInit() {
    console.log(this.today);
    this.bookingForm = new FormGroup({
      checkInDate: new FormControl(null, Validators.required),
      checkOutDate: new FormControl(null, Validators.required),
      roomType: new FormControl(null, Validators.required),
      numberOfPersons: new FormControl(null, Validators.required)
    });
    this.bookingService.getRoomsData()
      .subscribe(rooms => {
        this.roomType = rooms;
      });

  }

  onSubmit() {
    console.log(this.bookingForm);
    let selectedRoom: Rooms;
    this.roomType.forEach(room => {
      if (this.bookingForm.value.roomType === room.type) {
        selectedRoom = room;
      }
    });
    console.log(selectedRoom);
    const bookingReservation = new BookingReservation(
      this.bookingForm.value.checkInDate,
      this.bookingForm.value.checkOutDate,
      this.bookingForm.value.numberOfPersons,
      selectedRoom,
      []
    );
    this.bookingService.bookingReservation = bookingReservation;
    this.router.navigateByUrl('/bookingdetails');
    // this.bookingForm.reset();
  }

}
