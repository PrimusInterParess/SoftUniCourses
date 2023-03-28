import { showHome } from "./home.js";
import { checkUserNav } from "./util.js";

const section = document.getElementById('loginView');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

section.remove();

export async function showLogin() {
    document.querySelector('main').replaceChildren(section);
}

async function onSubmit(evnt) {
    evnt.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');

    try {
        const res = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, password }),
        });

        if (res.ok == false) {
            const err = await res.json();
            throw Error(err.message)
        }

        const data = await res.json();

        const userData = {
            email: data.email,
            accessToken: data.accessToken,
            id: data._id,
        }

        sessionStorage.setItem('userData', JSON.stringify(userData));
        checkUserNav();
        showHome();

    } catch (err) {
        alert(err.message)
    }
}