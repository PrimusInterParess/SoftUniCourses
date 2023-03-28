import { logout } from './api/users.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js'
import { catalogView } from './views/catalog.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { registerView } from './views/registger.js';

page(decorateContext);
page('/', homeView);
page('/catalog', catalogView);
page('/login', loginView);
page('/register', registerView);
page('/create-game', createView);
page('/games/:id', detailsView);
page('/edit/:id', editView);




const main = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', onLogout);
updateNav();
page.start();


function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    next();
}

function renderMain(temlateResult) {

    render(temlateResult, main);
}

function updateNav() {
    const userData = getUserData();

    if (userData) {
        document.querySelector('#user').style.display = 'block';
        document.querySelector('#guest').style.display = 'none';

        console.log(document.querySelector('.user'));


    } else {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'block';
    }
}

function onLogout() {
    logout();
    updateNav();
    page.redirect('/');
}