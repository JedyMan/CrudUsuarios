import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioListaComponent } from './usuario-lista/usuario-lista.component';
import { AgregarUsuarioComponent } from './agregar-usuario/agregar-usuario.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';

const routes: Routes = [
  {path:'usuarios', component: UsuarioListaComponent},
  {path:'', redirectTo: 'usuarios', pathMatch:'full'},
  {path:'agregar-usuario', component: AgregarUsuarioComponent},
  {path:'editar-usuario/:id', component: EditarUsuarioComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
