import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    claims: any;
    public forecasts: WeatherForecast[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, service: AuthService) {
        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json() as WeatherForecast[];
        }, error => console.error(error));

        service.AuthGet('http://localhost:5001/api/Cars/claims').subscribe(result=>{
            this.claims = result.json();
        })

    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
