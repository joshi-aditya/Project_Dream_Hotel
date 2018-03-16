import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { BookingService } from '../shared/services/booking.service';
import { Person } from '../shared/models/person';
import { Router } from '@angular/router';

@Component({
  selector: 'app-guest-details',
  templateUrl: './guest-details.component.html',
  styleUrls: ['./guest-details.component.scss']
})
export class GuestDetailsComponent implements OnInit {

  numberOfPersons: number;
  rentAmount: number;
  guestDetails: FormGroup;

  constructor(private bookingService: BookingService, private router: Router) {
  }

  ngOnInit() {
    this.guestDetails = new FormGroup({
      firstName: new FormArray([]),
      lastName: new FormArray([])
    });
    this.numberOfPersons = this.bookingService.bookingReservation.numberOfPersons;
    this.addControls();
    this.getRentAmount();
  }

  onSubmit() {
    for (let i = 0; i < this.numberOfPersons; i++) {
      const person = new Person(this.guestDetails.value.firstName[i], this.guestDetails.value.lastName[i]);
      this.bookingService.bookingReservation.persons.push(person);
    }
    this.bookingService.bookRoom()
      .subscribe(result => {
        this.router.navigateByUrl('/home');
      });
    this.guestDetails.reset();
  }

  getRentAmount() {
    // tslint:disable-next-line:max-line-length
    const timeDiff = Math.abs((new Date(this.bookingService.bookingReservation.checkIn).getTime()) - (new Date(this.bookingService.bookingReservation.checkOut)).getTime());
    this.rentAmount = Math.ceil(timeDiff / (1000 * 3600 * 24)) * this.bookingService.bookingReservation.room.rent;
  }

  addControls() {
    for (let i = 0; i < this.numberOfPersons; i++) {
      (<FormArray>this.guestDetails.get('firstName')).push(new FormControl(null, Validators.required));
      (<FormArray>this.guestDetails.get('lastName')).push(new FormControl(null, Validators.required));
    }
  }
}
