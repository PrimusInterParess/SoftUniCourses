const section = document.getElementById('loginView');

section.remove();

export async function showLogin() {
    document.querySelector('main').replaceChildren(section);
}