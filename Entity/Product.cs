using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Medicine.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ActiveIngredient { get; set; }

        public string Forms { get; set; }

        public string Strength { get; set; }
    }
}
