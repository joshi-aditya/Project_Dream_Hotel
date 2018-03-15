import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Rooms } from '../models/rooms';
import 'rxjs/add/operator/map';
import { BookingReservation } from '../models/bookingReservation';
import { Observable } from 'rxjs/Observable';

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

  bookRoom() {
    const bookingLink = 'api/reservation/bookingreservation';
    const body = JSON.stringify(this.bookingReservation);
    const headers = new HttpHeaders({'Content-Type': 'application/json'});
    return this.http.post(this.url + bookingLink, body, {headers: headers})
      .map(result => {
        console.log(result);
        return result;
      });
  }

}
