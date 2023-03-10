import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { IProfissionalDto } from 'src/app/interface/IProfissionalDto';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-editar-profissional',
  templateUrl: './editar-profissional.component.html',
  styleUrls: ['./editar-profissional.component.css']
})
export class EditarProfissionalComponent {
  profissional!: IProfissionalDto;
  idProfissionalRecebido!: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idProfissionalRecebido = Number(params.get('idProfissional'));
    });
  }

  ngOnInit(): void {
    this.profissional = {
      IdProfissional: this.idProfissionalRecebido ?? 0,
      Nome: '',
      Telefone: '',
      Endereco: '',
      Ativo: false
    }


    if (this.idProfissionalRecebido) {
      this.http
        .get(`https://localhost:7074/ConsultarProfissionalPorId/${this.idProfissionalRecebido}`)
        .subscribe((data) => {
          this.profissional = data as IProfissionalDto;
        });
    }

  }

  salvarProfissionalEditado() {

    if (this.validarInformacoes()) {
      console.log(`Objeto para salvar: ${JSON.stringify(this.profissional)}`);

      if (this.profissional.IdProfissional == 0) {

        this.http.post('https://localhost:7074/Profissional/CadastrarProfissional', this.profissional)
          .subscribe((data) => {
            this.router.navigate(['cadastrarprofissional']);
          });

      } else {
        this.http.patch('https://localhost:7074/Profissional/AtualizarProfissional', this.profissional)
          .subscribe((data) => {
            this.router.navigate(['listarprofissional']);
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
    if (this.profissional.Nome == '') {
      return false;
    }

    // VALIDAR COM REGEX

    return true;
  }

}
