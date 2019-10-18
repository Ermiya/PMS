import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.less'],
})
export class JobsComponent implements OnInit {
  editCache: { [key: string]: any } = {};
  listOfData: any[] = [];

  constructor() {}

  ngOnInit(): void {
    this.listOfData = [
      {
        serial: 23476,
        title: 'حسابدار',
        jobString: 'کارشناس'
      },
      {
        serial: 23456,
        title: 'برنامه نویس ارشد',
        jobString: 'کارشناس ارشد'
      }
    ]
    this.updateEditCache();
  }

  startEdit(id: string): void {
    this.editCache[id].edit = true;
  }

  cancelEdit(id: string): void {
    const index = this.listOfData.findIndex(item => item.id === id);
    this.editCache[id] = {
      data: { ...this.listOfData[index] },
      edit: false,
    };
  }

  saveEdit(id: string): void {
    const index = this.listOfData.findIndex(item => item.id === id);
    Object.assign(this.listOfData[index], this.editCache[id].data);
    this.editCache[id].edit = false;
  }

  updateEditCache(): void {
    this.listOfData.forEach(item => {
      this.editCache[item.id] = {
        edit: false,
        data: { ...item },
      };
    });
  }

  addRow(): void {
    this.listOfData = [
      {
        id: `1`,
        serial: ``,
        insuranceCode: ``,
        title: ``,
        jobString: ``,
        supervision: '',
        active: '',
      },
      ...this.listOfData,
    ];
  }
}
