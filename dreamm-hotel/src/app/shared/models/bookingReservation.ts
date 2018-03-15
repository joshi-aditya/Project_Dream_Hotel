import { Rooms } from './rooms';
import { Person } from './person';

export class BookingReservation {
  constructor(public id: number,
              public checkIn: Date,
              public checkOut: Date,
              public numberOfPersons: number,
              public room: Rooms,
              public persons: Person[]) {
  }
}
