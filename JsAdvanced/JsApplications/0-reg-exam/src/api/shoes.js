import { del, get, post, put } from "./api.js";

export async function getAllShoes() {
    return get('/data/shoes?sortBy=_createdOn%20desc');
}

export async function createShoe(shoe) {
    return post('/data/shoes', shoe);
}

export async function getShoe(shoeId) {
    return get('/data/shoes/' + shoeId);
}


export async function deleteShoe(shoeId) {
    return del('/data/shoes/' + shoeId);
}

export async function editShoe(shoe, shoeId) {
    return put('/data/shoes/' + shoeId, shoe);
}

export async function searchEngine(query) {
    return get(`/data/shoes?where=brand%20LIKE%20%22${query}%22`);
}