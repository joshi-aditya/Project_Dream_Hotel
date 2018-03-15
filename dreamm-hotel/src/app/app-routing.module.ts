import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { GuestDetailsComponent } from './guest-details/guest-details.component';
import { BookingHistoryComponent } from './booking-history/booking-history.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomepageComponent
  },
  {
    path: 'bookingdetails',
    component: GuestDetailsComponent
  },
  {
    path : 'bookinghistory',
    component : BookingHistoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
