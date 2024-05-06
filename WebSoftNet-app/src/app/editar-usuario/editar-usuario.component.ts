import { Component } from '@angular/core';
import { Usuarios } from '../usuarios';
import { UsuarioService } from '../usuario.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.css']
})
export class EditarUsuarioComponent {
  usuario: Usuarios = new Usuarios();
  id: number;

  constructor(private usuarioServicio: UsuarioService,
              private ruta: ActivatedRoute, private enrutador: Router){}

  ngOnInit(): void {
    this.id = this.ruta.snapshot.params['id'];
    this.usuarioServicio.obtenerUsuarioId(this.id).subscribe(
      {
        next: (datos) => {this.usuario = datos},
        error: (error: any) => { console.log(error) }
      }
    );
  }

  onSubmit(){
    this.editarUsuario();
  }

  editarUsuario(){
    this.usuarioServicio.editarUsuario(this.usuario).subscribe(
      {
        next: (datos) => {this.irListaUsuarios()},
        error: (error: any) => { console.log(error) }
      }
    )
  }

  irListaUsuarios(){
    this.enrutador.navigate(['/usuarios']);
  }
}
