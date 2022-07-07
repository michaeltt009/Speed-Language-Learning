import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44355/api";
  readonly AudioUrl = "https://localhost:44355/AudioFiles/";

  constructor(private http:HttpClient) { }

  getEngPhrasesList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/EnglishPhrases');
  }

  addEngPhrase(val:any){
    return this.http.post(this.APIUrl+'/EnglishPhrases',val);
  }

  updateEngPhrase(val:any){
    return this.http.put(this.APIUrl+'/EnglishPhrases',val);
  }

  deleteEngPhrase(val:any){
    return this.http.delete(this.APIUrl+'/EnglishPhrases/'+val);
  }

  getItlPhrasesList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/ItalianPhrases');
  }

  addItlPhrase(val:any){
    return this.http.post(this.APIUrl+'/ItalianPhrases',val);
  }

  updateItlPhrase(val:any){
    return this.http.put(this.APIUrl+'/ItalianPhrases',val);
  }

  deleteItlPhrase(val:any){
    return this.http.delete(this.APIUrl+'/ItalianPhrases/'+val);
  }

  getEngPhrasesTimesList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/EnglishPhrasesTimes');
  }

  addEngPhraseTimes(val:any){
    return this.http.post(this.APIUrl+'/EnglishPhrasesTimes',val);
  }

  updateEngPhraseTimes(val:any){
    return this.http.put(this.APIUrl+'/EnglishPhrasesTimes',val);
  }

  deleteEngPhraseTimes(val:any){
    return this.http.delete(this.APIUrl+'/EnglishPhrasesTimes/'+val);
  }
}
