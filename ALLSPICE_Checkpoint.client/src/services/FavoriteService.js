import { AppState } from "../AppState.js";
import { Favorite } from "../models/Favorite.js";
import Pop from "../utils/Pop.js";
import { api } from "./AxiosService.js";


class FavoriteService {

  async getMyFavorites() {
    try {
      const res = await api.get('account/favorites');
      const favorites = res.data.map(favorite => new Favorite(favorite));
      AppState.favorites = favorites;
    } catch (error) {
      Pop.error(error.message, '[FAVORITES-SERVICE]')
    }
  }
}

export const favoriteService = new FavoriteService()