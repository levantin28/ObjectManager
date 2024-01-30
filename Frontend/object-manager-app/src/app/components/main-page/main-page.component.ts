import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DataService } from '../../services/data.service';
import { GeneralObjectApiModel } from '../../models/general-object';
import { RelationApiModel } from '../../models/relation';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent implements OnInit {
  private paginator!: MatPaginator;
  private sort!: MatSort;

  @ViewChild(MatSort) set matSort(ms: MatSort) {
    this.sort = ms;
    this.setDataSourceAttributes();
  }

  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    this.setDataSourceAttributes();
  }

  constructor(private dataService: DataService) {

  }

  displayedColumnsGeneralObjectDataSource: string[] = ['id', 'name', 'description', 'type', 'actions'];
  displayedColumnsSecondaryGeneralObjectDataSource: string[] = ['id', 'name', 'description', 'type'];
  displayedColumnsRelationDataSource: string[] = ['id', 'parentObjectId', 'childObjectId', 'actions'];
  generalObjectDataSource!: MatTableDataSource<any>;
  relationDataSource!: MatTableDataSource<any>;
  parentsGeneralObjectDataSource!: MatTableDataSource<any>;
  childsGeneralObjectDataSource!: MatTableDataSource<any>;
  relations: RelationApiModel[] = [];
  generalObjects: GeneralObjectApiModel[] = [];
  parentsGeneralObjects: GeneralObjectApiModel[] = [];
  childsGeneralObjects: GeneralObjectApiModel[] = [];
  showCreateGeneralObjectScreen: boolean = false;
  showUpdateGeneralObjectScreen: boolean = false;
  showCreateRelationScreen: boolean = false;
  showUpdateRelationScreen: boolean = false;
  showMainPage: boolean = true;
  showDetailsScreen: boolean = false;
  selectedGeneralObjectId: number = 0;
  selectedRelationId: string = "";

  updateGeneralObjectForm: FormGroup = new FormGroup({
    id: new FormControl(""),
    name: new FormControl(""),
    description: new FormControl(""),
    type: new FormControl(""),
  });

  createGeneralObjectForm: FormGroup = new FormGroup({
    name: new FormControl(""),
    description: new FormControl(""),
    type: new FormControl(""),
  });

  updateRelationForm: FormGroup = new FormGroup({
    id: new FormControl(""),
    parentObjectId: new FormControl(""),
    chidlObjectId: new FormControl(""),
  });

  createRelationForm: FormGroup = new FormGroup({
    parentObjectId: new FormControl(""),
    chidlObjectId: new FormControl(""),
  });

  ngOnInit(): void {
    this.dataService.getAllGeneralObjects().subscribe({
      next: (res) => {
        res.forEach((element: any) => {
          let generalObject = new GeneralObjectApiModel();
          generalObject.id = element.id;
          generalObject.name = element.name;
          generalObject.description = element.description;
          generalObject.type = element.type;

          this.generalObjects.push(generalObject);
        });
        this.generalObjectDataSource = new MatTableDataSource(this.generalObjects);
        this.generalObjectDataSource.paginator = this.paginator;
        this.generalObjectDataSource.sort = this.sort;
      },
      error: (err) => { console.log(err.message); }
    })

    this.dataService.getAllRelations().subscribe({
      next: (res) => {
        res.forEach((element: any) => {
          let relation = new RelationApiModel();
          relation.id = element.id;
          relation.parentObjectId = element.parentObjectId;
          relation.childObjectId = element.childObjectId;

          this.relations.push(relation);
        });
        this.relationDataSource = new MatTableDataSource(this.relations);
        this.relationDataSource.paginator = this.paginator;
        this.relationDataSource.sort = this.sort;
      },
      error: (err) => { console.log(err.message); }
    })
  }

  setDataSourceAttributes() {
    this.generalObjectDataSource.paginator = this.paginator;
    this.generalObjectDataSource.sort = this.sort;
    this.relationDataSource.paginator = this.paginator;
    this.relationDataSource.sort = this.sort;
  }

  showUpdateRelation(event: any, row: any) {
    this.showMainPage = false;
    this.showUpdateRelationScreen = true;
    this.updateRelationForm.controls['id'].setValue(row.id);
    this.updateRelationForm.controls['parentObjectId'].setValue(row.parentObjectId);
    this.updateRelationForm.controls['childObjectId'].setValue(row.childObjectId);
    this.selectedRelationId = row.id;
  }

  showUpdateGeneralObject(event: any, row: any) {
    this.showMainPage = false;
    this.showUpdateGeneralObjectScreen = true;
    this.updateGeneralObjectForm.controls['id'].setValue(row.id);
    this.updateGeneralObjectForm.controls['name'].setValue(row.name);
    this.updateGeneralObjectForm.controls['description'].setValue(row.description);
    this.updateGeneralObjectForm.controls['type'].setValue(row.type);
    this.selectedGeneralObjectId = row.id;
  }

  deleteRelation(event: any, row: any) {
    this.dataService.deleteRelation(row.id).subscribe();
  }

  deleteGeneralObject(event: any, row: any) {
    this.dataService.deleteGeneralObject(row.id).subscribe();
  }

  showCreateGeneralObject(event: any) {
    this.showMainPage = false;
    this.showCreateGeneralObjectScreen = true;
  }

  showCreateRelation(event: any) {
    this.showMainPage = false;
    this.showCreateRelationScreen = true;
  }

  backToMain() {
    this.showMainPage = true;
    this.showDetailsScreen = false;
    this.showCreateGeneralObjectScreen = false;
    this.showUpdateGeneralObjectScreen = false;
    this.showCreateRelationScreen = false;
    this.showUpdateRelationScreen = false;
    this.updateGeneralObjectForm.controls['id'].setValue("");
    this.updateGeneralObjectForm.controls['name'].setValue("");
    this.updateGeneralObjectForm.controls['description'].setValue("");
    this.updateGeneralObjectForm.controls['type'].setValue("");
    this.updateRelationForm.controls['id'].setValue("");
    this.updateRelationForm.controls['parentObjectId'].setValue("");
    this.updateRelationForm.controls['childObjectId'].setValue("");
    this.createGeneralObjectForm.controls['id'].setValue("");
    this.createGeneralObjectForm.controls['name'].setValue("");
    this.createGeneralObjectForm.controls['description'].setValue("");
    this.createGeneralObjectForm.controls['type'].setValue("");
    this.createRelationForm.controls['id'].setValue("");
    this.createRelationForm.controls['parentObjectId'].setValue("");
    this.createRelationForm.controls['childObjectId'].setValue("");
    this.childsGeneralObjects = [];
    this.parentsGeneralObjects = [];
    this.parentsGeneralObjectDataSource = new MatTableDataSource(this.parentsGeneralObjects);
    this.childsGeneralObjectDataSource = new MatTableDataSource(this.childsGeneralObjects);
    this.selectedRelationId = "";
    this.selectedGeneralObjectId = 0;
  }

  createGeneralObject(event: any) {
    this.dataService.postGeneralObject(this.createGeneralObjectForm.value).subscribe();
    this.backToMain();
  }

  createRelation(event: any) {
    this.dataService.postRelation(this.createRelationForm.value).subscribe();
    this.backToMain();
  }

  updateGeneralObject(event: any) {
    let generalObject = new GeneralObjectApiModel();
    generalObject.id = this.selectedGeneralObjectId;
    generalObject.name = this.updateGeneralObjectForm.controls['name'].value;
    generalObject.description = this.updateGeneralObjectForm.controls['description'].value;
    generalObject.type = this.updateGeneralObjectForm.controls['type'].value;

    this.dataService.putGeneralObject(generalObject).subscribe();
    this.backToMain();
  }

  updateRelation(event: any) {
    let relation = new RelationApiModel();
    relation.id = this.selectedRelationId;
    relation.parentObjectId = this.updateRelationForm.controls['parentObjectId'].value;
    relation.childObjectId = this.updateRelationForm.controls['childObjectId'].value;

    this.dataService.putRelation(relation).subscribe();
    this.backToMain();
  }

  showDetails(event:any, row:any){
    this.parentsGeneralObjects = [];
    this.childsGeneralObjects = [];
    this.showMainPage = false;
    this.showDetailsScreen = true;
    this.dataService.getParentObjects(row.id).subscribe({
      next: (res) => {
        res.forEach((element: any) => {
          let generalObject = new GeneralObjectApiModel();
          generalObject.id = element.id;
          generalObject.name = element.name;
          generalObject.description = element.description;
          generalObject.type = element.type;

          this.parentsGeneralObjects.push(generalObject);
        });
        this.parentsGeneralObjectDataSource = new MatTableDataSource(this.parentsGeneralObjects);
      },
      error: (err) => { console.log(err.message); }
    });

    this.dataService.getChildObjects(row.id).subscribe({
      next: (res) => {
        res.forEach((element: any) => {
          let generalObject = new GeneralObjectApiModel();
          generalObject.id = element.id;
          generalObject.name = element.name;
          generalObject.description = element.description;
          generalObject.type = element.type;

          this.childsGeneralObjects.push(generalObject);
        });
        this.childsGeneralObjectDataSource = new MatTableDataSource(this.childsGeneralObjects);
      },
      error: (err) => { console.log(err.message); }
    });
  }
}
