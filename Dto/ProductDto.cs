using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ActiveIngredient { get; set; }

        public string Forms { get; set; }

        public string Strength { get; set; }
    }
}
