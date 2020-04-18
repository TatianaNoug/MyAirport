using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLTM.MyAirport.EF
{
    public class Vol
    {
        /// <summary>
        /// Vol Constructor
        /// </summary>
        public Vol()
        {
            Cie = "";
            Lig = "";
            Bagages = new List<Bagage>();
        }

        /// <summary>
        /// Vol Key
        /// </summary>
        [Key]
        public int VolID { get; set; }

        
        /// <summary>
        /// Vol Company
        /// </summary>
        [Column(TypeName = "char(10)")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Cie { get; set; }

        /// <summary>
        /// Vol Lig
        /// </summary>
        [Column(TypeName = "char(5)")]
        public string Lig { get; set; }

        /// <summary>
        /// Vol Dhc
        /// </summary>
        public DateTime Dhc { get; set; }

        /// <summary>
        /// Vol Pkg
        /// </summary>
        [Column(TypeName = "char(3)")]
        public string? Pkg { get; set; }

        /// <summary>
        /// Vol Imm
        /// </summary>
        [Column(TypeName = "char(6)")]
        public string? Imm { get; set; }

        /// <summary>
        /// Vol Pax
        /// </summary>
        public short? Pax { get; set; }

        /// <summary>
        /// Vol Destination
        /// </summary>
        [Column(TypeName = "char(3)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string? Des { get; set; }


        /// <summary>
        /// Bagages flying with this Vol
        /// </summary>
        public virtual ICollection<Bagage> Bagages { get; set; }
    }
}
