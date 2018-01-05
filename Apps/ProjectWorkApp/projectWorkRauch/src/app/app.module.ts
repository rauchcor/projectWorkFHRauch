import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { AppComponent } from './app.component';
import { CarsApiService } from './services/rest-api/project-work-rest-api.service';
import { ConfigService } from './services/config.service';
import { HomeComponent } from './components/home/home.component';
import { CarsComponent } from './components/cars/cars.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { BackendServiceModule } from './services/rest-api/backend.module';
import { OAuthModule } from 'angular-oauth2-oidc';


export function startupConfigServiceFactory(configService: ConfigService): Function {
  return () => configService.initialize();
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CarsComponent,
    LoginComponent,
    LogoutComponent,
    UnauthorizedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    BackendServiceModule,
    HttpModule,
    BrowserModule,
    OAuthModule.forRoot()
  ],
  providers: [
    ConfigService,
    { provide: APP_INITIALIZER, useFactory: startupConfigServiceFactory, deps: [ConfigService], multi: true},
    CarsApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
