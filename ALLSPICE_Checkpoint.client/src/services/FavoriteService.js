import { AppState } from "../AppState.js";
import { Favorite } from "../models/Favorite.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";


class FavoriteService {

  async getFavorites() {
    const res = await api.get('account/favorites')
    logger.log('favorites res data', res.data)
    const favorites = res.data.map(f => new Favorite(f))
    // logger.log('mapped res data', favorites)
    AppState.favorites = favorites
    logger.log('appstate favorites', AppState.favorites)
  }

  async createFavorite(favoriteData) {
    const res = await api.post('api/favorites', favoriteData)
    // logger.log('favorites res data', res.data)
    const favorite = new Favorite(res.data)
    // logger.log('new favorite', favorite)
    AppState.favorites.push(favorite)
    logger.log('New favorite', AppState.favorites)
  }

  async removeFavorite(favoriteId) {
    await api.delete(`api/favorites/${favoriteId}`)
    const favoriteIndex = AppState.favorites.findIndex(favorites => favorites.favoriteId == favoriteId)
    AppState.favorites.splice(favoriteIndex, 1)
  }


}

export const favoriteService = new FavoriteService()