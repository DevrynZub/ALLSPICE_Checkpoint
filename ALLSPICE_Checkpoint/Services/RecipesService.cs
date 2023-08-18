using ALLSPICE_Checkpoint_csharp.Models;
using ALLSPICE_Checkpoint_csharp.Repositories;


namespace ALLSPICE_Checkpoint_csharp.Services;
public class RecipesService
{
  private readonly RecipesRepository _recipesRepository;

  public RecipesService(RecipesRepository recipesRepository){
    _recipesRepository = recipesRepository;
  }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      int recipeId = _recipesRepository.CreateRecipe(recipeData);
      Recipe recipe = GetRecipeById(recipeId);
      return recipe;
    }


    internal Recipe GetRecipeById(int recipeId)
    {
Recipe recipe = _recipesRepository.GetRecipeById(recipeId);

if (recipe == null)
{
throw new Exception("Bad Id");
}
return recipe;
 }
 internal List<Recipe> GetRecipes()
    {
      List<Recipe> recipes = _recipesRepository.GetRecipes();
return recipes;
    }

    internal Recipe UpdateRecipe(Recipe recipeData, int recipeId)
    {
      Recipe originalRecipe = GetRecipeById(recipeId);
      if(originalRecipe.CreatorId != recipeData.CreatorId)
      {
        throw new Exception("YO THIS ISN'T YOUR RECIPE");
      }
      originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
      originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
      originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
      originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;
    
    Recipe recipe = _recipesRepository.UpdateRecipe(originalRecipe);
    return recipe;

    }


    internal Recipe DeleteRecipe(int recipeId, string userId)
    {
      Recipe recipe = GetRecipeById(recipeId);
      if(recipe.CreatorId != userId)
      {
        throw new Exception("THIS IS NOT YOUR DATA, YOU CAN NOT REMOVE IT");
      }
      _recipesRepository.DeleteRecipe(recipeId);
      return recipe;
    }
}
