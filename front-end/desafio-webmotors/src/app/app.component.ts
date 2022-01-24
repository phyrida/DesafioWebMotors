import { Component, OnInit } from '@angular/core';
import { AnnouncementModel } from './model/announcement.model';
import { DesafioServiceService } from './services/desafio/desafio-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'desafio-webmotors';
  listAnnouncement: AnnouncementModel[] = []

  constructor(private desafioServiceService: DesafioServiceService) {

  }

  ngOnInit() {

    this.desafioServiceService.getAnnouncement()
    .then(
      (dataResponse: AnnouncementModel[]) => {
        console.log(dataResponse);
        this.listAnnouncement = dataResponse;
      },
      (error) => {
        console.log(error);
      }

    )
  }


}
