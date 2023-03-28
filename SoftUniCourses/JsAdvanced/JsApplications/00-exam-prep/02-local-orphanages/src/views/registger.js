import { register } from '../api/users.js';
import { html } from '../lib.js'


const registerTemp = (onSubmit) => html`
<section id="register-page" class="auth">
<form @submit=${onSubmit} id="register">
    <h1 class="title">Register</h1>

    <article class="input-group">
        <label for="register-email">Email: </label>
        <input type="email" id="register-email" name="email">
    </article>

    <article class="input-group">
        <label for="register-password">Password: </label>
        <input type="password" id="register-password" name="password">
    </article>

    <article class="input-group">
        <label for="repeat-password">Repeat Password: </label>
        <input type="password" id="repeat-password" name="repeatPassword">
    </article>

    <input type="submit" class="btn submit-btn" value="Register">
</form>
</section>`


export async function registerView(ctx) {
    ctx.render(registerTemp(onSubmit));

    async function onSubmit(evnt) {
        evnt.preventDefault();

        const formData = new FormData(evnt.target);

        const email = formData.get('email');
        const password = formData.get('password');
        const rePassword = formData.get('repeatPassword');

        if (rePassword == '' ||  email == '' || password == '') {
            return alert('All fields are required!')
        }

        if (password != rePassword) {
           return alert('Passwords don\'t match!');
        }

        await register(email,password);
        ctx.updateNav();
        ctx.page.redirect('/');

    }
}