import { Injectable, EventEmitter, Component } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Router } from "@angular/router";
import { UserManager, Log, MetadataService, User } from 'oidc-client';
import { GlobalEventsManager } from './global.events.manager';
import { ResponseOptions } from '@angular/http/src/base_response_options';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';

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

  
  // silentRequestTimeout:10000,

  filterProtocolClaims: true,
  loadUserInfo: true
};

@Injectable()
export class AuthService {
  public _loggedIn: boolean = false;
  _mgr: UserManager;
  _userLoadedEvent: EventEmitter<User> = new EventEmitter<User>();
  _currentUser: User;
  _authHeaders: Headers;

  constructor(
    private http: Http,
    private _router: Router,
    private _globalEventsManager: GlobalEventsManager) {
    if (typeof window !== 'undefined') {
      //instance needs to be created within the if clause
      //otherwise you'll get a sessionStorage not defined error.
      this._mgr = new UserManager(settings);
      this._mgr
        .getUser()
        .then((user) => {
          if (user) {
            this._currentUser = user;
            this._userLoadedEvent.emit(user);
          } else {
            console.log('not logged in')
          }
        })
        .catch((err) => {
          console.log(err);
        });
      this._mgr.events.addUserUnloaded((e) => {
        //if (!environment.production) {
        console.log("user unloaded");
        //}
      });
    }
  }

/**
  isLoggedIn(): Promise<boolean> {

    return this._mgr
      .map((usermanager) => {
        if (typeof window !== 'undefined') {
    return usermanager
          .getUser()
          .then((user) => {
            if (user) {
              this._currentUser = user;
              return true;
            } else {
              this._router.navigate(['unauthorized']);
              return false;
            }
          })
          .catch((err) => {
            this._router.navigate(['unauthorized']);
            return false;
          });}else{
            
          }
      }).switch();


  } */
  isLoggedIn(): Promise<boolean> {
    return this._mgr
      .getUser()
      .then((user) => {
        if (user) {
          this._currentUser = user;
          return true;
        } else {
          this._router.navigate(['unauthorized']);
          return false;
        }
      })
      .catch((err) => {
        this._router.navigate(['unauthorized']);
        return false;
      });


  }
  clearState() {
    this._mgr.clearStaleState().then(function () {
      console.log("clearStateState success");
    }).catch(function (e) {
      console.log("clearStateState error", e.message);
    });
  }

  getUser() {
    this._mgr.getUser().then((user) => {
      console.log("got user");
      this._userLoadedEvent.emit(user);
    }).catch(function (err) {
      console.log(err);
    });
  }

  removeUser() {
    this._mgr.removeUser().then(() => {
      this._userLoadedEvent.emit(undefined);
      console.log("user removed");
    }).catch(function (err) {
      console.log(err);
    });
  }

  startSigninMainWindow() {
    this._mgr.signinRedirect({ data: 'some data' }).then(function () {
      console.log("signinRedirect done");
    }).catch(function (err) {
      console.log(err);
    });
  }

  endSigninMainWindow() {

    if (typeof window !== 'undefined') {
      this._mgr.signinRedirectCallback().then((user) => {
        console.log("signed in");
        this._currentUser = user;
        this._loggedIn = true;
        this._globalEventsManager.showNavBar(this._loggedIn);
        this._router.navigate(['home']);
      }).catch(function (err) {
        console.log(err);
      });
    }
  }

  startSignoutMainWindow() {
    this._mgr.signoutRedirect().then(function (resp) {
      console.log("signed out", resp);
      setTimeout(5000, () => {
        console.log("testing to see if fired...");

      })
    }).catch(function (err) {
      console.log(err);
    });
  };

  endSignoutMainWindow() {
    this._mgr.signoutRedirectCallback().then(function (resp) {
      console.log("signed out", resp);
    }).catch(function (err) {
      console.log(err);
    });
  };
  /**
   * Example of how you can make auth request using angulars http methods.
   * @param options if options are not supplied the default content type is application/json
   */
  AuthGet(url: string, options?: RequestOptions): Observable<Response> {


    if (options) {
      options = this._setRequestOptions(this._currentUser, options);
    }
    else {
      options = this._setRequestOptions(this._currentUser);
    }
    return this.http.get(url, options);


  }


  private _setAuthHeaders(user: User) {
    this._authHeaders = new Headers();
    this._authHeaders.append('Authorization', user.token_type + " " + user.access_token);
    this._authHeaders.append('Content-Type', 'application/json');
  }

  private _setRequestOptions(user: User, options?: RequestOptions) {
    if (options !== undefined) {
      var header = this._authHeaders.get('Authorization');
      this._authHeaders.append('Authorization', String(header));
      this._authHeaders.append('Content-Type', 'application/json');
    }
    else {
      //setting default authentication headers
      this._setAuthHeaders(user);
      options = new RequestOptions({ headers: this._authHeaders, body: "" });
    }
    return options;
  }
}