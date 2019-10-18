import { CreationAuditModule } from '@shared/comp/creation-audit/creation-audit.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MonthlyFunctionalityRoutingModule } from './monthly-functionality.routing';
import { MonthlyFunctionalityComponent } from './monthly-functionality.component';
import { NzTableModule } from 'ng-zorro-antd/table';
import { FormsModule } from '@angular/forms';
import { NzInputModule, NzButtonModule, NzIconModule, NzPopconfirmModule } from 'ng-zorro-antd';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzUploadModule } from 'ng-zorro-antd/upload';

@NgModule({
  declarations: [MonthlyFunctionalityComponent],
  imports: [
    CommonModule,
    MonthlyFunctionalityRoutingModule,
    FormsModule,
    CreationAuditModule,
    NzTableModule,
    NzInputModule,
    NzModalModule,
    NzButtonModule,
    NzUploadModule,
    NzIconModule,
    NzPopconfirmModule,
  ],
})
export class MonthlyFunctionalityModule {}
