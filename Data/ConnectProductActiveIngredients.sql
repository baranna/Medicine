insert into dbo.ProductActiveIngredient (ProductId, ActiveIngredientId)
 (
select product.Id, ingredient.Id
from dbo.Product as product, dbo.ActiveIngredient as ingredient
where product.ActiveIngredient LIKE CONCAT('%', ingredient.[Name], '%')
)