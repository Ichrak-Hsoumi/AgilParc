using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgilParc.Models
{
    public class Vehicule
    {
        [Key]
        public string Matricule { get; set; }
        public string Type { get; set; }
        public string NumSerie { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateFabrication { get; set; }
        public string Etat { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateMiseEnCirculation { get; set; }
        public int Kilometrage { get; set; }
        public string Moteur { get; set; }
        public int NbrPortes { get; set; }
        public int MaintenanceId { get; set; }
        public Maintenance Maintenance { get; set; }
        public string ParcNom { get; set; }
        public Parc Parc { get; set; }
        public int ChauffeurId { get; set; }
        public Chauffeur Chauffeur { get; set; }
        public int AssurenceNumero { get; set; }
        public Assurence Assurence { get; set; }
        public int VisiteId { get; set; }
        public Visite Visite { get; set; }
        public virtual ICollection<EquipementEmbarque> EquipementEmbarques { get; set; }
    }
}
