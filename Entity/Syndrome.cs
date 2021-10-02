using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Medicine.Entity
{
    public class Syndrome
    {
        public Syndrome()
        {
            this.Symptoms = new HashSet<Symptom>();
        }

        public int Id { get; set; }

        public int DiseaseId { get; set; }

        public virtual Disease Disease { get; set; }

        public virtual ICollection<Symptom> Symptoms { get; set; }

    }
}
