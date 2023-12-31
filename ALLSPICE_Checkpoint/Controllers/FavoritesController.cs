namespace ALLSPICE_Checkpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0Provider;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
    {
        _favoritesService = favoritesService;
        _auth0Provider = auth0Provider;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
    {
      try 
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        favoriteData.AccountId = userInfo.Id;
        Favorite favorite = _favoritesService.CreateFavorite(favoriteData);
        return Ok(favorite);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{favoriteId}")]
    public async Task<ActionResult<Favorite>> RemoveFavorite(int favoriteId)
    {
      try 
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        _favoritesService.RemoveFavorite(favoriteId, userInfo.Id);
        return Ok("Favorite Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
}