import { showCatalog } from "./catalog.js";
import { checkUserNav } from "./util.js";

const section = document.getElementById('createView');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

section.remove();

export async function showCreate() {
    document.querySelector('main').replaceChildren(section);
}

async function onSubmit(evnt) {
    evnt.preventDefault();

    const formData = new FormData(form);

    const title = formData.get('title');


    try {
        const res = await fetch('http://localhost:3030/data/movies', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': JSON.parse(sessionStorage.getItem('userData')).accessToken
              
            },
            body: JSON.stringify({ title }),
        });

        if (res.ok == false) {
            const err = await res.json();
            throw Error(err.message)
        }


      
        showCatalog();

    } catch (err) {
        alert(err.message)
    }
}