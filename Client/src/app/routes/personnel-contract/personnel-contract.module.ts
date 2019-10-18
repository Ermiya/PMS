import { CreationAuditModule } from '../../shared/comp/creation-audit/creation-audit.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonnelContractRoutingModule } from './personnel-contract.routing';
import { PersonnelContractComponent } from './personnel-contract.component';
import {
  NzFormModule,
  NzInputModule,
  NzTableModule,
  NzCollapseModule,
  NzCheckboxModule,
  NzPopconfirmModule,
  NzIconModule,
  NzUploadModule,
  NzModalModule,
  NzSelectModule,
} from 'ng-zorro-antd';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { HighlightModule } from '@shared/pipes/highlight.module';

@NgModule({
  declarations: [PersonnelContractComponent],
  imports: [
    CommonModule,
    PersonnelContractRoutingModule,
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
    NzModalModule,
    NzSelectModule,
  ],
})
export class PersonnelContractModule {}
