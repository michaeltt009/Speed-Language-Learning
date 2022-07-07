import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { StudyComponent } from './study/study.component';
import { TrainComponent } from './train/train.component';

const routes: Routes = [
  {path:'study',component:StudyComponent},
  {path:'train',component:TrainComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
