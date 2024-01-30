import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  currentYear: string = "";
  title = 'object-manager-app';

  constructor() {
    
  }

  ngOnInit(): void {
    this.currentYear = (new Date()).getFullYear().toString();
  }
}
