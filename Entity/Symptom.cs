using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Entity
{
    public class Symptom
    {
        public Symptom()
        {
            this.Diseases = new HashSet<Disease>();
            this.Syndromes = new HashSet<Syndrome>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }

        public virtual ICollection<Syndrome> Syndromes { get; set; }
    }
}
