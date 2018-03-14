import {Rooms} from "./rooms";

export class BookingReservation {
  constructor(public id: number,
              public checkIn: Date,
              public checkOut: Date,
              public numberOfPersons: number,
              public room: Rooms) {}
}
