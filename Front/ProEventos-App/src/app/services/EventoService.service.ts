import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Evento } from '../models/Evento';
import { Observable } from 'rxjs';

@Injectable()
export class EventoService {
baseUrl = 'https://localhost:5001/api/evento';

constructor(private http: HttpClient) { }

getEventos(): Observable<Evento[]> {
  return this.http.get<Evento[]>(this.baseUrl);
}

getEventoById(id: number): Observable<Evento> {
  return this.http.get<Evento>(`${this.baseUrl}/${id}`);
}

getEventosByTema(tema: string): Observable<Evento[]> {
  return this.http.get<Evento[]>(`${this.baseUrl}/${tema}/tema`);
}

}
