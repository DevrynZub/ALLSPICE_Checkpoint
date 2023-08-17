using ALLSPICE_Checkpoint_csharp.Models;
using ALLSPICE_Checkpoint_csharp.Services;

namespace ALLSPICE_Checkpoint_csharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0Provider;

  public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider)
  {
_recipesService = recipesService;
_auth0Provider = auth0Provider;
  }

[Authorize]
[HttpPost]

public async Task<ActionResult<Recipes>> CreateRecipe([FromBody] Recipes recipeData)
{
  try
  {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    recipeData.CreatorId = userInfo.Id;
    Recipes recipe = _recipesService.CreateRecipe(recipeData);
    return Ok(recipe);
  }
  catch (Exception e)
  {
    return BadRequest(e.Message);
  }
}


}
