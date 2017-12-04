import { Component, OnInit } from '@angular/core';
import { CarsApiService, CarCreateDto, CarDto } from '../../services/rest-api/project-work-rest-api.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  cars: CarDto[];



  constructor(private carService: CarsApiService) { }

  ngOnInit() {
     this.carService.get()
          .subscribe((cars) => {
            this.cars = cars;
          }, error => console.log(error));
  }

}
