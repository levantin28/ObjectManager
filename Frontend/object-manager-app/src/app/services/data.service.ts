import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { Observable } from 'rxjs';
import { GeneralObjectApiModel } from '../models/general-object';
import { RelationApiModel } from '../models/relation';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  constructor(private http: HttpClient, private configService: ConfigService) {}

  // GeneralObjects Endpoints

  postGeneralObject(data: GeneralObjectApiModel): Observable<any> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/create`;
    return this.http.post(apiUrl, data);
  }

  putGeneralObject(data: GeneralObjectApiModel): Observable<any> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/update`;
    return this.http.put(apiUrl, data);
  }

  deleteGeneralObject(id: number): Observable<any> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/delete?id=${id}`;
    return this.http.delete(apiUrl);
  }

  getGeneralObjectById(id: number): Observable<GeneralObjectApiModel> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/${id}`;
    return this.http.get<GeneralObjectApiModel>(apiUrl);
  }

  getGeneralObjectsByType(type: string): Observable<GeneralObjectApiModel[]> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/${type}`;
    return this.http.get<GeneralObjectApiModel[]>(apiUrl);
  }

  searchGeneralObjects(searchString: string): Observable<GeneralObjectApiModel[]> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/search/${searchString}`;
    return this.http.get<GeneralObjectApiModel[]>(apiUrl);
  }

  getAllGeneralObjects(): Observable<GeneralObjectApiModel[]> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/all`;
    return this.http.get<GeneralObjectApiModel[]>(apiUrl);
  }

  getChildObjects(id: number): Observable<GeneralObjectApiModel[]> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/childs/${id}`;
    return this.http.get<GeneralObjectApiModel[]>(apiUrl);
  }

  getParentObjects(id: number): Observable<GeneralObjectApiModel[]> {
    const apiUrl = `${this.configService.apiUrl}/api/GeneralObjects/parents/${id}`;
    return this.http.get<GeneralObjectApiModel[]>(apiUrl);
  }

  // Relations Endpoints

  postRelation(data: RelationApiModel): Observable<any> {
    const apiUrl = `${this.configService.apiUrl}/api/Relations/create`;
    return this.http.post(apiUrl, data);
  }

  putRelation(data: RelationApiModel): Observable<any> {
    const apiUrl = `${this.configService.apiUrl}/api/Relations/update`;
    return this.http.put(apiUrl, data);
  }

  deleteRelation(id: string): Observable<any> {
    const apiUrl = `${this.configService.apiUrl}/api/Relations/delete?id=${id}`;
    return this.http.delete(apiUrl);
  }

  getRelationById(id: string): Observable<RelationApiModel> {
    const apiUrl = `${this.configService.apiUrl}/api/Relations/${id}`;
    return this.http.get<RelationApiModel>(apiUrl);
  }

  getAllRelations(): Observable<RelationApiModel[]> {
    const apiUrl = `${this.configService.apiUrl}/api/Relations/all`;
    return this.http.get<RelationApiModel[]>(apiUrl);
  }
}
