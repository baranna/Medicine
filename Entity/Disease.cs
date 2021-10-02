using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Medicine.Entity
{
    public class Disease
    {
        public Disease()
        {
            this.Symptoms = new HashSet<Symptom>();
            this.Syndromes = new List<Syndrome>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Precautions { get; set; }

        public virtual ICollection<Symptom> Symptoms { get; set; }

        public virtual ICollection<Syndrome> Syndromes { get; set; }
    }
}
