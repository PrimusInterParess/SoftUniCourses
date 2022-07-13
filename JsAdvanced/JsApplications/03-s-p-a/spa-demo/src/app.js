import { showAbout } from "./about.js";
import { showCatalog } from "./catalog.js";
import { showHome } from "./home.js";
import { showRegister } from "./register.js";
import { showLogin } from "./login.js";


document.querySelector('nav').addEventListener('click', onNavigate);

showHome();

const sections = {
    'homeBtn': showHome,
    'catalogBtn': showCatalog,
    'aboutBtn': showAbout,
    'registerBtn': showRegister,
    'loginBtn': showLogin,

}

async function onNavigate(e) {

    if (e.target.tagName == 'A') {

        const view = sections[e.target.id];

        if (typeof view == 'function') {
            e.preventDefault();
            view();

        }

    }

}