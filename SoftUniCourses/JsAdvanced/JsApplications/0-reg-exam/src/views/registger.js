import { register } from '../api/users.js';
import { html } from '../lib.js'


const registerTemp = (onSubmit) => html `  <section id="register">
<div class="form">
  <h2>Register</h2>
  <form @submit=${onSubmit} class="login-form">
    <input
      type="text"
      name="email"
      id="register-email"
      placeholder="email"
    />
    <input
      type="password"
      name="password"
      id="register-password"
      placeholder="password"
    />
    <input
      type="password"
      name="re-password"
      id="repeat-password"
      placeholder="repeat password"
    />
    <button type="submit">login</button>
    <p class="message">Already registered? <a href="/login">Login</a></p>
  </form>
</div>
</section>`


export async function registerView(ctx) {
    ctx.render(registerTemp(onSubmit));

    async function onSubmit(evnt) {
        evnt.preventDefault();

        const formData = new FormData(evnt.target);

        const email = formData.get('email');
        const password = formData.get('password');
        const rePassword = formData.get('re-password');

        if (rePassword == '' || email == '' || password == '') {
            return alert('All fields are required!')
        }

        if (password != rePassword) {
            return alert('Passwords don\'t match!');
        }

        await register(email, password);
        ctx.updateNav();
        ctx.page.redirect('/dashboard');

    }
}