import * as request from './requester';

const baseUrl = 'http://localhost:3030'

export const login = (loginData) => {
    return request.post(`${baseUrl}/users/login/`,loginData)
};