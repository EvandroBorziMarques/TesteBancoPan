import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ApiService {
  private baseUrl = 'https://localhost:44372';

  constructor(private http: HttpClient) { }

  getItems(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/pessoa`);
  }

  createItem(item: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/pessoa`, item);
  }

  updateItem(id: string, item: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/pessoa/${id}`, item);
  }

  deleteItem(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/pessoa/${id}`);
  }
}
