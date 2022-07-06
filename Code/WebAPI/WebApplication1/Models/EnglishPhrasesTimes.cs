using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EnglishPhrasesTimes
    {
        public int StudiedPhraseId { get; set; }
        public int PhraseId { get; set; }
        public int AmountStudied { get; set; }
        public float LastStudiedTime { get; set; }
        public float AverageStudiedTime { get; set; }

    }
}