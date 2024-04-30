import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  slideIndex: number = 1;

 plusSlides(n: number): void {
    this.showSlides(this.slideIndex += n);
}

 showSlides(n: number): void {
    // Logic to display slides
    // You can add your implementation here
}

}
