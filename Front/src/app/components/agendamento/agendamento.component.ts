import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { IAgendamentoDto } from 'src/app/interface/IAgendamentoDto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendamento.component.html',
  styleUrls: ['./agendamento.component.css']
})
export class AgendamentoComponent implements OnInit {

  agendamento!: IAgendamentoDto;
  idAgendamentoRecebido!: number;
  idBeneficiarioRecebido!: number;
  idHospitalRecebido!: number;
  idEspecialidadeRecebido!: number;
  idProfissionalRecebido!: number;
  dataHoraAgendamentoRecebido!: number;
  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.route.paramMap.subscribe(params => {
      this.idAgendamentoRecebido = Number(params.get('idAgendamento'));
          });
  }

  ngOnInit(): void {
    this.agendamento = {
      idAgendamento: this.idAgendamentoRecebido ?? 0,
      idBeneficiario: this.idBeneficiarioRecebido ?? 0,
      idHospital: this.idHospitalRecebido ?? 0,
      idEspecialidade: this.idEspecialidadeRecebido ?? 0,
      idProfissional: this.idProfissionalRecebido ?? 0,
      dataHoraAgendamento: this.dataHoraAgendamentoRecebido,
      ativo: false,
    }
     if(this.idAgendamentoRecebido) {
      this.http
      .get(`https://localhost:7074/PorId/${this.idAgendamentoRecebido}`)
      .subscribe(data => {
        this.agendamento = data as IAgendamentoDto;
      });
  }
}

  salvar() {

    if (this.validarInformacoes()) {
      console.log(`Objeto para salvar: ${JSON.stringify(this.agendamento)}`);

      if (this.agendamento.idAgendamento == 0) {

        this.http.post('https://localhost:7074/Cadastrar', this.agendamento)
          .subscribe((data) => {
            this.router.navigate(['listaragendamentos']);
          });

      } else {
        this.http.patch('https://localhost:7074/Atualizar', this.agendamento)
          .subscribe((data) => {
            this.router.navigate(['listaragendamentos']);
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
    if (this.agendamento.idAgendamento == null) {
      return false;
    }

    // VALIDAR COM REGEX

    return true;
  }

}
