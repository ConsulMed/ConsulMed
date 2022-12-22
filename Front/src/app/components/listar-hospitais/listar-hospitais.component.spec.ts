import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarHospitaisComponent } from './listar-hospitais.component';

describe('ListarHospitaisComponent', () => {
  let component: ListarHospitaisComponent;
  let fixture: ComponentFixture<ListarHospitaisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarHospitaisComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarHospitaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
