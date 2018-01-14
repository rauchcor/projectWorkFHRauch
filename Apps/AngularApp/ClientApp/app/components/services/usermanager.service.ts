import { Injectable, EventEmitter, Component } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Router } from "@angular/router";
import { UserManager, Log, MetadataService, User } from 'oidc-client';
import { GlobalEventsManager } from './global.events.manager';
import { ResponseOptions } from '@angular/http/src/base_response_options';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Subject } from 'rxjs/Subject';

const settings: any = {

  authority: 'http://localhost:5000',
  client_id: 'ng',
  redirect_uri: 'http://localhost:4427/callback',
  post_logout_redirect_uri: 'http://localhost:4427/home',
  response_type: 'id_token token',
  scope: 'openid profile carApi',

  silent_redirect_uri: 'http://localhost:4427/silent-renew.html',
  automaticSilentRenew: true,
  accessTokenExpiringNotificationTime: 4,
  //userStore: new WebStorageStateStore({ store: localStorage}),
  // silentRequestTimeout:10000,

  filterProtocolClaims: true,
  loadUserInfo: true
};



@Injectable()
export class UserManagerService {
    userData: any;
    
    userManager:BehaviorSubject<UserManager> = new BehaviorSubject<UserManager>(new UserManager(settings));
    userManager$:Observable<UserManager> = this.userManager.asObservable();

    constructor(
        private _globalEventsManager: GlobalEventsManager){

            this.initialize();
          }
    private initialize(){
        if (typeof window !== 'undefined') {
            //instance needs to be created within the if clause
            //otherwise you'll get a sessionStorage not defined error.
            this.userManager.next( new UserManager(settings));
        }
        while(typeof window !== 'undefined'){
            this.userManager.next( new UserManager(settings));
        }
    }

}