import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { userGuard } from './guards/user.guard';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {path:'',component: HomeComponent},
  {path:'',
    runGuardsAndResolvers: 'always',
    canActivate: [userGuard],
    children: [
      {path:'dashboard',component: DashboardComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
