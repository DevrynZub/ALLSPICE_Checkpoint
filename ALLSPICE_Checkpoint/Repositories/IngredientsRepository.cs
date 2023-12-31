namespace ALLSPICE_Checkpoint.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients(name, quantity, recipeId, creatorId)
        VALUES
        (@name, @Quantity, @RecipeId, @CreatorId);
        SELECT LAST_INSERT_ID()
        ;";

        int ingredientId = _db.ExecuteScalar<int>(sql, ingredientData);
        return ingredientId;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"
        SELECT * FROM ingredients 
        WHERE id = @ingredientId
        ;";
        
        Ingredient ingredient = _db.QueryFirstOrDefault<Ingredient>(sql, new {ingredientId});
        return ingredient;
    }

    internal List<Ingredient> GetIngredientByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT 
        *
        FROM ingredients 
        WHERE recipeId = @recipeId;
        ;";

        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new {recipeId}).ToList();
        return ingredients;
    }

    internal void RemoveIngredient(int ingredientId)
    {
        string sql = @"DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
        _db.Execute(sql, new {ingredientId});
    }
}