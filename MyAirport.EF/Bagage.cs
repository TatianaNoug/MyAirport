using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LucLopTatMei.MyAirport.EF
{
    public class Bagage
    {
        public Bagage()
        {
            CodeIata = "";
        }

        [Key]
        public int BagageID { get; set; }


        public Vol? Vol { get; set; }

        [Column(TypeName = "char(12)")]
        public string CodeIata { get; set; }

        public DateTime DateCreation { get; set; }

        [Column(TypeName = "char(1)")]
        public string? Classe { get; set; }

        public bool? Prioritaire { get; set; }

        [Column(TypeName = "char(1)")]
        public string? Sta { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Ssur { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string? Destination { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Escale { get; set; }


    }
}
