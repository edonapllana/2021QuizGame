//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int scoreID { get; set; }
        public int userID { get; set; }
        public int quizID { get; set; }
        public int score1 { get; set; }
    
        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
    }
}
