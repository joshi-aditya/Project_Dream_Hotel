import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { BookingService } from '../shared/services/booking.service';
import { Person } from '../shared/models/person';

@Component({
  selector: 'app-guest-details',
  templateUrl: './guest-details.component.html',
  styleUrls: ['./guest-details.component.scss']
})
export class GuestDetailsComponent implements OnInit {

  numberOfPersons: number;
  guestDetails: FormGroup;

  constructor(private bookingService: BookingService) {
  }

  ngOnInit() {
    this.guestDetails = new FormGroup({
      firstName: new FormArray([]),
      lastName: new FormArray([])
    });
    this.numberOfPersons = this.bookingService.bookingReservation.numberOfPersons;
    console.log(this.numberOfPersons);
    this.addControls();
  }

  onSubmit() {
    for (let i = 0; i < this.numberOfPersons; i++) {
      const person = new Person(this.guestDetails.value.firstName[i], this.guestDetails.value.lastName[i]);
      this.bookingService.bookingReservation.persons.push(person);
    }
    console.log(this.bookingService.bookingReservation);
    console.log(this.guestDetails);
  }

  addControls() {
    for (let i = 0; i < this.numberOfPersons; i++) {
      (<FormArray>this.guestDetails.get('firstName')).push(new FormControl(null, Validators.required));
      (<FormArray>this.guestDetails.get('lastName')).push(new FormControl(null, Validators.required));
    }
  }
}
