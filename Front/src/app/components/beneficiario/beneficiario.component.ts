
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { IBeneficiarioDto } from 'src/app/interface/IBeneficiarioDto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-beneficiario',
  templateUrl: './beneficiario.component.html',
  styleUrls: ['./beneficiario.component.css']
})
export class BeneficiarioComponent implements OnInit {
  beneficiario!: IBeneficiarioDto;
  idBeneficiarioRecebido!: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idBeneficiarioRecebido = Number(params.get('idBeneficiario'));
          });
  }

  ngOnInit(): void {
    this.beneficiario = {
      idBeneficiario: this.idBeneficiarioRecebido ?? 0,
      nome: '',
      cpf: '',
      telefone: '',
      endereco: '',
      numeroCarteirinha: '',
      ativo: false,
      email: '',
      senha: ''
    }

  if(this.idBeneficiarioRecebido) {
    this.http
      .get(`https://localhost:7074/PorId/${this.idBeneficiarioRecebido}`)
      .subscribe(data => {
        this.beneficiario = data as IBeneficiarioDto;
      });
  }
}

  salvar() {

    if (this.validarInformacoes()) {
      console.log(`Objeto para salvar: ${JSON.stringify(this.beneficiario)}`);

      if (this.beneficiario.idBeneficiario == 0) {

        this.http.post('https://localhost:7074/Beneficiario/Cadastrar', this.beneficiario)
          .subscribe((data) => {
            this.router.navigate(['listarbeneficiarios']);
          });

      } else {
        this.http.patch('https://localhost:7074/Beneficiario/Atualizar', this.beneficiario)
          .subscribe((data) => {
            this.router.navigate(['listarbeneficiarios']);
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
    if (this.beneficiario.nome == '') {
      return false;
    }

    // VALIDAR COM REGEX

    return true;
  }

}


