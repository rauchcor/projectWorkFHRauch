import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { CallbackComponent } from './components/callback/callback.component';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

import { AuthService } from './components/services/auth.service';
import { GlobalEventsManager } from './components/services/global.events.manager';
import { AuthGuardService } from './components/services/auth-guard.service';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CallbackComponent,
        UnauthorizedComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'callback', component: CallbackComponent },    
            { path: 'counter', component: CounterComponent },
            { path: 'unauthorized', component: UnauthorizedComponent },
            { path: 'fetch-data', component: FetchDataComponent, canActivate:[AuthGuardService]  },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ AuthService, AuthGuardService, GlobalEventsManager ]
    
})
export class AppModuleShared {
}
