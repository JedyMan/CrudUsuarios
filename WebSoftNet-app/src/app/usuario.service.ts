import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuarios } from './usuarios';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private urlBase="https://localhost:7234/api/Usuario"

  constructor(private clienteHttp: HttpClient) { }

  obtenerUsuariosLista(): Observable<Usuarios[]>{
    return this.clienteHttp.get<Usuarios[]>(this.urlBase);
  }

  agregarUsuario(usuario: Usuarios): Observable<Object>{
    return this.clienteHttp.post(this.urlBase, usuario);
  }

  obtenerUsuarioId(id: number){
    return this.clienteHttp.get<Usuarios>(`${this.urlBase}/${id}`);
  }

  editarUsuario(usuario: Usuarios): Observable<Object>{
    return this.clienteHttp.put(this.urlBase, usuario);
  }

  eliminarUsuario(id: number): Observable<Object>{
    return this.clienteHttp.delete(`${this.urlBase}/${id}`);
  }
}
