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

    this.http.get('https://localhost:7074/Beneficiario/ListarTodas')
    .subscribe(
        response => {this.beneficiario = response as IBeneficiarioDto[]; this.beneficiarioLista = this.beneficiario; },
        error => console.log(error)
    );
  }
  removerBeneficiario(id: number) {
    this.http.delete(`https://localhost:7074/Beneficiario/Excluir?idBeneficiario=${id}`)
      .subscribe((data) => {
        console.log(`Linhas executadas no método de remover do banco ${JSON.stringify(data)}`);
        this.listarBeneficiario();
      });
  }

  cadastrarBeneficiario() {
      this.router.navigate([`listarbeneficiarios`]);
  }

}
