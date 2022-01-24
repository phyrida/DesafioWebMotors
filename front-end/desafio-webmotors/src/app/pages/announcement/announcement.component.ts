import { Component, OnInit } from '@angular/core';
import { AnnouncementModel } from 'src/app/model/announcement.model';
import { DesafioServiceService } from 'src/app/services/desafio/desafio-service.service';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.css']
})
export class AnnouncementComponent implements OnInit {

  listAnnouncement: AnnouncementModel[] = []

  constructor(private desafioServiceService: DesafioServiceService) { }

  loadRegister(){
    this.desafioServiceService.getAnnouncement()
    .then(
      (response) => {
        this.listAnnouncement = response;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  ngOnInit(): void {
    this.loadRegister();
  }

  delete(id:any){
    if(confirm('deseja excluir esse registro?')){
      this.desafioServiceService.delete(id)
      .then(
        (data)=>{
          this.loadRegister();
          alert('Registro excluido com sucesso');
        }
      )
    }
  }
}
