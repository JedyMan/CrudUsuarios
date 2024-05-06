import { Component } from '@angular/core';
import { Usuarios } from '../usuarios';
import { UsuarioService } from '../usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-agregar-usuario',
  templateUrl: './agregar-usuario.component.html',
  styleUrls: ['./agregar-usuario.component.css']
})
export class AgregarUsuarioComponent {
  usuario: Usuarios = new Usuarios();

  constructor(private usuarioServicio: UsuarioService, private enrutador: Router){}

  onSubmit(){
    this.guardarUsuario();
  }

  guardarUsuario(){
    this.usuarioServicio.agregarUsuario(this.usuario).subscribe(
      {
        next: (datos) => { this.irListaUsuarios(); },
        error: (error: any) => { console.log(error) }
      }
    );
  }

  irListaUsuarios(){
    this.enrutador.navigate(['/usuarios']);
  }
}
