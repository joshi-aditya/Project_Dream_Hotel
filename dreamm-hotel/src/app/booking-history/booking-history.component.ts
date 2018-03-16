import { Component, OnInit } from '@angular/core';
import { BookingService } from '../shared/services/booking.service';
import { BookingReservation } from '../shared/models/bookingReservation';

@Component({
  selector: 'app-booking-history',
  templateUrl: './booking-history.component.html',
  styleUrls: ['./booking-history.component.scss']
})
export class BookingHistoryComponent implements OnInit {

  bookingData: BookingReservation[];
  constructor(private bookingService: BookingService) { }

  ngOnInit() {
    this.bookingService.getBookingData().subscribe( _ => {
      this.bookingData = _;
      console.log(this.bookingData);
    });
  }

}
