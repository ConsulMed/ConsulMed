import { ProfissionalComponent } from './components/profissional/profissional.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BeneficiarioComponent } from './components/beneficiario/beneficiario.component';
import { CadastroHospitalComponent } from './components/cadastro-hospital/cadastro-hospital.component';
import { HomeComponent } from './components/home/home.component';
import { ListarHospitaisComponent } from './components/listar-hospitais/listar-hospitais.component';
import { ListarProfissionalComponent } from './components/listar-profissional/listar-profissional.component';
import { EspecialidadesComponent } from './components/especialidades/especialidades.component';
import { ListarBeneficiariosComponent } from './components/listar-beneficiarios/listar-beneficiarios.component';
import { AgendamentoComponent } from './components/agendamento/agendamento.component';
import { ConsultaComponent } from './components/consulta/consulta.component'

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'listarbeneficiarios', component: BeneficiarioComponent },
  { path: 'cadastrarhospital', component: CadastroHospitalComponent},
  { path: 'listarhospitais', component: ListarHospitaisComponent},
  { path: 'cadastrarprofissional', component: ProfissionalComponent},
  { path: 'listarprofissional', component: ListarProfissionalComponent},
  { path: 'cadastrarespecialidades', component: EspecialidadesComponent},
  { path: 'listarbeneficiario', component: ListarBeneficiariosComponent},
  { path: 'agendamento', component: AgendamentoComponent},
  { path: 'consulta', component: ConsultaComponent},


  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
