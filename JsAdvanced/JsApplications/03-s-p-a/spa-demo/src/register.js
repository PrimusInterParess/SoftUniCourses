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
    const passsword = formData.get('passwprd').trim();
    const rePass = formData.get('rePassword').trim();

    try {

        const res = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, passsword }),
        });

        if (res.ok == false) {
            const err = await res.json();

            throw new Error(err.message);
        }

    } catch (err) {
        alert(err.message)
    }

}