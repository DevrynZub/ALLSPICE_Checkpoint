using System.ComponentModel;
using System.ComponentModel.Design;
using ALLSPICE_Checkpoint_csharp.Models;
using Microsoft.AspNetCore.Components.Web;

namespace ALLSPICE_Checkpoint_csharp.Repositories;
public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db){
    _db = db;
  }

    internal int CreateRecipe(Recipes recipeData)
    {
      string sql = @"
      INSERT INTO recipe (title, category, imgUrl, instructions, creatorId)
      VALUES (@title, @Category, @ImgUrl, @CreatorId);
      SelectionTypes LAST_INSERT_ID()
      ;";

      int recipeId = _db.ExecuteScalar<int>(sql, recipeData);

      return recipeId;
    }

    internal Recipes GetRecipeById(int recipeId)
    {
        throw new NotImplementedException();
    }
}