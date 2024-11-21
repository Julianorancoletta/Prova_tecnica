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
      .get(`${this.UrlService}/api`)
      .pipe(map(this.extractData), catchError(this.serviceError));
  }

  PostCliente(body: any): Observable<any> {
    return this.http
      .post(`${this.UrlService}/api/Cadastrar`, body)
      .pipe(map(this.extractData), catchError(this.serviceError));
  }

  DeleteCliente(id: number): Observable<number> {
    return this.http
      .delete(`${this.UrlService}`)
      .pipe(map(this.extractData), catchError(this.serviceError));
  }
}
