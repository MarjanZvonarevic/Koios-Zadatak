using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcNaseljaModel
    {   [Key]
        public int NaseljeId { get; set; }

        [Required(ErrorMessage ="Morate ispuniti ovo polje")]
        public string Naselje { get; set; }

        [Required(ErrorMessage = "Morate ispuniti ovo polje")]
        public string PBroj { get; set; }

        [Required(ErrorMessage = "Morate ispuniti ovo polje")]
        public string Država { get; set; }
    }
}