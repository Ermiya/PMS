import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SimpleGuard } from '@delon/auth';
import { environment } from '@env/environment';
// layout
import { LayoutDefaultComponent } from '../layout/default/default.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutDefaultComponent,
    children: [
      {
        path: 'applicants-register',
        loadChildren: () =>
          import('./applicants-registration/applicants-registration.module').then(m => m.ApplicantsRegistrationModule),
      },
      {
        path: 'personnel-list',
        loadChildren: () => import('./personnel-list/personnel-list.module').then(m => m.PersonnelListModule),
      },
      {
        path: 'personnel-contract',
        loadChildren: () => import('./personnel-contract/personnel-contract.module').then(m => m.PersonnelContractModule),
      },
      {
        path: 'personnel-details',
        loadChildren: () => import('./personnel-details/personnel-details.module').then(m => m.PersonnelDetailsModule),
      },
      {
        path: 'description-rulling',
        loadChildren: () => import('./description-rulings/description-rulings.module').then(m => m.DescriptionRulingsModule),
      },
      {
        path: 'jobs',
        loadChildren: () => import('./jobs/jobs.module').then(m => m.JobsModule),
      },
      {
        path: 'monthly-functionality',
        loadChildren: () => import('./monthly-functionality/monthly-functionality.module').then(m => m.MonthlyFunctionalityModule),
      },
    ],
  },
  { path: '**', redirectTo: 'exception/404' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      useHash: environment.useHash,
      scrollPositionRestoration: 'top',
    }),
  ],
  exports: [RouterModule],
})
export class RouteRoutingModule {}
