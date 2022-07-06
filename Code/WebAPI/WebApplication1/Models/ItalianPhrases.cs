using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ItalianPhrases
    {
        public int PhraseId { get; set; }
        public string Phrase { get; set; }
        public string Translation { get; set; }
        public string PhraseAudioFileName { get; set; }
        public string TranslationAudioFileName { get; set; }
    }
}