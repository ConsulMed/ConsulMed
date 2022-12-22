import { ProfissionalComponent } from './components/profissional/profissional.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BeneficiarioComponent } from './components/beneficiario/beneficiario.component';
import { CadastroHospitalComponent } from './components/cadastro-hospital/cadastro-hospital.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'listarbeneficiarios', component: BeneficiarioComponent },
  { path: 'cadastrarhospital', component: CadastroHospitalComponent},
  { path: 'cadastrarprofissional', component: ProfissionalComponent},
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
