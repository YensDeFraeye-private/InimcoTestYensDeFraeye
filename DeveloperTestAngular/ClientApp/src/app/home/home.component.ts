import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ['input { display: block; }']
})

export class HomeComponent {
  constructor(private http: HttpClient) { }

  firstName = '';
  lastName = '';
  socialSkills = '';
  socialAccounts = '';
  personInfo = Object;

  onSubmit() {
    console.log('Firstname:' + this.firstName);
    console.log('Lastname:' + this.lastName);
    console.log('socialSkills:' + this.socialSkills);
    console.log('socialAccounts:' + this.socialAccounts);

    this.fetchPersonInfo();
  }

  fetchPersonInfo() {
    var person = {
      'FirstName': this.firstName,
      'LastName': this.lastName,
      'SocialSkills': this.socialSkills,
      'SocialAccounts': this.socialAccounts
    };

    let res = this.http.post<any>('https://localhost:44318/api/Person/getInfo', person)
      .subscribe((data) => {
        this.personInfo = data;
      })
  }
}
