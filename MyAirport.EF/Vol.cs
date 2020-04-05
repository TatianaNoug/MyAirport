using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLTM.MyAirport.EF
{
    public class Vol
    {
        public Vol()
        {
            Cie = "";
            Lig = "";
            Bagages = new List<Bagage>();
        }

        [Key]
        public int VolID { get; set; }

        [Column(TypeName = "char(10)")]
        public string Cie { get; set; }

        [Column(TypeName = "char(5)")]
        public string Lig { get; set; }

        public DateTime Dhc { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Pkg { get; set; }

        [Column(TypeName = "char(6)")]
        public string? Imm { get; set; }

        public short? Pax { get; set; }

        [Column(TypeName = "char(3)")]
        public string? Des { get; set; }


        public virtual ICollection<Bagage> Bagages { get; set; }
    }
}
