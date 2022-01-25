import { Component, Input, OnInit } from '@angular/core';
import { Colectie } from 'src/app/interfaces/colectie';

@Component({
  selector: 'app-collection-info',
  templateUrl: './collection-info.component.html',
  styleUrls: ['./collection-info.component.css']
})
export class CollectionInfoComponent implements OnInit {

  @Input() colectii: any[] = [];
  constructor() { }

  ngOnInit(): void {

  }

}
