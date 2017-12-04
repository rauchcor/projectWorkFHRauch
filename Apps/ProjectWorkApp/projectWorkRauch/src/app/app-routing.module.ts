import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { CarsComponent } from "./components/cars/cars.component";

const routes: Routes = [
  {
    path: '',
    redirectTo: 'cars',
    pathMatch: 'full',
  },
  {
    path: 'cars',
    component: CarsComponent
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
