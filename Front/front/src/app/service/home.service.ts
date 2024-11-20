import { HttpClient } from '@angular/common/http';
import { BaseService } from './common/base.service';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';

@Injectable()
export class HomeService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  getClienteList(): Observable<any[]> {
    return this.http
      .get(`${this.UrlService}/api`, super.ObterAuthHeaderJson())
      .pipe(map(this.extractData), catchError(this.serviceError));
  }

  PostEspeciality(body: any): Observable<any> {
    return this.http
      .post(`${this.UrlService}/Especiality`, body, super.ObterAuthHeaderJson())
      .pipe(map(this.extractData), catchError(this.serviceError));
  }

  DeleteEspeciality(id: number): Observable<number> {
    return this.http
      .delete(
        `${this.UrlService}/Especiality/${id}`,
        super.ObterAuthHeaderJson()
      )
      .pipe(map(this.extractData), catchError(this.serviceError));
  }
}
