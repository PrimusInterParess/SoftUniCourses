import { html, render } from 'https://unpkg.com/lit-html?module';

const template = (name) => html `<h2> Hello there, ${name}</h2>`;

start();

function start() {
    const main = document.querySelector('main');

    const temlateRes = template('Peter');

    render(temlateRes, main);
}