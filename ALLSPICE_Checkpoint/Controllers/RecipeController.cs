using ALLSPICE_Checkpoint_csharp.Models;
using ALLSPICE_Checkpoint_csharp.Services;

namespace ALLSPICE_Checkpoint_csharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0Provider;
  private readonly IngredientsService _ingredientsService;

  public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider, IngredientsService ingredientsService)
  {
_recipesService = recipesService;
_auth0Provider = auth0Provider;
_ingredientsService = ingredientsService;
  }

[Authorize]
[HttpPost]
public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
{
  try
  {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    recipeData.CreatorId = userInfo.Id;
    Recipe recipe = _recipesService.CreateRecipe(recipeData);
    return Ok(recipe);
  }
  catch (Exception e)
  {
    return BadRequest(e.Message);
  }
}

[HttpGet]
public ActionResult<List<Recipe>> GetRecipes()
{
try
{
 List<Recipe> recipes = _recipesService.GetRecipes();
 return Ok(recipes); 
}
catch (Exception e)
{ 
  return BadRequest(e.Message);
}
}

[HttpGet("{recipeId}")]
public ActionResult<Recipe> GetRecipeById(int recipeId)
{
  try
  {
    Recipe recipe = _recipesService.GetRecipeById(recipeId);
    return Ok(recipe);
  }
  catch (Exception e)
  {
    return BadRequest (e.Message);
  }
}

[Authorize]
[HttpPut("{recipeId}")]
public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe recipeData, int recipeId)
{
  try
  {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    recipeData.CreatorId = userInfo.Id;
    Recipe recipe = _recipesService.UpdateRecipe(recipeData, recipeId);
    return Ok(recipe);
  }
  catch (Exception e)
  {
    
return BadRequest(e.Message);
}
}

[Authorize]
[HttpDelete("{recipeId}")]
public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
{
  try
  {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    Recipe recipe = _recipesService.DeleteRecipe(recipeId, userInfo.Id);
    return Ok($"{recipe.Title} has been deleted");
  }
  catch (Exception e)
  {
    
    return BadRequest(e.Message);
  }
}

[HttpGet("{recipeId}/ingredients")]
public ActionResult<List<Ingredient>> GetIngredientByRecipeId(int recipeId)
{
  try
  {
    List<Ingredient> ingredients = _ingredientsService.GetIngredientByRecipeId(recipeId);
  return Ok(ingredients);
  }
  catch (Exception e)
  {
    return BadRequest(e.Message);
  }
}

}
