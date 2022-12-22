import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroHospitalComponent } from './components/cadastro-hospital/cadastro-hospital.component';
import { HomeComponent } from './components/home/home.component';
import { BeneficiarioComponent } from './components/beneficiario/beneficiario.component';
import { ProfissionalComponent } from './components/profissional/profissional.component';
import { ListarHospitaisComponent } from './components/listar-hospitais/listar-hospitais.component';
import { ListarProfissionalComponent } from './components/listar-profissional/listar-profissional.component';
import { EspecialidadesComponent } from './components/especialidades/especialidades.component';
import { ListarBeneficiariosComponent } from './components/listar-beneficiarios/listar-beneficiarios.component';
import { EditarHospitalComponent } from './components/editar-hospital/editar-hospital.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastroHospitalComponent,
    HomeComponent,
    BeneficiarioComponent,
    ProfissionalComponent,
    ListarHospitaisComponent,
    ListarProfissionalComponent,
    EspecialidadesComponent,
    ListarBeneficiariosComponent,
    EditarHospitalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
