function validate() {
    document.getElementById('email').addEventListener('change', function(e) {

        var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        let email = e.currentTarget.value;

        if (!email.match(validRegex)) {

            e.currentTarget.className = 'error';
        } else {
            e.currentTarget.className = '';
        }

    })
}