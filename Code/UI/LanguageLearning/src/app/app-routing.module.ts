import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { StudyComponent } from './study/study.component';

const routes: Routes = [
  {path:'study',component:StudyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
