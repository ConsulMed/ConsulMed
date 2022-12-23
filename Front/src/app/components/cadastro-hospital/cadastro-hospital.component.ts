import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IHospitalDto } from 'src/app/interface/IHospitalDto';

@Component({
  selector: 'app-cadastro-hospital',
  templateUrl: './cadastro-hospital.component.html',
  styleUrls: ['./cadastro-hospital.component.css']
})
export class CadastroHospitalComponent implements OnInit {

  @Input()
  maxlength!: string | number | null;

  hospital!: IHospitalDto;
  idHospitalRecebido!: number;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idHospitalRecebido = Number(params.get('IdHospital'));
          });
  }

  ngOnInit(): void {
    this.hospital = {
      IdHospital: this.idHospitalRecebido ?? 0,
      Nome: '',
      Cnpj: '',
      Telefone: '',
      Endereco: '',
      Cnes: '',
      Ativo: false,
    }

    if(this.idHospitalRecebido) {
      this.http
        .get(`https://localhost:7074/Hospital/${this.idHospitalRecebido}`)
        .subscribe(data => {
          this.hospital = data as IHospitalDto;
        });
    }
  }

  salvarHospital() {
    if (this.validarInformacoes()) {
      console.log(`Objeto para salvar: ${JSON.stringify(this.hospital)}`);

      if (this.hospital.IdHospital == 0) {

        this.http.post('https://localhost:7074/CadastrarHospital', this.hospital)
          .subscribe((data) => {
            this.router.navigate(['cadastrarhospital']);
          });

      } else {
        this.http.patch('https://localhost:7074/EditarHospital', this.hospital)
          .subscribe((data) => {
            this.router.navigate(['listarhospitais']);
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
    if (this.hospital.Nome == '') {
      return false;
    }

    // VALIDAR COM REGEX

    return true;
  }

}
