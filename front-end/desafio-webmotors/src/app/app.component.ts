import { Component, OnInit } from '@angular/core';
import { AnnouncementModel } from './model/announcement.model';
import { DesafioServiceService } from './services/desafio/desafio-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'desafio-webmotors';


  constructor() {

  }

}
