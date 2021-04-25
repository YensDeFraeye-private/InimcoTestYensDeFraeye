import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  firstName = '';

  onClickMe() {
    console.log('name:' + this.firstName);
  }
}
