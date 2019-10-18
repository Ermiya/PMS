import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { TitleService } from '@delon/theme';

@Component({
  selector: 'app-monthly-functionality',
  templateUrl: './monthly-functionality.component.html',
  styleUrls: ['./monthly-functionality.component.less'],
})
export class MonthlyFunctionalityComponent implements OnInit {
  selectedRow: any;
  functionalities: any[] = [];

  editCache: { [key: string]: any } = {};
  editCacheDetails: { [key: string]: any } = {};
  isVisibleTop = false;
  isVisibleMiddle = false;
  isVisible = false;

  constructor(private msg: NzMessageService) {}
  handleChange({ file, fileList }: { [key: string]: any }): void {
    const status = file.status;
    if (status !== 'uploading') {
      console.log(file, fileList);
    }
    if (status === 'done') {
      this.msg.success(`${file.name} file uploaded successfully.`);
    } else if (status === 'error') {
      this.msg.error(`${file.name} file upload failed.`);
    }
  }
  showUploadModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    console.log('Button ok clicked!');
    this.isVisible = false;
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
  }

  startEdit(id: string): void {
    this.editCache[id].edit = true;
  }

  cancelEdit(id: string): void {
    const index = this.functionalities.findIndex(item => item.id === id);
    this.editCache[id] = {
      data: { ...this.functionalities[index] },
      edit: false,
    };
  }

  saveEdit(id: string): void {
    const index = this.functionalities.findIndex(item => item.id === id);
    Object.assign(this.functionalities[index], this.editCache[id].data);
    this.editCache[id].edit = false;
  }

  updateEditCache(): void {
    this.functionalities.forEach(item => {
      this.editCache[item.id] = {
        edit: false,
        data: { ...item },
      };
    });
  }
  startEditDetails(data: any): void {
    console.log(this.editCacheDetails);

    this.editCacheDetails[data.id] = { edit: true, data };
  }

  cancelEditDetails(id: string): void {
    const index = this.selectedRow.items.findIndex(item => item.id === id);
    this.editCacheDetails[id] = {
      data: { ...this.selectedRow.items[index] },
      edit: false,
    };
  }

  saveEditDetails(id: string): void {
    const index = this.selectedRow.items.findIndex(item => item.id === id);
    Object.assign(this.selectedRow.items[index], this.editCacheDetails[id].data);
    this.editCacheDetails[id].edit = false;
  }

  updateEditCacheDetails(): void {
    if (this.selectedRow) {
      this.selectedRow.items.forEach(item => {
        this.editCacheDetails[item.id] = {
          edit: false,
          data: { ...item },
        };
      });
    }
  }

  ngOnInit(): void {
    const types = ['اصلاحی', 'اصلی']
    const funcs = ['کارکرد عادی', 'اضافه کاری', 'غیبت', 'مرخصی استحقاقی', 'مرخصی استعلاجی', 'تاخیر'];
    for (let i = 0, f_length = Math.floor(Math.random() * 100) % 30; i < f_length; i++) {
      let functionality = {
        id: `${i}`,
        serial: Math.round(Math.random() * 1000),
        fullname: `سید امیر مهدوی`,
        type: types[Math.floor(Math.random() * 10) % types.length],
        status: `فعال`,
        year: `139${i}`,
        month: 'بهمن',
        yearedit: `139${i + 2}`,
        monthedit: 'شهریور',
        personnel: Math.round(Math.random() * 100000),
        items: [],
      };
      for (let j = 0, i_length = Math.floor(Math.random() * 10); j < i_length; j++) {
        functionality.items.push({
          id: `${i * 10 + j}`,
          title: funcs[Math.floor(Math.random() * 10) % funcs.length],
          minute: Math.floor(Math.random() * 100)% 60,
          hour: Math.floor(Math.random() * 100),
        });
      }
      this.functionalities.push(functionality);
    }
    this.updateEditCache();
    this.updateEditCacheDetails();
  }
  addRow(): void {
    this.functionalities = [
      {
        id: `1`,
        fullname: `test`,
        type: `اصلی`,
        status: `فعال`,
        year: `1391`,
        month: 'بهمن',
        yearedit: `1392`,
        monthedit: 'شهریور',
        personnel: '12387-12836',
      },
      ...this.functionalities,
    ];
  }

  showModalTop(): void {
    this.isVisibleTop = true;
  }

  showModalMiddle(): void {
    this.isVisibleMiddle = true;
  }

  handleOkTop(): void {
    this.isVisibleTop = false;
  }

  handleCancelTop(): void {
    this.isVisibleTop = false;
  }

  handleOkMiddle(): void {
    this.isVisibleMiddle = false;
  }

  handleCancelMiddle(): void {
    this.isVisibleMiddle = false;
  }
}
