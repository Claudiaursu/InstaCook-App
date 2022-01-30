import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Colectie } from 'src/app/interfaces/colectie';

@Component({
  selector: 'app-collection-info',
  templateUrl: './collection-info.component.html',
  styleUrls: ['./collection-info.component.css']
})
export class CollectionInfoComponent implements OnInit {

  @Input() colectii: any[] = [];
  @Input() showPrivate: boolean = false;
  @Input() filterSweets: boolean = false;
  @Output() onDeleteColectie: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
    console.log("colectii ", this.colectii)
    console.log("showprivate: ", this.showPrivate)
  }

  deleteColectie(titlu: string){
    this.onDeleteColectie.emit(titlu)
    console.log("s-a emis ", titlu)
  }

}
