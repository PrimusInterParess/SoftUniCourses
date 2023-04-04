const baseUrl = `http://localhost:3005/api/users`;


export const GetAll = async () => {

    const response = await fetch(baseUrl);
    const result = await response.json();

    return result.users;
};

export const GetUser = async (id) => {

    const response = await fetch(`${baseUrl}/${id}`);
    const result = await response.json();

    return result.user;
};

export const CreateUser = async (inputData) => {
    const { city, country, street, streetNumber, ...data } = inputData;
    data.address = {
        city,
        country,
        street,
        streetNumber,
    }
    
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(data)
    });

    const result = await response.json();

    return result.user;
};