import { Injectable, Component } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { AuthService } from './auth.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthGuardService implements CanActivate {

    constructor(private _authService: AuthService, private _router: Router) { 
    }

    canActivate(): boolean | Observable<boolean> | Promise<boolean> {
        if (typeof window !== 'undefined') {
        return this._authService.isLoggedIn();
        }
    }

    checkIfWindowDefined(){

        if (typeof window !== 'undefined') {
            return true;
        }else {
            return false;
        }
    }
}