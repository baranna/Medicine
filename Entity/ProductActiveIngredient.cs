using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Entity
{
    public class ProductActiveIngredient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ActiveIngredientId { get; set; }

        public ActiveIngredient ActiveIngredient { get; set; }
    }
}
