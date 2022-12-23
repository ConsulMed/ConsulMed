import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { IHospitalDto } from 'src/app/interface/IHospitalDto';

@Component({
  selector: 'app-listar-hospitais',
  templateUrl: './listar-hospitais.component.html',
  styleUrls: ['./listar-hospitais.component.css']
})
export class ListarHospitaisComponent {
  hospitais!: IHospitalDto[];
  hospitaisLista: any = [];
  telaParaApresentar = 'listahospitais';

  ngOnit() {
    this.listarHospitais();
}

  constructor(private http: HttpClient, private router: Router) {
    this.listarHospitais();
  }

  listarHospitais() {
    // LIMPAR A LISTA ANTES DE PREENCHER
    this.hospitais = [];

    this.http.get('https://localhost:7074/ListarTodosHospitais')
    .subscribe(
        response => {this.hospitais = response as IHospitalDto[]; this.hospitaisLista = this.hospitais; },
        error => console.log(error)
    );
  }

  cadastrarHospital() {
      this.router.navigate([`cadastrarhospital`]);
  }

  removerHospital(id: number) {
    this.http.delete(`https://localhost:7074/ExcluirHospital/${id}`)
      .subscribe((data) => {
        console.log(`Linhas executadas no método de remover do banco ${JSON.stringify(data)}`);
        this.listarHospitais();
      });
  }
}
