import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateAnnouncementComponent } from './pages/announcement/create-announcement/create-announcement.component';
import { EditAnnouncementComponent } from './pages/announcement/edit-announcement/edit-announcement.component';
import { AnnouncementComponent } from './pages/announcement/announcement.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CreateAnnouncementComponent,
    EditAnnouncementComponent,
    AnnouncementComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
