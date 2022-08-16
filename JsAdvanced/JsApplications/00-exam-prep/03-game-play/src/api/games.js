import { del, get, post, put } from "./api.js";

export async function getAllGames() {
    return get('/data/games?sortBy=_createdOn%20desc');
}

export async function getMostReacentGames() {
    return get('/data/games?sortBy=_createdOn%20desc&distinct=category');
}

export async function createGame(game) {
    return post('/data/games', game);
}

export async function getGame(gameId) {
    return get('/data/games/' + gameId);
}

export async function deleteGame(gameId) {
    return del('/data/games/' + gameId);
}

export async function editGame(game, gameId) {
    return put('/data/games/' + gameId, game);
}