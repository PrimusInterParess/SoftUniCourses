function loadRepos() {
    let inputField = document.getElementById('username');

    fetch(`https://api.github.com/users/${inputField.value}/repos`)
        .then(res => res.json())
        .then(data => console.log(data.map(({ full_name, html_url }) => ({ full_name, html_url }))));
}