import { del, get, post, put } from "./api.js";

export async function getAllComments(gameId) {
    return get(`/data/comments?where=gameId%3D%22${gameId}%22`);
}

export async function createComment(comment) {
    return post('/data/comments', comment);
}