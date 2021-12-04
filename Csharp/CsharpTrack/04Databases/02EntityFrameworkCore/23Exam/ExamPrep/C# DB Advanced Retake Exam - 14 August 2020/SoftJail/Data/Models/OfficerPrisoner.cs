using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [ForeignKey(nameof(Prisoner))]
        public int PrisonerId { get; set; }

        public virtual Prisoner Prisoner { get; set; }

        [ForeignKey(nameof(Officer))]
        public int OfficerId { get; set; }

        public virtual Officer Officer { get; set; }
        

        /*
         *
         * OfficerPrisoner
        •	PrisonerId – integer, Primary Key
        •	Prisoner – the officer’s prisoner (required)
        •	OfficerId – integer, Primary Key
        •	Officer – the prisoner’s officer (required)
        
         */
    }
}
