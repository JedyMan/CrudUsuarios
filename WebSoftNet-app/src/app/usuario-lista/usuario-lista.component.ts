import { Component } from '@angular/core';
import { Usuarios} from '../usuarios';
import { UsuarioService } from '../usuario.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.css']
})
export class UsuarioListaComponent {
  usuarios: Usuarios[];
  posts = new Array();

  constructor(private usuarioServicio: UsuarioService, private enrutador: Router){}

  ngOnInit(){
    this.obtenerUsuarios();
  }

  private obtenerUsuarios(){
    this.usuarioServicio.obtenerUsuariosLista().subscribe(
      (datos => {
        this.usuarios = datos;
      })
    );
  }

  checkAllCheckBox(ev: any) {
    this.usuarios.forEach(x => x.checked = ev.target.checked)
  }

  isAllCheckBoxChecked() {
    return this.usuarios.every(p => p.checked);
  }

  editarUsuario(id: number){
    this.enrutador.navigate(['editar-usuario', id])
  }

  eliminarUsuario(id: number){
    this.usuarioServicio.eliminarUsuario(id).subscribe(
      {
        next: (datos) => { this.obtenerUsuarios() },
        error: (error)=> { console.log(error) }
      }
    );
  }
}
