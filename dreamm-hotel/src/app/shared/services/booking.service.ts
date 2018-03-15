import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Rooms } from '../models/rooms';
import 'rxjs/add/operator/map';
import {BookingReservation} from '../models/bookingReservation';

@Injectable()
export class BookingService {

  bookingReservation: BookingReservation;
  roomType: Rooms[];

  constructor(private http: HttpClient) {
  }

  url = 'http://localhost:60361/';

  getRoomsData() {
    const getRooms = 'api/reservation/rooms';
    return this.http.get<Rooms[]>(this.url + getRooms)
      .map(data => {
        this.roomType = data;
        return data;
      });
  }

}
