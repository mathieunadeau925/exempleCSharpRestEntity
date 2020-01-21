using System;
using System.Collections.Generic;

namespace StagesApi
{
    public partial class Stage
    {
        public int Id { get; set; }
        public string Etat { get; set; }
        public string NomPoste { get; set; }
        public double? Salaire { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int? EntrepriseId { get; set; }
        public int? ProgrammeId { get; set; }

        public virtual Entreprise Entreprise { get; set; }
        public virtual Programme Programme { get; set; }
    }
}
