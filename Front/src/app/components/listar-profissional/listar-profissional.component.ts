import { IProfissionalDto } from './../../interface/IProfissionalDto';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs';

@Component({
  selector: 'app-listar-hospitais',
  templateUrl: './listar-profissional.component.html',
  styleUrls: ['./listar-profissional.component.css']
})
export class ListarProfissionalComponent {
  profissional!: IProfissionalDto[];
  profissionalLista: any = [];
  telaParaApresentar = 'listaprofissional';

  ngOnit() {
    this.listarProfissional();
}

  constructor(private http: HttpClient, private router: Router) {
    this.listarProfissional();
  }

  listarProfissional() {
    // LIMPAR A LISTA ANTES DE PREENCHER
    this.profissional = [];

    this.http.get('https://localhost:7074/Profissional/ListarTodosProfissionais')
    .subscribe(
        response => {this.profissional = response as IProfissionalDto[]; this.profissionalLista = this.profissional; },
        error => console.log(error)
    );
  }

  removerProfissional(id: number) {
    this.http.delete(`https://localhost:7074/Profissional/ExcluirProfissional?IdProfissional=${id}`)
      .subscribe((data) => {
        console.log(`Linhas executadas no método de remover do banco ${JSON.stringify(data)}`);
        this.listarProfissional();
      });
  }

  cadastrarProfissional() {
      this.router.navigate([`cadastrarprofissional`]);
  }
  editarProfissional(id: number) {
    this.router.navigate([`/editarProfissional`]);
  }

}
