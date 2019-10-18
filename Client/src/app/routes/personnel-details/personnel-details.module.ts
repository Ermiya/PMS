import { CreationAuditModule } from '../../shared/comp/creation-audit/creation-audit.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonnelDetailsRoutingModule } from './personnel-details.routing';
import { PersonnelDetailsComponent } from './personnel-details.component';
import {
  NzFormModule,
  NzInputModule,
  NzTableModule,
  NzCollapseModule,
  NzCheckboxModule,
  NzPopconfirmModule,
  NzIconModule,
  NzUploadModule,
  NzSelectModule,
} from 'ng-zorro-antd';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { HighlightModule } from '@shared/pipes/highlight.module';
import { DpDatePickerModule } from 'ng2-jalali-date-picker';

@NgModule({
  declarations: [PersonnelDetailsComponent],
  imports: [
    CommonModule,
    PersonnelDetailsRoutingModule,
    HighlightModule,
    FormsModule,
    Ng2SearchPipeModule,
    CreationAuditModule,
    ReactiveFormsModule,
    NzFormModule,
    NzUploadModule,
    NzIconModule,
    NzGridModule,
    NzTableModule,
    NzButtonModule,
    NzInputModule,
    NzPopconfirmModule,
    NzCheckboxModule,
    NzCollapseModule,
    NzSelectModule,
    DpDatePickerModule
  ],
})
export class PersonnelDetailsModule {}
