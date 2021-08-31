using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgilParc.Models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public string Operations { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Cout { get; set; }
        public string Lieu { get; set; }
    }
}
