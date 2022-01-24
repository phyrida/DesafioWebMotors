import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnnouncementComponent } from './pages/announcement/announcement.component';
import { CreateAnnouncementComponent } from './pages/announcement/create-announcement/create-announcement.component';
import { EditAnnouncementComponent } from './pages/announcement/edit-announcement/edit-announcement.component';

const routes: Routes = [
  { path: '', redirectTo: '/annoucement', pathMatch: 'full' },
  { path: 'annoucement', component: AnnouncementComponent },
  { path: 'annoucement/create', component: CreateAnnouncementComponent },
  { path: 'annoucement/:id', component: EditAnnouncementComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
