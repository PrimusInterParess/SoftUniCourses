async function loadRepos() {
    let inputField = document.getElementById('username');

    let repos = document.getElementById('repos');

    let result = await fetch(`https://api.github.com/users/${inputField.value}/repos`)
       // .then(res => res.json())
    // .then(data => (data.map(({ full_name, html_url }) => ({ full_name, html_url }))));

    console.log(result);


    // for (const repo of result) {

    //     console.log(repo.full_name, repo.html_url);
    // }
}