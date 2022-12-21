import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroHospitalComponent } from './components/cadastro-hospital/cadastro-hospital.component';
import { HomeComponent } from './components/home/home.component';
import { BeneficiarioComponent } from './components/beneficiario/beneficiario.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastroHospitalComponent,
    HomeComponent,
    BeneficiarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
