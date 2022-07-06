import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { Router } from "@angular/router"

@Component({
  selector: 'app-study',
  templateUrl: './study.component.html',
  styleUrls: ['./study.component.css']
})
export class StudyComponent implements OnInit {

  constructor(private service:SharedService, private router: Router) { }

  Phrase:string="";
  Translation:string="";
  PhraseAudioFileName:string="";
  TranslationAudioFileName:string="";
  PhraseAudioFilePath:string="";
  TranslationAudioFilePath:string="";
  CurrentPhrase:number=0;

  ngOnInit(): void {
    this.getPhraseInfo();
  }

  getPhraseInfo(){
    this.service.getEngPhrasesList().subscribe(data=>{
      this.Phrase=data[this.CurrentPhrase].Phrase;
      this.Translation=data[this.CurrentPhrase].Translation;
      this.PhraseAudioFileName=data[this.CurrentPhrase].PhraseAudioFileName;
      this.TranslationAudioFileName=data[this.CurrentPhrase].TranslationAudioFileName;
      this.PhraseAudioFilePath=this.service.AudioUrl+this.PhraseAudioFileName;
      this.TranslationAudioFilePath=this.service.AudioUrl+this.TranslationAudioFileName;
    });
  }

  playPhraseAudio(){
    let audio = new Audio();
    audio.src = this.PhraseAudioFilePath;
    audio.load();
    audio.play();
  }

  playTranslationAudio(){
    let audio = new Audio();
    audio.src = this.TranslationAudioFilePath;
    audio.load();
    audio.play();
  }

  changePhrase(){
    this.CurrentPhrase += 1;
    if (this.CurrentPhrase == 5) {
      this.router.navigate(['/']);
    } else {
      this.getPhraseInfo();
    }
  }

}
