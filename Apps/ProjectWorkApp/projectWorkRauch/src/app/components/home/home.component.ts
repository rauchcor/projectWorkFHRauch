import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc'
import { Http } from '@angular/http/src/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [Http]
  
})
export class HomeComponent implements OnInit {

  constructor(private oauthService: OAuthService,
              private http: Http) {
    this.oauthService.redirectUri = window.location.origin;
    this.oauthService.clientId = 'mvc';
    this.oauthService.scope = 'openid profile carApi';
    this.oauthService.issuer = 'http://localhost:5000';
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.oidc = true;
    // Load Discovery Document and then try to login the user
    this.oauthService.loadDiscoveryDocument().then(() => {
      this.oauthService.tryLogin({
        validationHandler: context => {
            var search = new URLSearchParams();
            search.set('token', context.idToken); 
            search.set('client_id', oauthService.clientId);
            return http.get(validationUrl, { search }).toPromise();
        }
    });
    });
  }
  ngOnInit() {
  }



}
