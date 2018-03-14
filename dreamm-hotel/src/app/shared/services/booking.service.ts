import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Rooms } from "../models/rooms";
import "rxjs/add/operator/map";

@Injectable()
export class BookingService {

  roomType: Rooms[];

  constructor(private http: HttpClient) {
  }

  url = 'http://localhost:60361/';

  getRoomsData() {
    const getRooms = 'api/reservation/rooms';
    return this.http.get<Rooms[]>(this.url+getRooms)
      .map(data => {
        console.log(data);
        this.roomType = data;
        return data;
      });
  }

}
