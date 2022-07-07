import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { Router } from "@angular/router"
@Component({
  selector: 'app-train',
  templateUrl: './train.component.html',
  styleUrls: ['./train.component.css']
})
export class TrainComponent implements OnInit {

  constructor(private service:SharedService, private router: Router) { }

  Phrase:string="";
  Translation:string="";
  PhraseAudioFileName:string="";
  TranslationAudioFileName:string="";
  PhraseAudioFilePath:string="";
  TranslationAudioFilePath:string="";
  CurrentPhrase:number=0;

  AmountStudied:number=0;
  LastStudiedTime:number=0;
  AverageStudiedTime:number=0;
  Checked:boolean=false;
  PreviousTime:number=0;
  CurrentTime:number=0;

  ngOnInit(): void {
    this.getPhraseInfo();
    this.getPhraseTimesInfo();
    this.PreviousTime = new Date().getTime();
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

  getPhraseTimesInfo(){
    this.service.getEngPhrasesTimesList().subscribe(data=>{
      this.AmountStudied=data[this.CurrentPhrase].AmountStudied;
      this.LastStudiedTime=data[this.CurrentPhrase].LastStudiedTime;
      this.AverageStudiedTime=data[this.CurrentPhrase].AverageStudiedTime;
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
  
  checked(){
    this.Checked = true;
    this.CurrentTime = new Date().getTime();
    this.LastStudiedTime = (this.CurrentTime - this.PreviousTime)/1000;
  }

  didNotGet(){
    this.Checked = false;
    this.CurrentPhrase += 1;
    if (this.CurrentPhrase == 5) {
      this.router.navigate(['/']);
    } else {
      this.getPhraseInfo();
      this.getPhraseTimesInfo();
    }
  }

  gotIt(){
    this.Checked = false;
    this.AmountStudied += 1;
    if (this.AverageStudiedTime > 90000) {
      this.AverageStudiedTime = this.LastStudiedTime;
    } else {
      this.AverageStudiedTime = (this.AverageStudiedTime*(this.AmountStudied-1)+this.LastStudiedTime)/this.AmountStudied;
    }
    var val = { StudiedPhraseId:this.CurrentPhrase+1,
    PhraseId:this.CurrentPhrase+1,
    AmountStudied:this.AmountStudied,
    LastStudiedTime:this.LastStudiedTime,
    AverageStudiedTime:this.AverageStudiedTime };
    this.service.updateEngPhraseTimes(val).subscribe(res=>{console.log(res)});
    this.CurrentPhrase += 1;
    if (this.CurrentPhrase == 5) {
      this.router.navigate(['/']);
    } else {
      this.getPhraseInfo();
      this.getPhraseTimesInfo();
      this.PreviousTime = this.CurrentTime;
    }
  }

}
