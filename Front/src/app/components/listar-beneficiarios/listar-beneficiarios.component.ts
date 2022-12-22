import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { IBeneficiarioDto } from 'src/app/interface/IBeneficiarioDto';


@Component({
  selector: 'app-listar-beneficiarios',
  templateUrl: './listar-beneficiarios.component.html',
  styleUrls: ['./listar-beneficiarios.component.css']
})
export class ListarBeneficiariosComponent {
  beneficiario!: IBeneficiarioDto[];
  beneficiarioLista: any = [];
  telaParaApresentar = 'listaBeneficiario';

  ngOnit() {
    this.listarBeneficiario();
}

  constructor(private http: HttpClient, private router: Router) {
    this.listarBeneficiario();
  }

  listarBeneficiario() {
    // LIMPAR A LISTA ANTES DE PREENCHER
    this.beneficiario = [];

    this.http.get('https://localhost:7074/ListarTodas')
    .subscribe(
        response => {this.beneficiario = response as IBeneficiarioDto[]; this.beneficiarioLista = this.beneficiario; },
        error => console.log(error)
    );
  }

  cadastrarBeneficiario() {
      this.router.navigate([`cadastrarbeneficiario`]);
  }

}
