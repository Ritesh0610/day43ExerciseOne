import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import {Student} from './student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
   readonly stdUrl='https://localhost:44340/api';

   stdList:Student[];
  constructor(private objhttp:HttpClient) { }
  studentList()
  {
    this.objhttp.get(this.stdUrl+'/Students').toPromise().then(res=>this.stdList=res as Student[]);
  }
}
