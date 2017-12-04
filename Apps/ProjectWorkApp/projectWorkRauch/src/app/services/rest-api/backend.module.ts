import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import * as generated from './project-work-rest-api.service';
import { generate } from 'rxjs/observable/generate';
import { ConfigService } from '../config.service';

@NgModule({
    imports: [
        HttpModule
    ],
    providers: [
        {
        /* set's the web api base url (NSwag client) */
            provide: generated.API_BASE_URL,
            useFactory: ApiUrlFactory,
            deps: [ConfigService]
        },
        generated.CarsApiService,

    ]
})
export class BackendServiceModule {
}

 export function ApiUrlFactory(configService: ConfigService) {
    return configService.getApiUrl();
}
