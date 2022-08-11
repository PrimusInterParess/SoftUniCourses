import { del, get, post, put } from "./api.js";

export async function getAllPosts() {
    return get('/data/posts?sortBy=_createdOn%20desc');
}

export async function createPost(postData) {
    return post('/data/posts', postData)
}