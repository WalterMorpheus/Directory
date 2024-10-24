import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { userGuard } from './guards/user.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BusinessAreaComponent } from './business-area/business-area.component';
import { PersonComponent } from './person/person.component';

const routes: Routes = [
  {path:'',component: HomeComponent},
  {path:'',
    runGuardsAndResolvers: 'always',
    canActivate: [userGuard],
    children: [
      {path:'dashboard',component: DashboardComponent},
      {path:'business-areas',component: BusinessAreaComponent},
      {path:'person',component: PersonComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
