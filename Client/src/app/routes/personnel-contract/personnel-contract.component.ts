import { Component, OnInit } from '@angular/core';
import { ConstantsService } from 'src/app/services/constants.service';

@Component({
  selector: 'app-personnel-contract',
  templateUrl: './personnel-contract.component.html',
  styleUrls: ['./personnel-contract.component.less']
})
export class PersonnelContractComponent implements OnInit {
  editCache: { [key: string]: any } = {};
  contracts: any[] = [];
  selectedContract: any;
  selectedRull: any;

  panels: any = {
    contract: {active: true},
    rull: {active: true},
    rullItem: {active: true},
  }

  rullPriceModal: boolean = false;

  get constants(): any { return this.constantsService.constrants; }

  constructor(private constantsService: ConstantsService) { }

  ngOnInit() {
    for (let i = 0, c_length = Math.round(Math.random()*100); i < c_length; i++) {
      let contract = {
        id: `${i}`,
        serial: Math.round(Math.random()*1000),
        employementDescription: `شرح استخدام`,
        type: 'ساعتی',
        startTime: '1398/07/08',
        endTime: '1398/07/08',
        maxWork: Math.round(Math.random()*10)+170,
        status: (Math.floor(Math.random()*10)%2 == 0 ? 'ابطال شده' : 'پایان یافته'),
        rulls: []
      };
      for (let j = 0, r_length = Math.round(Math.random()*10); j < r_length; j++) {
        let rull = {
          id: `${j}`,
          serial: Math.round(Math.random()*1000),
          status: `اجرا شده`,
          date: `1398/07/08`,
          items: []
        };
        for (let k = 0, i_length = Math.round(Math.random()*10); k < i_length; k++) {
          let item = {
            id: `${k}`,
            serial: Math.round(Math.random()*1000),
            reason: `علت صدور حکم`,
            amount: Math.round(Math.random()*100000),
          };
          rull.items.push(item);
        }
        contract.rulls.push(rull);
      }
      this.contracts.push(contract);
    }
    this.updateEditCache();
  }

  updateEditCache(): void {
    this.contracts.forEach(item => {
      this.editCache[item.id] = {
        edit: false,
        data: { ...item },
      };
    });
  }
  rullPrice(data: any)
  {
    this.rullPriceModal = true;
    this.selectedRull = data;
  }
  rullPriceCancel() {
    this.rullPriceModal = false;
  }
}
