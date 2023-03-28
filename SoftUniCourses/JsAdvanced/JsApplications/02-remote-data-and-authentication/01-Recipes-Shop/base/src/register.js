document.querySelector('form').addEventListene('submit', onSubmit);

async function onSubmit(evnt) {
    evnt.preventDefault();

    const formData = new FormData(evnt.target);

    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    try {
        //validate inputs

        //check passwords equallity

        //register user

        //check response
        //deserialize response

        //extraxct token from sessionStorage

        // redirect window.location='/';
    } catch (error) {

    }
}