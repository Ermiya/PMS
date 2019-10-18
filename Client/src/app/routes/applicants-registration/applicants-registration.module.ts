import { CreationAuditModule } from './../../shared/comp/creation-audit/creation-audit.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DpDatePickerModule } from 'ng2-jalali-date-picker';

import { ApplicantsRegistrationRoutingModule } from './applicants-registration.routing';
import { ApplicantsRegistrationComponent } from './applicants-registration.component';
import { NzFormModule, NzInputModule, NzSelectModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzGridModule } from 'ng-zorro-antd/grid';

@NgModule({
  declarations: [ApplicantsRegistrationComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NzFormModule,
    NzInputModule,
    NzButtonModule,
    NzGridModule,
    NzSelectModule,
    ApplicantsRegistrationRoutingModule,
    CreationAuditModule,
    DpDatePickerModule
  ],
})
export class ApplicantsRegistrationModule {}
