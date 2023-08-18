using System.ComponentModel;
using System.ComponentModel.Design;
using ALLSPICE_Checkpoint_csharp.Models;
using Microsoft.AspNetCore.Components.Web;

namespace ALLSPICE_Checkpoint_csharp.Repositories;
public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
    internal int CreateRecipe(Recipe recipeData)
    {
       string sql = @"
        INSERT INTO recipes (title, instructions, img, category, creatorId)
        VALUES (@title, @instructions, @img, @category, @creatorId);
        SELECT LAST_INSERT_ID()
        ;";

      int recipeId = _db.ExecuteScalar<int>(sql, recipeData);

      return recipeId;
    }
    internal Recipe GetRecipeById(int recipeId)
    {
      string sql = @"
      SELECT
      rec.*,
      acc.*
      FROM recipes rec
      JOIN accounts acc ON acc.id = rec.creatorId
      WHERE rec.id = @recipeID LIMIT 1
      ;";

      Recipe recipe  = _db.Query<Recipe, Profile, Recipe>(
        sql,
        (recipe, profile)=>
        {
          recipe.Creator = profile;
          return recipe;
        },
        new { recipeId}).FirstOrDefault();
        return recipe;
          }

    internal List<Recipe> GetRecipes()
    {
    string sql = @"
        SELECT
        rec.*,
        acc.* 
        FROM recipes rec
        JOIN accounts acc ON acc.id = rec.creatorId
        ;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(
            sql,
            (recipe, profile)=>
            {
                recipe.Creator = profile;
                return recipe; 
            }
            ).ToList();
        return recipes;
    }

    internal Recipe UpdateRecipe(Recipe originalRecipe)
    {
      string sql = @"
      UPDATE recipes
      SET
      title = @Title, 
      instructions = @Instructions, 
      img = @Img,
      category = @Category
      WHERE id = @Id
      LIMIT 1;
      SELECT * FROM recipes WHERE id = @Id
      ;";

      Recipe updateRecipe = _db.QueryFirstOrDefault<Recipe>(sql, originalRecipe);

      return updateRecipe;
    }

        internal void DeleteRecipe(int recipeId)
    {
        string sql = @"DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
        _db.Execute(sql, new{recipeId});
    }
}