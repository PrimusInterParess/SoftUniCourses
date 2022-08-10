import { del, get, post, put } from "./api.js";

export async function getAllMemes() {
    return get('/data/memes?sortBy=_createdOn%20desc');
}

export async function getMemeById(id) {
    return get('/data/memes/' + id)
}

export async function createMeme(meme) {
    return post('/data/memes', meme);
}

export async function editMeme(id,meme) {
    return put('/data/memes/'+id, meme);
}

export async function deleteMeme(id) {
    return del('/data/memes/' + id);
}