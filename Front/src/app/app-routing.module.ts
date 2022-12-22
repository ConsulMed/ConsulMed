import { ProfissionalComponent } from './components/profissional/profissional.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BeneficiarioComponent } from './components/beneficiario/beneficiario.component';
import { CadastroHospitalComponent } from './components/cadastro-hospital/cadastro-hospital.component';
import { HomeComponent } from './components/home/home.component';
import { ListarHospitaisComponent } from './components/listar-hospitais/listar-hospitais.component';
import { ListarProfissionalComponent } from './components/listar-profissional/listar-profissional.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'listarbeneficiarios', component: BeneficiarioComponent },
  { path: 'cadastrarhospital', component: CadastroHospitalComponent},
  { path: 'listarhospitais', component: ListarHospitaisComponent},
  { path: 'cadastrarprofissional', component: ProfissionalComponent},
  { path: 'listarprofissional', component: ListarProfissionalComponent},
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
