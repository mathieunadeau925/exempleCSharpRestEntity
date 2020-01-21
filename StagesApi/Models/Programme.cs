using System;
using System.Collections.Generic;

namespace StagesApi
{
    public partial class Programme
    {
        public Programme()
        {
            Stage = new HashSet<Stage>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Stage> Stage { get; set; }
    }
}
