
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { IEspecialidadesDto } from 'src/app/interface/IEspecialidadesDto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-especialidades',
  templateUrl: './especialidades.component.html',
  styleUrls: ['./especialidades.component.css']
})
export class EspecialidadesComponent implements OnInit {
  especialidade!: IEspecialidadesDto;
  idEspecialidadeRecebido!: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idEspecialidadeRecebido = Number(params.get('idEspecialidades'));
          });
  }

  ngOnInit(): void {
    this.especialidade = {
      IdEspecialidade: this.idEspecialidadeRecebido ?? 0,
      nome: '',
      descricao: '',
      ativo: false
    }

  if(this.idEspecialidadeRecebido) {
    this.http
      .get(`https://localhost:7074/Especialidade/PorId/${this.idEspecialidadeRecebido}`)
      .subscribe(data => {
        this.especialidade = data as IEspecialidadesDto;
      });
  }
}

  salvarEspecialidade() {

    if (this.validarInformacoes()) {
      console.log(`Objeto para salvar: ${JSON.stringify(this.especialidade)}`);

      if (this.especialidade.IdEspecialidade == 0) {

        this.http.post('https://localhost:7074/Especialidade/Cadastrar', this.especialidade)
          .subscribe((data) => {
            this.router.navigate(['listarespecialidade']);
          });

      } else {
        this.http.patch('https://localhost:7074/Especialidade/Atualizar', this.especialidade)
          .subscribe((data) => {
            this.router.navigate(['listarespecialidade']);
          });
      }

    } else {
      console.log('Erro na validação');
      // TRATAMENTO DE ERRO
      // ALERTA
      // BORDA VERMELHA
    }
  }

  validarInformacoes(): boolean {
    if (this.especialidade.nome == '') {
      return false;
    }

    // VALIDAR COM REGEX

    return true;
  }

}


