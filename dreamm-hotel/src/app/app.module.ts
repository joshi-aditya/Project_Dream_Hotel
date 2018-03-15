
import { BookingHistoryComponent } from './booking-history/booking-history.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { InquiryFormComponent } from './footer/inquiry-form/inquiry-form.component';
import { HomepageComponent } from './homepage/homepage.component';
import { BookingFormComponent } from './homepage/booking-form/booking-form.component';
import { GuestDetailsComponent } from './guest-details/guest-details.component';
import { AppRoutingModule } from "./app-routing.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BookingService } from "./shared/services/booking.service";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    InquiryFormComponent,
    HomepageComponent,
    BookingFormComponent,
    GuestDetailsComponent,
    BookingHistoryComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [BookingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
