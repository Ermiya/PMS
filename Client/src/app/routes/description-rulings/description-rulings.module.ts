import { CreationAuditModule } from '../../shared/comp/creation-audit/creation-audit.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DescriptionRulingsRoutingModule } from './description-rulings.routing';
import { DescriptionRulingsComponent } from './description-rulings.component';
import {
  NzFormModule,
  NzInputModule,
  NzTableModule,
  NzCollapseModule,
  NzCheckboxModule,
  NzPopconfirmModule,
  NzIconModule,
  NzUploadModule,
} from 'ng-zorro-antd';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { HighlightModule } from '@shared/pipes/highlight.module';

@NgModule({
  declarations: [DescriptionRulingsComponent],
  imports: [
    CommonModule,
    DescriptionRulingsRoutingModule,
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
  ],
})
export class DescriptionRulingsModule {}
