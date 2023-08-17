using ALLSPICE_Checkpoint_csharp.Models;
using ALLSPICE_Checkpoint_csharp.Repositories;


namespace ALLSPICE_Checkpoint_csharp.Services;
public class RecipesService
{
  private readonly RecipesRepository _recipesRepository;

  public RecipesService(RecipesRepository recipesRepository){
    _recipesRepository = recipesRepository;
  }

    internal Recipes CreateRecipe(Recipes recipeData)
    {
      int recipeId = _recipesRepository.CreateRecipe(recipeData);
      Recipes recipe = GetRecipeById(recipeId);
      return recipe;
    }

    internal Recipes GetRecipeById(int recipeId)
    {
Recipes recipe = _recipesRepository.GetRecipeById(recipeId);

if (recipe == null)
{
throw new Exception("Your request was <i>exceptional<i>exceptional</i>");
}
return recipe;
 }
}