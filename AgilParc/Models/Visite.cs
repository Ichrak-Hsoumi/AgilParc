using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgilParc.Models
{
    public class Visite
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateVisite { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateExpiration { get; set; }
    }
}
