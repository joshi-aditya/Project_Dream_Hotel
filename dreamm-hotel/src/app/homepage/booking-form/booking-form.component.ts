import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { BookingService } from "../../shared/services/booking.service";
import { Rooms } from "../../shared/models/rooms";

@Component({
  selector: 'app-booking-form',
  templateUrl: './booking-form.component.html',
  styleUrls: ['./booking-form.component.scss']
})
export class BookingFormComponent implements OnInit {

  bookingForm: FormGroup;
  constructor(private router: Router, private bookingService: BookingService) { }

  roomType: Rooms[];

  ngOnInit() {
    this.bookingForm = new FormGroup({
      checkInDate: new FormControl(null, Validators.required),
      checkOutDate: new FormControl(null, Validators.required),
      roomType: new FormControl(null, Validators.required),
      numberOfPersons: new FormControl(null, Validators.required)
    });
    this.bookingService.getRoomsData()
      .subscribe(rooms => {
        this.roomType = rooms;
        console.log(this.roomType);
      });

  }

  onSubmit() {
    this.router.navigateByUrl('/bookingdetails');
    this.bookingForm.reset();
  }

}
