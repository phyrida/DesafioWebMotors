import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AnnouncementModel } from 'src/app/model/announcement.model';
import { MakeModel } from 'src/app/model/make.model';
import { ModelModel } from 'src/app/model/model.model';
import { VersionModel } from 'src/app/model/version.model';
import { DesafioServiceService } from 'src/app/services/desafio/desafio-service.service';

@Component({
  selector: 'app-edit-announcement',
  templateUrl: './edit-announcement.component.html',
  styleUrls: ['./edit-announcement.component.css']
})
export class EditAnnouncementComponent implements OnInit {

  listMaker: MakeModel[] = [];
  listModel: ModelModel[] = [];
  listVersion: VersionModel[] = [];

  form!: FormGroup;

  marcaControlValidator = this.fb.control(null, {
    validators: [
      Validators.required
    ]
  })

  modeloControlValidator = this.fb.control(null, {
    validators: [
      Validators.required
    ]
  })

  versaoControlValidator = this.fb.control(null, {
    validators: [
      Validators.required
    ]
  })

  anoControlValidator = this.fb.control(null, {
    validators: [
      Validators.required
    ]
  })

  kmControlValidator = this.fb.control(null, {
    validators: [
      Validators.required
    ]
  })

  obsControlValidator = this.fb.control(null, {
    validators: [
      Validators.required
    ]
  })

  marca?: number;
  modelo?: number;
  versao?: number;
  id?: number;

  currentMake?:string;
  currentModel?:string;
  currentVersion?:string;

  constructor(private desafioServiceService: DesafioServiceService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) {
    this.form = this.fb.group({
      obsControlValidator: this.obsControlValidator,
      kmControlValidator: this.kmControlValidator,
      anoControlValidator: this.anoControlValidator,
      marcaControlValidator: this.marcaControlValidator,
      modeloControlValidator: this.modeloControlValidator,
      versaoControlValidator: this.versaoControlValidator,
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.desafioServiceService.getAnnouncementById(this.route.snapshot.params['id'])
      .then(
        (data) => {
          this.desafioServiceService.getMaker()
            .then(
              (response) => {
                this.listMaker = response;
              },
              (err) => {
                console.log(err);
              }
            );

          this.obsControlValidator.setValue(data.observacao);
          this.kmControlValidator.setValue(data.quilometragem);
          this.anoControlValidator.setValue(data.ano);

          this.currentMake = data.marca;
          this.currentModel = data.modelo;
          this.currentVersion = data.versao;

        }
      )
  }

  loadModel(ele: any) {
    this.desafioServiceService.getModel(<number>ele.target.value).then(
      (data) => {
        this.marca = ele.target.value;
        this.listModel = data;
        this.listVersion = []
      }
    )
  }

  loadVersion(ele: any) {
    this.desafioServiceService.getVersion(<number>ele.target.value).then(
      (data) => {
        this.modelo = ele.target.value;
        this.listVersion = data;
      }
    )
  }

  selectVersion(ele: any) {
    this.versao = ele.target.value;
  }

  update() {
    if (this.form.valid) {
      var annuncement = new AnnouncementModel();

      annuncement.marca = this.listMaker.filter((e) => { return e.id == this.marca })[0].name;
      annuncement.modelo = this.listModel.filter((e) => { return e.id == this.modelo })[0].name;
      annuncement.versao = this.listVersion.filter((e) => { return e.id == this.versao })[0].name;
      annuncement.ano = this.anoControlValidator.value;
      annuncement.quilometragem = this.kmControlValidator.value;
      annuncement.observacao = this.obsControlValidator.value;
      annuncement.id = this.id;

      this.desafioServiceService.put(annuncement)
        .then(
          (data) => {
            console.log('ok');
            this.router.navigate(['/annoucement']);
          }
        )
    }
  }
}
