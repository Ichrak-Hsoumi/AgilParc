using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgilParc.Models
{
    public class Parc
    {
        [Key]
        public string Nom { get; set; }
        public string Materiels { get; set; }
    }
}
