import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MakeModel } from 'src/app/model/make.model';
import { ModelModel } from 'src/app/model/model.model';
import { VersionModel } from 'src/app/model/version.model';
import { VehicleModel } from 'src/app/model/vehicle.model';
import { AnnouncementModel } from 'src/app/model/announcement.model';

@Injectable({
  providedIn: 'root'
})
export class DesafioServiceService {

  constructor(private http: HttpClient) {

  }

  getMaker():Promise<MakeModel[]>{
    return new Promise<MakeModel[]>((resolve, reject) => {
      this.http
        .get<MakeModel[]>(environment.urlApi + '/DesafioOnline/make')
        .subscribe(
          (data: MakeModel[]) => {
            resolve(data);
          },
          (error: any) => {
            reject(error);
          }
        );
    });
  }

  getModel(makeId:number):Promise<ModelModel[]>{
    return new Promise<ModelModel[]>((resolve, reject) => {
      this.http
        .get<ModelModel[]>(environment.urlApi + '/DesafioOnline/model?MakeID=' +  makeId)
        .subscribe(
          (data: ModelModel[]) => {
            resolve(data);
          },
          (error: any) => {
            reject(error);
          }
        );
    });
  }

  getVersion(modelId:number):Promise<VersionModel[]>{
    return new Promise<VersionModel[]>((resolve, reject) => {
      this.http
        .get<VersionModel[]>(environment.urlApi + '/DesafioOnline/version')
        .subscribe(
          (data: VersionModel[]) => {
            resolve(data);
          },
          (error: any) => {
            reject(error);
          }
        );
    });
  }

  getVehicle(page:number):Promise<VehicleModel[]>{
    return new Promise<VehicleModel[]>((resolve, reject) => {
      this.http
        .get<VehicleModel[]>(environment.urlApi + '/DesafioOnline/vehicle')
        .subscribe(
          (data: VehicleModel[]) => {
            resolve(data);
          },
          (error: any) => {
            reject(error);
          }
        );
    });
  }

  getAnnouncement(): Promise<AnnouncementModel[]>{
    return new Promise<AnnouncementModel[]>((resolve, reject) => {
      this.http
        .get<AnnouncementModel[]>(environment.urlApi + '/AnuncioWebmotors')
        .subscribe(
          (data: AnnouncementModel[]) => {
            resolve(data);
          },
          (error: any) => {
            reject(error);
          }
        );
    });
  }

  getAnnouncementById(id:number){
    return new Promise<AnnouncementModel>((resolve, reject) => {
      this.http
        .get<AnnouncementModel>(environment.urlApi + '/AnuncioWebmotors/' + id)
        .subscribe(
          (data: AnnouncementModel) => {
            resolve(data);
          },
          (error: any) => {
            reject(error);
          }
        );
    });
  }

  post(channels: AnnouncementModel): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http
        .post<AnnouncementModel>(
          environment.urlApi + '/AnuncioWebmotors',
          channels
        )
        .subscribe(
          (data: AnnouncementModel) => {
            resolve(data);
          },
          (error) => {
            reject(error);
          }
        );
    });
  }

  put(channels: AnnouncementModel): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http
        .put<AnnouncementModel>(
          environment.urlApi + '/AnuncioWebmotors',
          channels
        )
        .subscribe(
          (data: AnnouncementModel) => {
            resolve(data);
          },
          (error) => {
            reject(error);
          }
        );
    });
  }

  delete(id: number): Promise<any> {
    return new Promise<any>((resolve, reject) => {
      this.http
        .delete<AnnouncementModel>(environment.urlApi + '/AnuncioWebmotors/' + id)
        .subscribe(
          (data: AnnouncementModel) => {
            resolve(data);
          },
          (error: any) => {
            reject(error);
          }
        );
    });
  }

}
