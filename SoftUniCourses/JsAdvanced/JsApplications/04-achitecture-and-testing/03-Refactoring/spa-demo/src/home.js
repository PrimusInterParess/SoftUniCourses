const section = document.getElementById('homeView');

section.remove();

export async function showHome() {

    document.querySelector('main').replaceChildren(section);

}

