import { Injectable } from '@angular/core';
import { Http, HttpModule, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
@Injectable()
export class ConfigService {
  private configData: any;
  private configPath = './assets/env.json';

  constructor(
    private http: Http) {
  }

  public initialize(): Promise<any> {
    return this.http.get(this.configPath)
      .map((res: any) => res.json())
      .toPromise()
      .then((data: any) => this.configData = data)
      .catch((error: any) => {
        console.log(error);
        Promise.resolve();
      });
  }

  public getApiUrl(): string {
    return this.getConfigValue<string>("apiUrl");
  }

  private getConfigValue<T>(configKey: string): T {
    if (this.configData == null) {
      throw new Error("Could not read config - you have to call \"initialize\" first");
    }
    return this.configData[configKey];
  }
}
