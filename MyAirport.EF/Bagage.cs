using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLTM.MyAirport.EF
{
    public class Bagage
    {
        /// <summary>
        /// Bagage Constructor
        /// </summary>
        public Bagage()
        {
            CodeIata = "";
        }

        /// <summary>
        /// Bagage Key
        /// </summary>
        [Key]
        public int BagageID { get; set; }

        /// <summary>
        /// Vol linked to Bagage
        /// </summary>
        public Vol? Vol { get; set; }

        /// <summary>
        /// Bagage CodeIata
        /// </summary>
        [Column(TypeName = "char(12)")]
        public string CodeIata { get; set; }

        /// <summary>
        /// Bagage Date of Creation
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Bagage classe
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string? Classe { get; set; }

        /// <summary>
        /// Bagage Priority
        /// </summary>
        public bool? Prioritaire { get; set; }

        /// <summary>
        /// Bagage Sta
        /// </summary>
        [Column(TypeName = "char(1)")]
        public string? Sta { get; set; }

        /// <summary>
        /// Bagage Ssur
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Ssur { get; set; }

        /// <summary>
        /// Bagage Destination
        /// </summary>
        [Column(TypeName = "varchar(3)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string? Destination { get; set; }

        /// <summary>
        /// Bagage Escale
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Escale { get; set; }


    }
}
