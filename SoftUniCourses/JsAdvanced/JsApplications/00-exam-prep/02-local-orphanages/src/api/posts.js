import { del, get, post, put } from "./api.js";

export async function getAllPosts() {
    return get('/data/posts?sortBy=_createdOn%20desc');
}

export async function createPost(postData) {
    return post('/data/posts', postData)
}

export async function getPostById(id) {
    return get('/data/posts/' + id);
}

export async function deletePost(id) {
    return del('/data/posts/' + id);
}

export async function editPost(id, postData) {
    return put('/data/posts/' + id, postData);
}

export async function getPostsByUserId(userId) {
    return get(`/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function getTotalDonation(postId) {
    return get(`/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`);
}

export async function makeDonation(postId) {
    return post('/data/donations', postId);
}

export async function Donated(postId, userId) {
 return get(`/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}