import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { InquiryFormComponent } from './footer/inquiry-form/inquiry-form.component';
import { HomepageComponent } from './homepage/homepage.component';
import { BookingFormComponent } from './homepage/booking-form/booking-form.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    InquiryFormComponent,
    HomepageComponent,
    BookingFormComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
