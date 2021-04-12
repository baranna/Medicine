using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Entity
{
    public class SideEffectFrequency
    {
        public int Id { get; set; }

        public string Frequency { get; set; }

        public string CidId { get; set; }

        public ActiveIngredient ActiveIngredient { get; set; }

        public SideEffect SideEffect { get; set; }

        public string SideEffectName { get; set; }

    }
}
