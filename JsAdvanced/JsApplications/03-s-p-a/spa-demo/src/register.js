import { showHome } from "./home.js";
import { checkUserNav } from "./util.js";

const section = document.getElementById('registerView');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
section.remove();

export async function showRegister() {
    document.querySelector('main').replaceChildren(section);
}

async function onSubmit(evnt) {
    evnt.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const rePassword = formData.get('rePassword').trim();

    try {

        if (email == '' || password == '') {
            throw new Error('Emplty fields');

        }

        if (rePassword != password) {
            throw new Error('Passwords does not match!');
        }

        const res = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, password })
        })

        if (res.ok == false) {
            const err = await res.json();

            throw new Error(err);
        }

        const {  accessToken, _id } = await res.json();

        const userData = {
            email,
            accessToken,
            id: _id,
        }

        sessionStorage.setItem('userData', JSON.stringify(userData));
        checkUserNav();
        showHome();

    } catch (err) {
        alert(err.message)
    }

}