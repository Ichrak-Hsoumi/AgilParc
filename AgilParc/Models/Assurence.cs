using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgilParc.Models
{
    public class Assurence
    {
        [Key]
        public int Numero { get; set; }
        public string Nom { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
