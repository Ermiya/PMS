import { NzMessageService, UploadFile } from 'ng-zorro-antd';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Observable, Observer } from 'rxjs';
import { ConstantsService } from 'src/app/services/constants.service';

@Component({
  selector: 'app-personnel-details',
  templateUrl: './personnel-details.component.html',
  styleUrls: ['./personnel-details.component.less'],
})
export class PersonnelDetailsComponent implements OnInit {
  inputValue: string;
  loading = false;
  avatarUrl: string;
  Martyr = false;
  MartyrFamily = false;
  editCache: { [key: string]: any } = {};
  listOfData: any[] = [];
  panels = [
    {
      active: true,
      disabled: false,
      name: 'مشخصات فردی',
      customStyle: {
        background: '#f7f7f7',
        'border-radius': '4px',
        'margin-bottom': '24px',
        border: '0px',
      },
    },
    {
      active: false,
      disabled: true,
      name: 'وضعیت تحصیلی',
      customStyle: {
        background: '#f7f7f7',
        'border-radius': '4px',
        'margin-bottom': '24px',
        border: '0px',
      },
    },
    {
      active: false,
      disabled: false,
      name: 'سابقه کار',
      customStyle: {
        background: '#f7f7f7',
        'border-radius': '4px',
        'margin-bottom': '24px',
        border: '0px',
      },
    },
    {
      active: false,
      disabled: false,
      name: 'تحت تکفل',
      customStyle: {
        background: '#f7f7f7',
        'border-radius': '4px',
        'margin-bottom': '24px',
        border: '0px',
      },
    },
  ];
  jobs: any[] = [
    {
      title: 'کارشناس حسابداری',
      location: 'شرکت ساپکو',
      duration: 23,
      valid_duration: 20,
      startTime: '1392/02/01',
      endTime: '1393/12/29'
    },
    {
      title: 'رئیس حسابداری',
      location: 'شرکت محور سازاتن',
      duration: 24,
      valid_duration: 24,
      startTime: '1394/01/01',
      endTime: '1395/12/29'
    }
  ];
  edudata: any[] = [
    {
      id: 1,
      type: 'لیسانس',
      uni: 'صنعتی شریف',
      reshte: 'مکانیک',
      gerayesh: 'جامدات',
      start: '1370/07/01',
      end: '1375/03/31',
      average: '16',
      active: 'پاییان یافته'
    },
    {
      id: 2,
      type: 'فوق لیسانس',
      uni: 'صنعتی شریف',
      reshte: 'مکانیک',
      gerayesh: 'جامدات',
      start: '1375/07/01',
      end: '1377/03/31',
      average: '17',
      active: 'پاییان یافته'
    }
  ];
  dependents: any[] = [
    {
      firstname: 'مهدی',
      lastname: 'محسنی',
      nesbat: 'فرزند'
    },
    {
      firstname: 'رضا',
      lastname: 'محسنی',
      nesbat: 'فرزند'
    },
    {
      firstname: 'محمد',
      lastname: 'محسنی',
      nesbat: 'پدر'
    }
  ];

  get constants(): any { return this.constantsService.constrants; }

  constructor(fb: FormBuilder, private msg: NzMessageService, private constantsService: ConstantsService) {
    this.myform = fb.group({
      serial: [],
      JobId: [],
      Status: [],
      FirstName: [],
      FirstNameEnglish: [],
      LastName: [],
      LastNameEnglish: [],
      NationalCode: [],
      IdNumber: [],
      BirthDate: [],
      MarriageDate: [],
      IdSerialNumber: [],
      IssuanceCityId: [],
      BirthPlaceCityId: [],
      Gender: [],
      MaritalStatus: [],
      PhoneNumber: [],
      MobileNumber: [],
      PostalCode: [],
      Address: [],
      ReligionType: [],
      BloodType: [],
      SoldierType: [],
      HousingType: [],
      InsuranceType: [],
      InjuriesPercentage: [],
      IsMartyrChild: [],
      FrontFrequency: [],
      serialVal: [],
      IsMartyrFamily: [],
      FrontDuration: [],
      BondageDuration: []
    });

    this.deform = fb.group({
      Gender: [],
      BirthDate: [],
      IdNumber: [],
      NationalCode: [],
      MarriageDate: [],
      EducationType: [],
      IsSupplementaryInsured: [],
      IsDependant: [],
    });
  }
  myform: FormGroup;
  deform: FormGroup;
  error = '';
  type = 0;
  
  get IsMartyrChild(): boolean { return this.myform.controls['IsMartyrChild'].value; }
  get IsMartyrFamily(): boolean { return this.myform.controls['IsMartyrFamily'].value; }

  ngOnInit() {
    this.myform.patchValue({
      serialVal:11
    });
    for (let i = 0; i < 2; i++) {
      this.listOfData.push({
        id: `${i}`,
        fullname: `${i}`,
        type: `${i}`,
        status: `${i}`,
        year: `139${i}`,
        month: `${i}`,
        yearedit: `139${i + 2}`,
        monthedit: `${i}`,
        personnel: 'test',
      });
    }
    this.updateEditCache();
  }

  submit() {
    this.error = '';
  }

  beforeUpload = (file: File) => {
    return new Observable((observer: Observer<boolean>) => {
      const isJPG = file.type === 'image/jpeg';
      if (!isJPG) {
        this.msg.error('You can only upload JPG file!');
        observer.complete();
        return;
      }
      const isLt2M = file.size / 1024 / 1024 < 2;
      if (!isLt2M) {
        this.msg.error('Image must smaller than 2MB!');
        observer.complete();
        return;
      }
      // check height
      this.checkImageDimension(file).then(dimensionRes => {
        if (!dimensionRes) {
          this.msg.error('Image only 300x300 above');
          observer.complete();
          return;
        }

        observer.next(isJPG && isLt2M && dimensionRes);
        observer.complete();
      });
    });
  };

  private getBase64(img: File, callback: (img: string) => void): void {
    const reader = new FileReader();
    reader.addEventListener('load', () => callback(reader.result!.toString()));
    reader.readAsDataURL(img);
  }

  private checkImageDimension(file: File): Promise<boolean> {
    return new Promise(resolve => {
      const img = new Image(); // create image
      img.src = window.URL.createObjectURL(file);
      img.onload = () => {
        const width = img.naturalWidth;
        const height = img.naturalHeight;
        window.URL.revokeObjectURL(img.src!);
        resolve(width === height && width >= 300);
      };
    });
  }

  handleChange(info: { file: UploadFile }): void {
    switch (info.file.status) {
      case 'uploading':
        this.loading = true;
        break;
      case 'done':
        // Get this url from response in real world.
        this.getBase64(info.file!.originFileObj!, (img: string) => {
          this.loading = false;
          this.avatarUrl = img;
        });
        break;
      case 'error':
        this.msg.error('Network error');
        this.loading = false;
        break;
    }
  }
  checkButtonMartyr(): void {
    this.Martyr = !this.Martyr;
  }
  checkButtonMartyrFamily(): void {
    this.MartyrFamily = !this.MartyrFamily;
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
        fullname: `test`,
        type: `test`,
        status: `test`,
        year: `test`,
        month: 'test',
        yearedit: `test`,
        monthedit: 'test',
        personnel: 'test',
      },
      ...this.listOfData,
    ];
  }
}
