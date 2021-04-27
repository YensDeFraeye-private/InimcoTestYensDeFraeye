import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ['input { display: block; }']
})

export class HomeComponent {
  constructor(private http: HttpClient) { }

  public personInfoModel: PersonInfoModel;

  firstName = '';
  lastName = '';
  socialSkills = '';
  socialAccounts = '';
  personInfo = Object;

  //btn Submit
  onSubmit() {
    this.personInfoModel = undefined;

    if (this.firstName != '' && this.lastName != '') {
      this.fetchPersonInfo();
    } else {
      // validate all form fields
      console.log('form not valid');
    }
  }

  //API Call
  fetchPersonInfo() {
    var person = {
      'FirstName': this.firstName,
      'LastName': this.lastName,
      'SocialSkills': this.socialSkills,
      'SocialAccounts': this.socialAccounts
    };

    let res = this.http.post<PersonInfoModel>('https://localhost:44318/api/Person/getInfo', person)
      .subscribe((data) => {
        //this.personInfo = data;
        this.personInfoModel = data;
        console.log(data);
      },
        error => console.error(error)
      )
  }
}

interface PersonInfoModel {
  vowels: number;
  constenants: number;
  fullName: string;
  reversedFullName: string;
  originalPersonModel: Person;
}

interface Person {
  firstName: string;
  lastName: string;
  socialSkills: string[];
  socialAccount: SocialAccount[];
}

interface SocialAccount {
  type: string;
  address: string;
}
